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

        public List<Book> getAllBooks(bool includeUnavailable)
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

                if (includeUnavailable || b.NrExemplare > 0)
                    books.Add(b);
            }

            rdr.Close();

            return books;
        }

        public Book getBookByCode(string code)
        {
            return getBookByCode(code, null);
        }

        private Book getBookByCode(string code, MySqlTransaction transaction)
        {
            Book book = null;

            MySqlCommand cmd = new MySqlCommand("select * from carti where CodCarte=@CodCarte", conn);
            if (transaction != null)
                cmd.Transaction = transaction;
            cmd.Parameters.Add(new MySqlParameter("@CodCarte", code));
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                book = new Book();
                book.CodCarte = code;
                book.Titlu = rdr.GetString("Titlu");
                book.Autor = rdr.GetString("Autor");
                book.NrExemplare = rdr.GetInt32("NrExemplare");
            }
            rdr.Close();

            return book;
        }

        public List<Book> makeBorrowing(string userID, List<Book> books)
        {
            List<Book> booksNotBorrowable = new List<Book>();
            MySqlTransaction transaction = conn.BeginTransaction();

            foreach (Book book in books)
            {
                if (getBookByCode(book.CodCarte).NrExemplare <= 0)
                {
                    booksNotBorrowable.Add(book);
                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("insert into imprumuturi values (@IDUser,@CodCarte)", conn, transaction);
                    cmd.Parameters.Add(new MySqlParameter("@CodCarte", book.CodCarte));
                    cmd.Parameters.Add(new MySqlParameter("@IDUser", userID));

                    try
                    {
                        cmd.ExecuteNonQuery();

                        cmd = new MySqlCommand("update carti set NrExemplare=NrExemplare-1 where CodCarte=@CodCarte", conn, transaction);
                        cmd.Parameters.Add(new MySqlParameter("@CodCarte", book.CodCarte));
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        booksNotBorrowable.Add(book);
                    }
                }
            }

            if (booksNotBorrowable.Count > 0)
            {
                transaction.Rollback();
            }
            else
            {
                transaction.Commit();
            }

            return booksNotBorrowable;
        }

        public bool addOrUpdateBook(Book book)
        {
            MySqlCommand cmd = null;
            if (getBookByCode(book.CodCarte) == null) // new book
            {
                cmd = new MySqlCommand("insert into carti values (@CodCarte, @Titlu, @Autor, @NrExemplare)", conn);
            }
            else // update existing
            {
                cmd = new MySqlCommand("update carti set Titlu=@Titlu, Autor=@Autor, NrExemplare=@NrExemplare where CodCarte=@CodCarte", conn);
            }

            cmd.Parameters.Add(new MySqlParameter("@CodCarte", book.CodCarte));
            cmd.Parameters.Add(new MySqlParameter("@Titlu", book.Titlu));
            cmd.Parameters.Add(new MySqlParameter("@Autor", book.Autor));
            cmd.Parameters.Add(new MySqlParameter("@NrExemplare", book.NrExemplare));

            try
            {                
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool deleteBook(string bookCode)
        {
            MySqlCommand cmd = new MySqlCommand("delete from carti where CodCarte=@CodCarte", conn);
            cmd.Parameters.Add(new MySqlParameter("@CodCarte", bookCode));

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public List<Borrowing> getBorrowings()
        {
            List<Borrowing> borrowings = new List<Borrowing>();

            MySqlCommand cmd = new MySqlCommand("select * from imprumuturi", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Borrowing b = new Borrowing();
                b.CodCarte = rdr.GetString("CodCarte");
                b.IDUser = rdr.GetString("IDUser");

                borrowings.Add(b);
            }

            rdr.Close();

            return borrowings;
        }
    }
}
