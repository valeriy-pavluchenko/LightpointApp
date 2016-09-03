(function () {
    'use strict';

    angular
        .module('lightpointApp')
        .factory('productService', productService);

    productService.$inject = ['$http', '$q'];

    function productService($http, $q) {
        return {
            getAll: getAll,
            getByShopId: getByShopId,
            getById: getById,
            create: create,
            edit: edit,
            remove: remove
        };

        function getById(id) {
            var request = $http({
                method: "get",
                url: "api/product/" + id,
            });

            return request.then(handleSuccess, handleError);
        }

        function getByShopId(shopId) {
            var request = $http({
                method: "get",
                url: "api/product/shop/" + shopId,
                isArray: true,
            });

            return request.then(handleSuccess, handleError);
        }

        function getAll() {
            var request = $http({
                method: "get",
                url: "api/product",
            });

            return request.then(handleSuccess, handleError);
        }

        function create(product) {
            var request = $http({
                method: "post",
                url: "api/product",
                data: product
            });

            return request.then(handleSuccess, handleError);
        }

        function edit(product) {
            var request = $http({
                method: "put",
                url: "api/product",
                data: product
            });

            return request.then(handleSuccess, handleError);
        }

        function remove(id) {
            var request = $http({
                method: "delete",
                url: "api/product/" + id,
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