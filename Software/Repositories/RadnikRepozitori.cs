using DBLayer;
using RecycloSmart.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecycloSmart.Repositories
{
    public class RadnikRepozitori
    {
        public static Radnik GetRadnik(string password)
        {


            string sql = $"SELECT * FROM Radnik WHERE Lozinka = '{password}'";
            return DohvatiRadnika(sql);
        }
        private static Radnik DohvatiRadnika(string sql)
        {
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            Radnik radnik = null;

            if (reader.HasRows == true)
            {
                reader.Read();
                radnik = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();

            return radnik;
        }
        private static Radnik CreateObject(SqlDataReader reader)
        {
          
            string username = reader["KorisnickoIme"].ToString();
            string password = reader["Lozinka"].ToString();
            

            var radnik = new Radnik
            {
                KorisnickoIme = username,
                Lozinka = password,
              
            };

            return radnik;
        }

        public void AddRadnik(Radnik noviRadnik)
        {
            DB.OpenConnection();
               
            string sql = "INSERT INTO Radnik (KorisnickoIme, Lozinka) OUTPUT INSERTED.Id VALUES (@KorisnickoIme, @Lozinka)";
            using (SqlCommand command = new SqlCommand(sql, DB.GetConnection()))
             {
                 command.Parameters.AddWithValue("@KorisnickoIme", noviRadnik.KorisnickoIme);
                 command.Parameters.AddWithValue("@Lozinka", noviRadnik.Lozinka);

                 noviRadnik.Id = (int)command.ExecuteScalar();

             } 


            DB.CloseConnection();
          
        }
    }
}
