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
      var restaurantId = " ";
      var restaurantMoment = " ";

      this.setRestaurant = function(name, id, moment){
        restaurantName = name;
        restaurantId = id;
        restaurantMoment = moment;
      }

      this.getRestaurantName = function(){
        return restaurantName;
      }

      this.getRestaurantMoment = function(){
        return restaurantMoment;
      }

      this.getRestaurantId = function(){
        return restaurantId;
      }
    })
