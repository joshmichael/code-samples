/*

================================================================================================

    - Handles the product insert modal form functionality
    - Fires product insert (POST) ajax call
    - Manages hard coded category list for "chosen" drop down menu

================================================================================================

*/



(function () {
    "use strict";

    //....// Establishing the modal controller
    angular.module(APPNAME).controller("productEditModalController", ProductEditModalController);

    //....// Injecting (similiar to inheritance)
    ProductEditModalController.$inject = ["$scope", "$baseController", "$uibModalInstance", "productSelected", "$productService"];

    function ProductEditModalController($scope, $baseController, $uibModalInstance, productSelected, $productService) {

        //....// Setting view model object
        var vm = this;

        //....// Merging the view model with the $baseController
        $baseController.merge(vm, $baseController);

        //....// Making the $scope available outside the function
        vm.$scope = $scope;

        //....// Making the the bootstrap ng modal instance available outside the function
        vm.$uibModalInstance = $uibModalInstance;

        vm.ok = _ok;
        vm.cancel = _cancel;
        vm.$productService = $productService;
        vm.productSelected = productSelected;
        vm.submitForm = _submitForm;
        vm.update = _update;
        vm.categoryMasterList = sabio.page.masterformat;


        //....// Populating data for the modal forms drop down category options
        vm.categories = sabio.page.masterformat;



        var payload =
            {
                "productId": vm.productSelected.productId
                , "userId": vm.productSelected.userId
                , "companyId": vm.productSelected.companyId
                , "name": sabio.page.masterformat[vm.productSelected.category]
                , "category": vm.productSelected.category
                , "cost": vm.productSelected.cost
                , "minPurchase": vm.productSelected.minPurchase
                , "description": vm.productSelected.description
                , "quantity": vm.productSelected.quantity
                , "threshold": vm.productSelected.threshold

            }

        vm.$productService.update(productSelected.productId, payload, vm.ok, _onProductError);

    };

    //....// If error during post ajax call
    function _onProductError(jqXhr, error) {
        console.log(error);

    };

    //....// Validate form - call the insert function
    function _submitForm(isValid) {
        if (isValid) {
            _update();
        }

        else {
            console.log("Form data is invalid");
        }

    };

    //....// $uibModalInstance is used to comunicate and send data back to the main controller
    //...//  Closes modal on click of submit button
    function _ok() {
        vm.$uibModalInstance.close();

    };

    //....// Close button of the modal update form
    function _cancel() {
        vm.$uibModalInstance.dismiss("cancel");

    };

})();

//})();