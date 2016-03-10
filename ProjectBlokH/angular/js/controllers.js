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

reservationsControllers.controller('ReservationsCtrl', ['$scope', '$http','$location', 'loginService','editService',
    function($scope,$http,$location,loginService, editService) {
        if(loginService.getLoggedIn()!=-1)
        {
            $scope.reservations=[];
            $http({
                method: 'GET',
                url: 'http://localhost:59499/api/users/' + loginService.getLoggedIn() + "/reservations",
            }).then(function successCallback(response) {
                if(response.data !=-1)
                {
                    for(var i= 0;i<response.data.length; i++)
                    {
                         var date= new Date(response.data[i].reserv.Date);
                         response.data[i].reserv.Full = response.data[i].reserv.Date;

                         var datestring=date.toLocaleDateString();
                         var time=date.toLocaleTimeString();
                         response.data[i].reserv.Date=datestring;
                         response.data[i].reserv.Time=time;
                     }
                     $scope.reservations=response.data;
                }
            }, function errorCallback(response) {
                // called asynchronously if an error occurs
                // or server returns response with an error status.
            });
            $scope.Delete = function (Id) {
                $http({
                    method: 'POST',
                    url: 'http://localhost:59499/api/reservation/'+Id,
                }).then(function successCallback(response) {
                  if(response.data !=-1)
                  {
                      for(var i= 0;i<response.data.length; i++)
                      {
                           var date= new Date(response.data[i].reserv.Date);
                           response.data[i].reserv.Full = response.data[i].reserv.Date;

                           var datestring=date.toLocaleDateString();
                           var time=date.toLocaleTimeString();
                           response.data[i].reserv.Date=datestring;
                           response.data[i].reserv.Time=time;
                       }
                  }
                }, function errorCallback(response) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.

                });;
                $scope.userId = "Loading";
            }
            $scope.reservations[0] = {};
            $scope.reservations[0].restaurant = {};
            $scope.reservations[0].restaurant.Name = "Loading";


            $scope.goEdit = function(path, name, id, date, time){

            var restaurantName = name;
            var date = date;
            var restaurantId = id;

            editService.setRestaurant(restaurantName, restaurantId, date);

            $location.path(path);

          };
        }
        else {
            $location.path('/login');
        }
    }
    ]);

reservationsControllers.controller('EditCtrl', ['$scope', '$http', '$location','loginService', 'editService',
  function($scope, $http, $location, loginService, editService){
    if(loginService.getLoggedIn()!=-1)
    {
      $http({
        method: 'GET',
        url: 'http://localhost:59499/api/users/reservations/edit'
      }).then(function successCallback(response){
        if(response.data !=-1){
            $scope.restaurants = response.data;
        }else{
          $location.path('/reservations');
        }
      },function errorCallback(response){

      });


      $scope.edit = function () {
        var date = $scope.restaurantDate;
          $http({
              method: 'POST',
              url: 'http://localhost:59499/api/users/reservations/edit',
              data: {"id": editService.getRestaurantId(), "Date": date, "RestaurantId": $scope.restaurant, "userId": loginService.getLoggedIn()}
          }).then(function successCallback(response) {
              if (response.data != -1) {
                  $location.path('/reservations');
              }
          }, function errorCallback(response) {
              // called asynchronously if an error occurs
              // or server returns response with an error status.
          });
          $scope.userId = "Loading";
      }
      $scope.restaurantDate = editService.getRestaurantDate();
    }else{
        $location.path('/login');
    }
  }]);
