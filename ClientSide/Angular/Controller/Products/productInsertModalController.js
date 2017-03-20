/*

==============================================================================================

    - Handles the product insert modal form functionality
    - Fires product insert (POST) ajax call
    - Manages hard coded category list for "chosen" drop down menu
    - Dev. Josh May

==============================================================================================

*/



(function () {
    "use strict";

    //....// Establishing the modal insert controller
    angular.module(APPNAME).controller("productInsertModalController", ProductInsertModalController);

    //....// Advising angular that we are going to include these objects into our ProductInsertModalController
    ProductInsertModalController.$inject = ["$scope", "$baseController", "$uibModalInstance", "$productService", "$uibModal"];

    function ProductInsertModalController($scope, $baseController, $uibModalInstance, $productService, $uibModal) {

        //....// Setting view model object
        var vm = this;

        //....// Simulating inheritance
        $baseController.merge(vm, $baseController);

        //....// Making the $scope available outside the function
        vm.$scope = $scope;

        //....// Making the the bootstrap ng modal instance available outside the IIFE
        vm.$uibModalInstance = $uibModalInstance;

        vm.ok = _ok;
        vm.cancel = _cancel;
        vm.$productService = $productService;
        vm.submitForm = _submitForm;
        vm.insert = _insert;
        vm.$uibModal = $uibModal;
        vm.categories = sabio.page.masterformat;

        //....// Best practice for two-way data binding (empty object)
        vm.thisProduct = {};
        

        //....// Ajax product post call
        function _insert()
        {

            var payload =
            {
                "userId": $("#PAGEUSER").val()
                , "companyId": $("#PAGECOMPANY").val()
                , "name": sabio.page.masterformat[vm.thisProduct.category]
                , "category": vm.thisProduct.category
                , "cost": vm.thisProduct.cost
                , "minPurchase": vm.thisProduct.minPurchase
                , "description": vm.thisProduct.description
                , "quantity": vm.thisProduct.quantity
                , "threshold": vm.thisProduct.threshold

            }

            vm.$productService.insert(payload, vm.ok, _onProductError);

        };


        //....// If error during post ajax call
        function _onProductError(jqXhr, error) {
            console.log(error);

        };

        //....// Validate form - call the insert function
        function _submitForm(isValid) {
            if (isValid) {
                _insert();
            }

            else {
                console.log("Form data is invalid");
            }

        };


        //....// $uibModalInstance is used to comunicate and send data back to the main controller
        //...//  Closes modal on click of submit button
        function _ok () 
        {
            vm.$uibModalInstance.close();

        };

        //....// Close button of the modal update form
        function _cancel () {
            vm.$uibModalInstance.dismiss("cancel");

        };

    };

})();
