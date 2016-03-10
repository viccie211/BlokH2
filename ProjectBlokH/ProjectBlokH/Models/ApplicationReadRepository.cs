using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProjectBlokH.Models
{
    public class ApplicationReadRepository : IApplicationRepository
    {
        SqlConnection db = new SqlConnection("Server=KOEN1\\SQLEXPRESS; Database=ProjectBlokH; Integrated Security=True;");
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
            db.Close();
        }
        // Security is heel slecht, maar dat vinden we bij een proof of concept app voor school niet heel belangrijk. 
        // We weten dat je passwords niet zo in de database moet zetten
        // En dat je zo alle users over internet stuurt, maar we wilden sowieso linq gebruiken dus vandaar.
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

        public int AddReservation(Reservation reservation)
        {
            string sql = "INSERT INTO reservation(moment,userID,restaurant) VALUES(@param1,@param2,@param3)";

            SqlCommand cmd = new SqlCommand(sql, db);
            cmd.Parameters.AddWithValue("@param1", reservation.Date);
            cmd.Parameters.AddWithValue("@param2", reservation.User.Id);
            cmd.Parameters.AddWithValue("@param3", reservation.Restaurant.Id);

            try
            {
                db.Open();
                cmd.ExecuteNonQuery();
                return 0;
            }

            catch(SqlException e)
            {
                MessageBox.Show(e.Message.ToString(), "Error Message");
                return -1;
            }
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            string sql = "INSERT INTO restaurant(name) VALUES(@param)";

            SqlCommand cmd = new SqlCommand(sql, db);
            cmd.Parameters.AddWithValue("@param", restaurant.Name);

            try
            {
                db.Open();
                cmd.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                MessageBox.Show(e.Message.ToString(), "Error Message");
            }

            return restaurant;
        }

        public User AddUser(User user)
        {
            string sql = "INSERT INTO users(username,pass) VALUES(@param1,@param2)";

            SqlCommand cmd = new SqlCommand(sql, db);
            cmd.Parameters.AddWithValue("@param1", user.Name);
            cmd.Parameters.AddWithValue("@param2", user.Password);

            try
            {
                db.Open();
                cmd.ExecuteNonQuery();
            }

            catch (SqlException e)
            {
                MessageBox.Show(e.Message.ToString(), "Error Message");
            }

            return user;
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