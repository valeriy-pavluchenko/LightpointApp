(function() {
    'use strict';

    angular
        .module('lightpointApp')
        .directive('loadingIndicator', loadingIndicator);

    loadingIndicator.$inject = ['$window'];
    
    function loadingIndicator($window) {
        var directive = {
            link: link,
            restrict: 'E',
            templateUrl: '/App/directives/loadingIndicator.html'
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }
})();