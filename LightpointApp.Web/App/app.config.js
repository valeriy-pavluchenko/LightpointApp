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
            .when('/shop/details/:id', {
                templateUrl: '/App/views/shop/details.html',
                controller: 'shopController'
            })
            .when('/shop/create', {
                templateUrl: '/App/views/shop/create.html',
                controller: 'shopController'
            })
            .when('/shop/edit/:id', {
                templateUrl: '/App/views/shop/edit.html',
                controller: 'shopController'
            })
            .when('/products', {
                templateUrl: '/App/views/product/list.html',
                controller: 'productController'
            })
            .when('/product/details/:id', {
                templateUrl: '/App/views/product/details.html',
                controller: 'productController'
            })
            .when('/product/create', {
                templateUrl: '/App/views/product/create.html',
                controller: 'productController'
            })
            .when('/product/edit/:id', {
                templateUrl: '/App/views/product/edit.html',
                controller: 'productController'
            })
            .when('/product/shop/:id', {
                templateUrl: '/App/views/product/listForShop.html',
                controller: 'productController'
            })
            .otherwise({
                redirectTo: '/'
            });
    }]);