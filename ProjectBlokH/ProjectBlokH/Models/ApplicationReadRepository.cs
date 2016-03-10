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
        List<User> users;
        List<Restaurant> restaurants;
        public ApplicationReadRepository()
        {
            //get the reservations
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [ProjectBlokH].[dbo].[reservation]";
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
                newItem.UserId = reader.GetInt32(2);
                newItem.RestaurantId = reader.GetInt32(3);
                reservations.Add(newItem);
            }
            db.Close();
            db.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [ProjectBlokH].[dbo].[users]";
            cmd.Connection = db;
            reader = cmd.ExecuteReader();
            users = new List<User>();
            while (reader.Read())
            {
                User newItem = new User();

                newItem.Id = reader.GetInt32(0);
                newItem.Name = reader.GetString(1);
                newItem.Password = reader.GetString(2);
                users.Add(newItem);
            }
            db.Close();
            db.Open();
            cmd = new SqlCommand();
            cmd.CommandText = "SELECT * FROM [ProjectBlokH].[dbo].[restaurant]";
            cmd.Connection = db;
            reader = cmd.ExecuteReader();
            restaurants = new List<Restaurant>();
            while (reader.Read())
            {
                Restaurant newItem = new Restaurant();

                newItem.Id = reader.GetInt32(0);
                newItem.Name = reader.GetString(1);
                restaurants.Add(newItem);
            }
            db.Close();
        }
        //Security is heel slecht, maar dat vinden we bij een proof of concept app voor school niet heel belangrijk. We weten dat je passwords niet zo in de database moet zetten
        //En dat je zo alle users over internet stuurt, maar we wilden sowieso linq gebruiken dus vandaar.
        public int login(string username, string password)
        {
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
            cmd.Parameters.AddWithValue("@param2", reservation.UserId);
            cmd.Parameters.AddWithValue("@param3", reservation.RestaurantId);

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

        public IEnumerable<ReservationRestaurant> GetAllReservationsFromUser(int userId)
        {
            var selected = from reservation in reservations join restaurant in restaurants on reservation.RestaurantId equals restaurant.Id where reservation.UserId == userId select new ReservationRestaurant { reserv = reservation, rest = restaurant };
            return selected.ToList();
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