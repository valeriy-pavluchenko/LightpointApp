(function () {
    'use strict';

    angular
        .module('lightpointApp')
        .controller('productController', productController);

    productController.$inject = ['$scope', '$routeParams', '$location', 'productService', 'shopService'];

    function productController($scope, $routeParams, $location, productService, shopService) {
        $scope.loading = true;

        if ($location.path().includes('/product/shop')) {
            var shopId = $routeParams['id'];

            if (shopId) {
                shopService.getById(shopId).then(function (data) {
                    $scope.shop = data;
                }).then(productService.getByShopId(shopId).then(function (data) {
                    $scope.products = data;
                }));
            }
        } else {
            var productId = $routeParams['id'];

            if (productId) {
                productService.getById(productId).then(function (data) {
                    $scope.product = data;
                });
            } else {
                productService.getAll().then(function (data) {
                    $scope.products = data;
                });
            }
        }

        shopService.getAll().then(function (data) {
            $scope.shops = data;
            $scope.loading = false;
        });

        $scope.create = function () {
            if ($scope.productForm.$valid) {
                $scope.loading = true;
                productService.create(this.product).then(function () {
                    $location.path('/products');
                    $scope.loading = false;
                })
            }
        };

        $scope.edit = function () {
            if ($scope.productForm.$valid) {
                $scope.loading = true;
                productService.edit(this.product).then(function () {
                    $location.path('/products');
                    $scope.loading = false;
                })
            }
        };

        $scope.remove = function (id) {
            $scope.loading = true
            var shopId = $routeParams['id'];

            if ($location.path().includes('/product/shop')) {
                productService.remove(id).then(function () {
                    productService.getByShopId(shopId).then(function (data) {
                        $scope.products = data;
                        $scope.loading = false;
                    });
                })
            } else {
                productService.remove(id).then(function () {
                    productService.getAll().then(function (data) {
                        $scope.products = data;
                        $scope.loading = false;
                    });
                })
            }
        }
    }
})();
