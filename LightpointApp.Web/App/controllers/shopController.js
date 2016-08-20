(function () {
    'use strict';

    angular
        .module('lightpointApp')
        .controller('shopController', shopController);

    shopController.$inject = ['$scope', 'shopService'];

    function shopController($scope, shopService) {
        $scope.loading = true;
        shopService.getAll().then(function (data) {
            $scope.shops = data;
            $scope.loading = false;
        });;
    }
})();
