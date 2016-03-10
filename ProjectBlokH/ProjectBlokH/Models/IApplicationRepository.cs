using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBlokH.Models
{
    public interface IApplicationRepository
    {
        IEnumerable<Reservation> GetAllReservations();
        IEnumerable<Reservation> GetAllReservationsFromUser(int userId);
        IEnumerable<User> GetAllUsers();
        IEnumerable<Restaurant> GetAllRestaurants();

        Reservation GetReservation(int id);

        Reservation AddReservation(Reservation reservation);

        User AddUser(User user);
        User GetUser(int id);
        int login(string username, string password);

        Restaurant AddRestaurant(Restaurant restaurant);
        Restaurant GetRestaurant(int id);

        void UpdateReservation(Reservation reservation);
        void RemoveReservation(int id);

        void UpdateUser(User user);
        void RemoveUser(int id);

        void UpdateRestaurant(Restaurant restaurant);
        void RemoveRestaurant(int id);
        
    }
}