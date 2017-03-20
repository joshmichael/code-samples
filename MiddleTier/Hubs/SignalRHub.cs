using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Sabio.Web.Models.Requests;
using Sabio.Web.Domain;
using Sabio.Web.Domain.Quotes;
using Microsoft.Practices.Unity;
using Sabio.Web.Services.Interfaces;

namespace Sabio.Web.Hubs
{

    public class SignalRHub : Hub 
    {

        //....// =========================== DEPENDENCY INJECTION BEGIN ===========================================

        [Dependency]
        public IUserProfileService _UserProfileService { get; set; }

        [Dependency]
        public INotificationService _NotificationService { get; set; }

        //....// =========================== DEPENDENCY INJECTION BEGIN ===========================================




        //....// ===================================================================================
        // - Establish list container connectedUsers 
        //....// ===================================================================================
        static List<ConnectedUserDomain> connectedUsers = new List<ConnectedUserDomain>();
        





        //....// ===================================================================================
        // - Method to remove users already logged in (to mitigate duplicates)
        //....// ===================================================================================
        public static bool DuplicateUsersToBeRemoved(ConnectedUserDomain human, string userId)
        {
            return (human.UserId == userId);
        }





        //....// ===================================================================================
        // - Handles asychronous communication with the angular controller function of the same name
        //....// ===================================================================================
        public static void SendMessage(MessageInsertRequest model)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<SignalRHub>();

            foreach (ConnectedUserDomain userX in connectedUsers)
            {
                if (userX.UserId == model.ReceiverId)
                {
                    string conId = userX.UserConnectionId;
                    hubContext.Clients.Client(conId).addNewMessageToPage(model.Content);

                }
            }
        }





        //....// ===================================================================================
        // - Status notification
        //....// ===================================================================================
        public static void SendNotification(NotificationInsertRequest model)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<SignalRHub>();
            foreach (ConnectedUserDomain userX in connectedUsers)
            {
                if (userX.UserId == model.UserId)
                {
                    string conId = userX.UserConnectionId;
                    hubContext.Clients.Client(conId).addNewNotificationToPage(model.Message1);
                    
                }
            }
        }





        //....// ============================================================================
        // - Connecting logged in users to the SignalR framework
        //....// ============================================================================
        public void Connect(string userName, string userId)
        {
            string conId = Context.ConnectionId;

            // - If the number of connected users that have the same connectionId is 0
            if (connectedUsers.Count(userX => userX.UserConnectionId == conId) == 0)
            {
                List<ConnectedUserDomain> usersToBeRemoved = connectedUsers.Where(thisConnectedUser => DuplicateUsersToBeRemoved(thisConnectedUser, userId)).ToList();

                foreach (ConnectedUserDomain userX in usersToBeRemoved)
                {
                    connectedUsers.Remove(userX);
                }

                connectedUsers.Add(new ConnectedUserDomain { UserConnectionId = conId, UserName = userName, UserId = userId });

                System.Diagnostics.Debug.WriteLine("connectedUsers are: ", connectedUsers);
            }
        }





        //....// ==============================================================================
        // - If a user already exists that has the same incomming connection ID disconnect them
        //....// ==============================================================================
        public override Task OnDisconnected(bool stopCalled)
        {
            connectedUsers.FirstOrDefault(userX => userX.UserConnectionId == Context.ConnectionId);

            Clients.All.removeConnection(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }





        //....// =================================================================================
        // - For the Active Quote Requests Widget 
        //....// =================================================================================
        public static void QuoteRequestUpdated(QuoteRequestDomain model, List<CompanyEmployeeDomain> employee_ActiveQR, string QRmessage)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<SignalRHub>();

            foreach (CompanyEmployeeDomain employee in employee_ActiveQR)
            {

                foreach (ConnectedUserDomain userX in connectedUsers)
                {
                    if (userX.UserId == employee.UserId)
                    {
                        string conId = userX.UserConnectionId;
                        hubContext.Clients.Client(conId).addNewActiveQRCountToPage();
                        
                        hubContext.Clients.Client(conId).addNewActiveQRMessage(QRmessage);

                    }
                }

            }

        }





        //....// =================================================================================
        // - For new bid count & bid notification
        //....// =================================================================================
        public static void BidUpdated (BidDomain model, List<CompanyEmployeeDomain> employee_ActiveBid, string bidMessage)
        {
            IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<SignalRHub>();

            foreach (CompanyEmployeeDomain employee in employee_ActiveBid)
            {

                foreach (ConnectedUserDomain userX in connectedUsers)
                {
                    if (userX.UserId == employee.UserId)
                    {
                        string conId = userX.UserConnectionId;
                        hubContext.Clients.Client(conId).addNewActiveBidCountToPage();

                        hubContext.Clients.Client(conId).addNewActiveBidMessage(bidMessage);

                    }
                }

            }
        }
    }
    }