/**
 * Created by Victor on 10-3-2016.
 */
'use strict';

/* jasmine specs for controllers go here */
describe('Reservations controllers', function($httpBackend) {

    describe('ReservationsCtrl', function(){

        beforeEach(module('reservationsApp'));
        beforeEach(module(function($provide) {
            $provide.service('loginService', function() {
                this.getLoggedIn = jasmine.createSpy('getLoggedIn').andCallFake(function() {
                    return 0;
                });
            });
        }));

//Getting reference of the mocked service
        var mockUtilSvc;

        inject(function(loginService) {
            mockUtilSvc = loginService;
        });
        it('should create "reservations" model with 3 reservations', inject(function($controller,$httpBackend,loginService) {

            $httpBackend.expect('GET',"http://localhost:59499/api/users/0/reservations").respond([
                {
                    "reserv": {
                        "id": 1,
                        "Date": "2016-03-08T12:45:34",
                        "RestaurantId": 0,
                        "UserId": 0
                    },
                    "rest": {
                        "Id": 0,
                        "Name": "Chinees"
                    }
                },
                {
                    "reserv": {
                        "id": 2,
                        "Date": "2016-03-09T12:45:34",
                        "RestaurantId": 1,
                        "UserId": 0
                    },
                    "rest": {
                        "Id": 1,
                        "Name": "Italiaan"
                    }
                },
                {
                    "reserv": {
                        "id": 3,
                        "Date": "2016-03-10T12:45:34",
                        "RestaurantId": 0,
                        "UserId": 0
                    },
                    "rest": {
                        "Id": 0,
                        "Name": "Chinees"
                    }
                }
            ]);
            var scope={},ctrl = $controller('ReservationsCtrl', {$scope:scope});
            expect(scope.reservations[0].rest.Name).toBe("Loading");
            $httpBackend.flush();
            expect(scope.reservations.length).toBe(3);
            console.log(scope);
        }));

    });
});