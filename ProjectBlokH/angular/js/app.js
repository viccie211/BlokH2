 
/* App Module */

var reservationsApp = angular.module('reservationsApp', [
  'ngRoute',
  'reservationsControllers',
  'reservationServices'
]);

reservationsApp.config(['$routeProvider',
  function($routeProvider) {
        $routeProvider.
			when('/login', {
                templateUrl: 'partials/login.html',
                controller: 'LoginCtrl'
              }).
            when('/reservations', {
                templateUrl: 'partials/reservations.html',
                controller: 'ReservationsCtrl'
            }).
			when('/addreservation', {
                templateUrl: 'partials/addReservation.html',
                controller: 'AddReservationsCtrl'
			}).
            when('/edit', {
                templateUrl: 'partials/updateReservation.html',
                controller: 'EditCtrl'
            }).
            when('/weather', {
              templateUrl: 'partials/weather.html',
              controller: 'WeatherCtrl'
            }).
			otherwise({
                redirectTo: '/login'
            });
  }]);
