using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace ProjectBlokH.Models
{
    public class ApplicationReadRepository : IApplicationRepository
    {
        SqlConnection db = new SqlConnection("Server= DESKTOP-SKEMNB8\\SQLEXPRESS; Database= ProjectBlokH; Integrated Security=True;");
        List<Reservation> reservations;
        List<User> users;

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
            db.Close();
        }
        //Security is heel slecht, maar dat vinden we bij een proof of concept app voor school niet heel belangrijk. We weten dat je passwords niet zo in de database moet zetten
        //En dat je zo alle users over internet stuurt, maar we wilden sowieso linq gebruiken dus vandaar.
        public int login(string username, string password)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [ProjectBlokH].[dbo].[users] u";
            cmd.Connection = db;
            SqlDataReader reader;

            db.Open();
            reader = cmd.ExecuteReader();
            List<User>users = new List<User>();
            while (reader.Read())
            {
                User newItem = new User();
                newItem.Id = reader.GetInt32(0);
                newItem.Name = reader.GetString(1);
                newItem.Password = reader.GetString(2);

                users.Add(newItem);
            }
            db.Close();
            List<int> loggedInUsers = users.Where(user => user.Name.Equals(username)).Where(user => user.Password.Equals(password)).Select(user=>user.Id).ToList();
            if(loggedInUsers.Count()>0)
            {
                return loggedInUsers[0];
            }
            else
            {
                return -1;
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

        public IEnumerable<Reservation> GetAllReservationsFromUser(int userId)
        {
            List<Reservation> selected = reservations.Where(reservation => reservation.User.Id == userId).ToList();
            return selected;
        }
        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAllUsers()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [ProjectBlokH].[dbo].[users] u;";
            cmd.Connection = db;
            SqlDataReader reader;

            db.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                User newItem = new User();
                newItem.Id = reader.GetInt32(0);
                newItem.Name = reader.GetString(1);
                newItem.Password = reader.GetString(2);

                users.Add(newItem);
            }
            db.Close();

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
            User user = users.Find(y => y.Id == id);

            return user;
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