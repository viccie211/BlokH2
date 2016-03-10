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

        public ApplicationUpdateRepository()
        {

        }

        public IEnumerable<ReservationRestaurant> GetAllReservationsFromUser(int userId)
        {
            throw new NotImplementedException();
        }
        public int AddReservation(Reservation reservation)
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
            return reservations;
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return restaurants;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return users;
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

        public int login(string username, string password)
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

        public void UpdateReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException("reservation");
            }

            Reservation oldReservation = reservations.FirstOrDefault(r => r.id == reservation.id);
            oldReservation.Date = reservation.Date;
            oldReservation.RestaurantId = reservation.RestaurantId;
            oldReservation.UserId = reservation.UserId;
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            if (restaurant == null)
            {
                throw new ArgumentNullException("restaurant");
            }

            Restaurant oldRestaurant = restaurants.FirstOrDefault(r => r.Id == restaurant.Id);
            oldRestaurant.Name = restaurant.Name;
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            User oldUser = users.FirstOrDefault(u => u.Id == user.Id);
            oldUser.Name = user.Name;
            oldUser.Password = user.Password;
        }

        bool IApplicationRepository.UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        bool IApplicationRepository.UpdateRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        bool IApplicationRepository.UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}