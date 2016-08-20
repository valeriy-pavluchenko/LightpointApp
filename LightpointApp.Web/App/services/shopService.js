(function () {
    'use strict';

    angular
        .module('lightpointApp')
        .factory('shopService', shopService);

    shopService.$inject = ['$http'];

    function shopService($http) {
        return {
            getAll: getAll,
            getById: getById
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