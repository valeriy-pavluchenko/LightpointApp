(function () {
    'use strict';

    angular
        .module('lightpointApp')
        .controller('shopController', shopController);

    shopController.$inject = ['$scope', '$location', '$routeParams', 'shopService'];

    function shopController($scope, $location, $routeParams, shopService) {
        $scope.loading = true;
        var shopId = $routeParams['id'];

        if (shopId) {
            shopService.getById(shopId).then(function (data) {
                $scope.shop = data;
                $scope.loading = false;
            });
        } else {
            shopService.getAll().then(function (data) {
                $scope.shops = data;
                $scope.loading = false;
            });
        }

        $scope.create = function () {
            if ($scope.shopForm.$valid) {
                $scope.loading = true;
                shopService.create(this.shop).then(function () {
                    $location.path('/shops');
                    $scope.loading = false;
                })
            }
        };

        $scope.edit = function () {
            if ($scope.shopForm.$valid) {
                $scope.loading = true;
                shopService.edit(this.shop).then(function () {
                    $location.path('/shops');
                    $scope.loading = false;
                })
            }
        };

        $scope.remove = function (id) {
            $scope.loading = true
            shopService.remove(id).then(function () {
                shopService.getAll().then(function (data) {
                    $scope.shops = data;
                    $scope.loading = false;
                });
            })
        }
    }
})();
