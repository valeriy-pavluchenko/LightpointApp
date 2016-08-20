angular.
    module('lightpointApp')
    .config(['$routeProvider', function config($routeProvider) {
        $routeProvider
            .when('/', {
                templateUrl: '/App/views/home/index.html',
            })
            .when('/shops', {
                templateUrl: '/App/views/shop/list.html',
                controller: 'shopController'
            })
            .when('/product/shop/:id', {
                templateUrl: '/App/views/product/list.html',
                controller: 'productController'
            })
            .otherwise({
                redirectTo: '/'
            });
    }]);