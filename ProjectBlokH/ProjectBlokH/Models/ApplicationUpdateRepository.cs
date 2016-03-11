using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectBlokH.Models
{
    public class ApplicationUpdateRepository : IApplicationRepository
    {
        private IEnumerable<Reservation> reservations = new List<Reservation>();
        private List<Restaurant> restaurants = new List<Restaurant>();
        private List<User> users = new List<User>();

        public ApplicationUpdateRepository()
        {
            ApplicationReadRepository db = new ApplicationReadRepository();
            reservations = db.GetAllReservations();
        }

        public IEnumerable<ReservationRestaurant> GetAllReservationsFromUser(int userId)
        {
            throw new NotImplementedException();
        }
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

            update(oldReservation);

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

        private void update(Reservation reservation)
        {
            SqlConnection conn = new SqlConnection("Server= localhost; Database= ProjectBlokH; Integrated Security=True;");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.Open();
            cmd.CommandText = "UPDATE [ProjectBlokH].[dbo].[reservation] SET moment ='" + reservation.Date + "',restaurant=" + reservation.RestaurantId + ", userId=" + reservation.UserId + "WHERE id =" + reservation.id + ";";
            int i = 1;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        IEnumerable<ReservationRestaurant> IApplicationRepository.GetAllReservationsFromUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}