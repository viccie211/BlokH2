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

        int AddReservation(Reservation reservation);

        User AddUser(User user);
        User GetUser(int id);
        int login(string username, string password);

        Restaurant AddRestaurant(Restaurant restaurant);
        Restaurant GetRestaurant(int id);

        bool UpdateReservation(Reservation reservation);
        void RemoveReservation(int id);

        bool UpdateUser(User user);
        void RemoveUser(int id);

        bool UpdateRestaurant(Restaurant restaurant);
        void RemoveRestaurant(int id);
        
    }
}