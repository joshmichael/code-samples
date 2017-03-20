/*
    
===========================================================================================

    - Main Angular product controller to load insert, edit and delete modal forms
    - Fires ajax call to get all products by company ID
    - Fires ajax call to delete products by product ID

===========================================================================================


*/

(function () {
    "use strict";

    angular.module(APPNAME).controller("productController", ProductController);

    ProductController.$inject = ["$scope", "$baseController", "$productService", "$uibModal"];

    function ProductController($scope, $baseController, $productService, $uibModal) {
        var vm = this;
        vm.items = null;
        vm.selectedProducts = null;

        vm.$productService = $productService;
        vm.$scope = $scope;

        vm.$uibModal = $uibModal;
        vm.openEditModal = _openEditModal;
        vm.openInsertModal = _openInsertModal;
        vm.openDeleteModal = _openDeleteModal;
        vm.delete = _delete;
        vm.receiveItems = _receiveItems;


        //....// - Merging the view model(vm) with the $baseController
        $baseController.merge(vm, $baseController);

        vm.notify = vm.$productService.getNotifier($scope);

        //....// - Calling the render function
        render();





        //....// - Ajax call
        function render()
        {
            vm.$productService.getByCompanyId(_receiveItems, _onProductError);
        };





        //....// - Success handler for getByCompanyId ajax call
        function _receiveItems(data)
        {
            vm.notify(function () {
                vm.items = data.items;
            });
        };





        //....// - Error handler
        function _onProductError(jqXhr, error) {
            console.log(error);

        };




        //....// - Ajax call
        function _delete(productSelected)
        {
            vm.$productService.delete(productSelected, vm.ok, _onProductError);
            render();

        };





        //....// - Load form in modal to add new product listing
        function _openInsertModal()
        {
            var modalInstance = vm.$uibModal.open
                ({
                    animation: true,
                    templateUrl: '/Scripts/app/SuppliersStorefront/Templates/productInsertModal.html',
                    controller: 'productInsertModalController as pimc',
                    resolve: {} // - anything passed to resolve can be injected into the modal controller as shown below

                });



            //....// - The Promise, code fires upon closing of the modal form
            modalInstance.result.then(function () {
                render();

            },
            function () {
                console.log('Modal dismissed at: ' + new Date());

            });
        };





        //....// - Load form in modal to edit existing product listing
        function _openEditModal(productSelected)
        {
            var modalInstance = vm.$uibModal.open
                ({
                    animation: true,
                    templateUrl: '/Scripts/app/SuppliersStorefront/Templates/productEditModal.html',
                    controller: 'productEditModalController as pemc',
                    resolve: // - anything passed to resolve can be injected into the modal controller as shown below
                        {
                            productSelected: function () {
                                return productSelected;
                            }
                        }
                });

            //....// - The Promise, code fires upon closing of the modal form
            modalInstance.result.then(function () {
                render();

            },
            function () {
                console.log('Modal dismissed at: ' + new Date());

            });
        };





        //....// - Loads product deletion confirmation modal
        function _openDeleteModal(productSelected)
        {
            var modalInstance = vm.$uibModal.open
                ({
                    animation: true,
                    templateUrl: '/Scripts/app/SuppliersStorefront/Templates/productDeleteConfirmModal.html',
                    controller: 'productDeleteModalController as pdmc',
                    resolve: // - anything passed to resolve can be injected into the modal controller as shown below
                        {
                            productSelected: function () {
                                return productSelected;
                            }
                        }
                });

            //....// - The Promise, code fires upon confirming product deletion
            modalInstance.result.then(function (productSelected) {
                vm.productSelected = productSelected;
                vm.delete(productSelected.productId);

            },
            function ()
            {
                console.log('Modal dismissed at: ' + new Date());

            });

        };

    };

}());
