(function () {
    'use strict';

    angular
        .module('lightpointApp')
        .factory('shopService', shopService);

    shopService.$inject = ['$http', '$q'];

    function shopService($http, $q) {
        return {
            getAll: getAll,
            getById: getById,
            create: create,
            edit: edit,
            remove: remove
        };

        function getById(id) {
            var request = $http({
                method: "get",
                url: "api/shop/" + id,
            });

            return request.then(handleSuccess, handleError);
        }

        function getAll() {
            var request = $http({
                method: "get",
                url: "api/shop",
            });

            return request.then(handleSuccess, handleError);
        }

        function create(shop) {
            var request = $http({
                method: "post",
                url: "api/shop",
                data: shop
            });

            return request.then(handleSuccess, handleError);
        }

        function edit(shop) {
            var request = $http({
                method: "put",
                url: "api/shop",
                data: shop
            });

            return request.then(handleSuccess, handleError);
        }

        function remove(id) {
            var request = $http({
                method: "delete",
                url: "api/shop/" + id,
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