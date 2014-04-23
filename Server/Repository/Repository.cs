using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using Common.Model;

namespace Server.Repository
{
    public class Repository
    {
        private static Repository instance = null;
        private const string ConnectionString = @"server=localhost;user id=root;database=biblioteca_mpp";
        private MySqlConnection conn;

        private Repository()
        {
            conn = new MySqlConnection(ConnectionString);

            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw ex;
            }

        }

        ~Repository()
        {
            try
            {
                conn.Close();
                Console.WriteLine("Connection closed");
            }
            finally
            {
                ;
            }
        }

        public static Repository getInstance()
        {
            if (instance == null)
                instance = new Repository();

            return instance;
        }

        public User getUserById(string userId)
        {
            User user = null;

            MySqlCommand cmd = new MySqlCommand("select * from abonati where IDUser=@IDUser", conn);
            cmd.Parameters.Add(new MySqlParameter("@IDUser", userId));
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                user = new User { idUser = userId, nume = rdr.GetString("Nume"), privilege = User.Privilege.User };
            }
            rdr.Close();

            return user;
        }

        public List<Book> getAllBooks()
        {
            List<Book> books = new List<Book>();

            MySqlCommand cmd = new MySqlCommand("select * from carti", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Book b = new Book();
                b.CodCarte = rdr.GetString("CodCarte");
                b.Autor = rdr.GetString("Autor");
                b.Titlu = rdr.GetString("Titlu");
                b.NrExemplare = rdr.GetInt32("NrExemplare");

                books.Add(b);
            }

            rdr.Close();

            return books;
        }
    }
}
