(function () {
    'use strict';

    angular
        .module('lightpointApp')
        .controller('productController', productController);

    productController.$inject = ['$scope', '$routeParams', 'productService', 'shopService'];

    function productController($scope, $routeParams, productService, shopService) {
        $scope.loading = true;
        var shopId = $routeParams['id'];

        if (shopId !== 'undefined') {
            shopService.getById(shopId).then(function (data) {
                $scope.shop = data;
            }).then(productService.getByShopId(shopId).then(function (data) {
                $scope.products = data;
            })).finally(function () {
                $scope.loading = false;
            });
        }
    }
})();
