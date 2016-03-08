using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBlokH.Models
{
    public interface IApplicationRepository
    {
        IEnumerable<Reservation> GetAll();
        Reservation GetReservation(int id);
        Reservation AddReservation(Reservation reservation);
        User AddUser(User user);
        User GetUser(int id);
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