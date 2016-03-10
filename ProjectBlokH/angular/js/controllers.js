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
            $scope.reservations[0].Restaurant={};
            $scope.reservations[0].Restaurant.Name="Loading";
			
			$scope.createReservation = function() {
				$location.path('/addreservation');
			}
			
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
        else
        {
            $location.path('/login');
        }
    }
    ]);
	
reservationsControllers.controller('AddReservationsCtrl', ['$scope', '$http','$location', 'loginService',
    function($scope,$http,$location,loginService) {
        if(loginService.getLoggedIn()!=-1)
        {
			$scope.selectedRestaurant = null;
			$scope.Restaurants = [];

			$http({
				method: 'GET',
				url: 'http://localhost:59499/api/Restaurant'
			}).success(function (result) {
			$scope.Restaurants = result;
			});
			
			$scope.date = {
				value: new Date(2016, 2, 11, 19)
			};
			
            $scope.addReservation = function (date) {
                $http({
                    method: 'POST',
                    url: 'http://localhost:59499/api/Reservation',
                    data: {"Id": -2, "Date": date, "RestaurantId": 0, "UserId": loginService.getLoggedIn()}
                }).then(function successCallback(response) {
                    if (response.data != -1) {
                        $location.path('/reservations');
                    }
                }, function errorCallback(response) {
                    // called asynchronously if an error occurs
                    // or server returns response with an error status.
                });
				
            }
        }
        else {
            $location.path('/login');
        }
    }
]);
