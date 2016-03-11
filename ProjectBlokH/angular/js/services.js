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

reservationServices.service('editService', function(){
    var restaurantName = " ";
    var reserveringId = " ";
    var restaurantDate = " ";

    this.setRestaurant = function(name, id, date){
        restaurantName = name;
        reserveringId = id;
        restaurantDate = date;
    }

    this.getRestaurantName = function(){
        return restaurantName;
    }

    this.getRestaurantDate = function(){
        return restaurantDate;
    }

    this.getRestaurantId = function(){
        return reserveringId;
    }
})