﻿'use strict';

/* Controllers */

var reservationsControllers = angular.module('reservationsControllers', []);

reservationsControllers.controller('LoginCtrl', ['$scope', '$http','$location', 'loginService',
    function($scope,$http,$location,loginService){
        if(loginService.getLoggedIn()<0) {
            $scope.userId = -2;
            $scope.login = function () {
                $http({
                    method: 'POST',
                    url: 'http://localhost:59499/api/Login',
                    data: {"Id": -2, "Name": $scope.username, "password": $scope.password}
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

reservationsControllers.controller('ReservationsCtrl', ['$scope', '$http','$location', 'loginService',
    function($scope,$http,$location,loginService) {
        if(loginService.getLoggedIn()!=-1)
        {
            $scope.reservations=[];
            $http({
                method: 'GET',
                url: 'http://localhost:59499/api/users/'+loginService.getLoggedIn()+"/reservations",
            }).then(function successCallback(response) {
                if(response.data !=-1)
                {
                    $scope.reservations=response.data;
                }
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
            $scope.reservations[0]={};
            $scope.reservations[0].Restaurant={};
            $scope.reservations[0].Restaurant.Name="Loading";
        }
        else
        {
            $location.path('/login');
        }
    }
    ]);