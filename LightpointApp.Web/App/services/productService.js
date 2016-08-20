(function () {
    'use strict';

    angular
        .module('lightpointApp')
        .factory('productService', productService);

    productService.$inject = ['$http'];

    function productService($http) {
        return {
            getByShopId: getByShopId,
        };

        function getByShopId(shopId) {
            var request = $http({
                method: "get",
                url: "api/product/shop/" + shopId,
                isArray: true,
            });

            return request.then(handleSuccess, handleError);
        }

        function handleError(response) {
            if (!angular.isObject(response.data) || !response.data.message) {
                return $q.reject("An unknown error occurred.");
            }

            return $q.reject(response.data.message);
        }

        function handleSuccess(response) {
            return response.data;
        }
    }
})();