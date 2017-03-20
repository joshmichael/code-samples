//....//=================================================================================================
// - SignalR angular service. Inject "$signalRService" into your controller as needed.
// - Dev. - Josh May
//....//=================================================================================================


(function ()
{
    "use strict",

    angular.module(APPNAME).factory("$signalRService", SignalRService);


    SignalRService.$inject = ["$baseService", "$sabio"];
    




    //....// ============================================================================
    // - Initialize connection to SignalR
    //....// ============================================================================
    $.connection.hub.start().done(function ()
    {
        console.log("SignalR initialized successfully.");

        _sendUserInfoToSignalRHub(); // - Call function to compile user info into SignalR

    }).fail(function () { alert("SignalR connection failed.") });

    
    var signalRHub = $.connection.signalRHub; // - Setting signalRHub variable to the open connection of SignalRHub
    




    //....// ============================================================================
    // - SignalR service core function
    //....// ============================================================================
    function SignalRService($baseService, $sabio)
    {

        var newService = $baseService.merge(true, {}, signalRHub);

        newService.CallbackRegistration = function (functionName, callbackFunction, overwrite) // - Controller callback function
        {
            if (overwrite === true || (overwrite !== true && typeof signalRHub.client[functionName] !== "function"))
            {
                signalRHub.client[functionName] = callbackFunction;
            }

        };

        return newService;

    };
    




    //....// ============================================================================
    // - Sending connected user info to SignalR framework
    //....// ============================================================================
    function _sendUserInfoToSignalRHub()
    {

        var companyName = $("#COMPANYNAME").val(); // - Used for readability
        var userId = $("#PAGEUSER").val();

        signalRHub.server.connect(companyName, userId) // - Call connect method on SignalRHub

        console.log(companyName, "is connected to SignalR.");
    };  


})();