'use strict';

/* Controllers */

var reservationsControllers = angular.module('reservationsControllers', []);

reservationsControllers.controller('LoginCtrl', ['$scope', '$http', '$location', 'loginService',
    function ($scope, $http, $location, loginService) {
        if (loginService.getLoggedIn() < 0) {
            $scope.userId = -2;
            $scope.login = function () {
                $http({
                    method: 'POST',
                    url: 'http://localhost:59499/api/Login',
                    data: { "Id": -2, "Name": $scope.username, "password": $scope.password }
                }).then(function successCallback(response) {
                    if (response.data != -1) {
                        loginService.login(response.data);
                        $location.path('/reservations');
                    }
                }, function errorCallback(response) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                });
                $scope.userId = "Loading";
            }
        }
        else {
            $location.path('/reservations');
        }
    }
]);

reservationsControllers.controller('ReservationsCtrl', ['$scope', '$http', '$location', 'loginService',
    function ($scope, $http, $location, loginService) {
        if (loginService.getLoggedIn() != -1) {
            $scope.reservations = [];
            $http({
                method: 'GET',
                url: 'http://localhost:59499/api/users/' + loginService.getLoggedIn() + "/reservations",
            }).then(function successCallback(response) {
                if(response.data !=-1)
                {
                    for(var i= 0;i<response.data.length; i++)
                    {
                        var datetemp =new Date(response.data[i].reserv.Date);
                        var datestring=datetemp.toLocaleDateString();
                        var time=datetemp.toLocaleTimeString();
                        response.data[i].reserv.DateShow=datestring;
                        response.data[i].reserv.Time=time;
                    }
                    $scope.reservations = response.data;
                }
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
                // or server returns response with an error status.
            });
            $scope.reservations[0]={};
            $scope.reservations[0].rest={};
            $scope.reservations[0].rest.Name="Loading";

            $scope.Delete = function (Id) {
                $http({
                    method: 'POST',
                    url: 'http://localhost:59499/api/reservation/'+Id,
                }).then(function successCallback(response) {
                    $scope.reservations = [];
                    $http({
                        method: 'GET',
                        url: 'http://localhost:59499/api/users/' + loginService.getLoggedIn() + "/reservations",
                    }).then(function successCallback(response) {
                        if (response.data != -1) {
                            for (var i = 0; i < response.data.length; i++) {
                                Date = new Date(response.data[i].reserv.Date);
                                var datestring = Date.toLocaleDateString();
                                var time = Date.toLocaleTimeString();
                                response.data[i].reserv.Date = datestring;
                                response.data[i].reserv.Time = time;
                            }
                            $scope.reservations = response.data;
                        }
                    }, function errorCallback(response) {
                        // called asynchronously if an error occurs
                        // or server returns response with an error status.
                    });
                }, function errorCallback(response) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                    
                });;
                $scope.userId = "Loading";
            }
            $scope.reservations[0] = {};
            $scope.reservations[0].restaurant = {};
            $scope.reservations[0].restaurant.Name = "Loading";
        }
        else {
            $location.path('/login');
        }
    }
]);
