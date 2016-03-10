'use strict';

/* App Module */		 /* App Module */

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
            when('/edit', {
                templateUrl: 'partials/updateReservation.html',
                controller: 'EditCtrl'
            }).
			otherwise({
                redirectTo: '/login'
            });
  }]);
