using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjectBlokH.Models
{
    public class ApplicationReadRepository : IApplicationRepository
    {
        SqlConnection db = new SqlConnection("Server= localhost; Database= ProjectBlokH; Integrated Security=True;");
        List<Reservation> reservations;
        public ApplicationReadRepository()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [ProjectBlokH].[dbo].[reservation] r JOIN [ProjectBlokH].[dbo].[users] u on r.userId=u.id JOIN [ProjectBlokH].[dbo].[restaurant] t ON r.restaurant = t.id";
            cmd.Connection = db;
            SqlDataReader reader;

            db.Open();
            reader = cmd.ExecuteReader();
            reservations = new List<Reservation>();
            while (reader.Read())
            {
                Reservation newItem = new Reservation();

                newItem.id = reader.GetInt32(0);
                newItem.Date = reader.GetDateTime(1);
                User u = new User();
                u.Id = reader.GetInt32(2);
                u.Name = reader.GetString(5);
                u.Password = reader.GetString(6);
                newItem.User = u;
                Restaurant t = new Restaurant();
                t.Id = reader.GetInt32(3);
                t.Name = reader.GetString(8);
                newItem.Restaurant = t;

                reservations.Add(newItem);
            }
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
            throw new NotImplementedException();
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