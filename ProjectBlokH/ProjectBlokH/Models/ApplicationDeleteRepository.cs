using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjectBlokH.Models
{
    public class ApplicationDeleteRepository
        : IApplicationRepository
    {
        SqlConnection db = new SqlConnection("Server= MITCHEL\\SERVERSCHOOLSQL; Database= ProjectBlokH; Integrated Security=True;");

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

        public IEnumerable<ReservationRestaurant> GetAllReservationsFromUser(int userId)
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

        public int login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void RemoveReservation(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Reservation WHERE Id='" + id + "'";
            cmd.Connection = db;

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();
        }

        public void RemoveRestaurant(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM Restaurant WHERE Id='" + id + "'";
            cmd.Connection = db;

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();
        }

        public void RemoveUser(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DELETE FROM User WHERE Id='" + id + "'";
            cmd.Connection = db;

            db.Open();
            cmd.ExecuteNonQuery();
            db.Close();
        }

        public void UpdateReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}