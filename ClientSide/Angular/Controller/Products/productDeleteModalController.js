/*

==================================================================

    - Handles modal delete confirmation functionality

==================================================================


*/


(function () {
    "use strict";

    //....// Establishing the modal controller
    angular.module(APPNAME).controller("productDeleteModalController", ProductDeleteModalController);

    //....// Injecting (similiar to inheritance)
    ProductDeleteModalController.$inject = ["$scope", "$baseController", "$uibModalInstance", "productSelected", "$productService"];

    function ProductDeleteModalController($scope, $baseController, $uibModalInstance, productSelected, $productService)
    {

        //....// Setting view model object
        var vm = this;

        //....// Merging the view model with the $baseController
        $baseController.merge(vm, $baseController);

        //....// Making the $scope available outside the function
        vm.$scope = $scope;

        //....// Making the the bootstrap ng modal instance available outside the function
        vm.$uibModalInstance = $uibModalInstance;

        vm.$productService = $productService;
        vm.productSelected = productSelected;


        //....// $uibModalInstance is used to comunicate and send data back to the main controller
        vm.ok = function () {
            console.log(productSelected);
            vm.$uibModalInstance.close(vm.productSelected);

        };

        //....//
        vm.cancel = function () {
            vm.$uibModalInstance.dismiss("cancel");

        };

    };

})();
