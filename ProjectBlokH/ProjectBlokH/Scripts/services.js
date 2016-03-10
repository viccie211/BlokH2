/**
 * Created by Victor on 9-3-2016.
 */
var reservationServices = angular.module('reservationServices', []);
    reservationServices.service('loginService', function() {
        var userid=-1;
        this.login = function(userId) {
            if(userid==-1)
            {
                userid=userId;
                return userId;
            }
        }
        this.getLoggedIn=function ()
        {
            return userid;
        }

    });