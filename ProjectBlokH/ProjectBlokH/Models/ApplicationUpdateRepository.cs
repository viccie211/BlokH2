using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectBlokH.Models
{
    public class ApplicationUpdateRepository : IApplicationRepository
    {
        private List<Reservation> reservations = new List<Reservation>();
        private List<Restaurant> restaurants = new List<Restaurant>();
        private List<User> users = new List<User>();

        public Reservation AddReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public User AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Reservation> GetAllReservations()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Reservation GetReservation(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveReservation(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateReservation(Reservation reservation)
        {
            if(reservation == null)
            {
                throw new ArgumentNullException("reservation");
            }

            int index = reservations.FindIndex(r => r.Id == reservation.)
        }

        public bool UpdateRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}