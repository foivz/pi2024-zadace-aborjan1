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
    public class MaterijalRepozitori
    {
        public static Materijal GetMaterijal(string naziv)
        {
            string sql = $"SELECT * FROM Materijal WHERE Naziv = '{naziv}'";
            return DohvatiMaterijal(sql);
        }
        private static Materijal DohvatiMaterijal(string sql)
        {
            DB.OpenConnection();
            Materijal materijal = null;
               var reader = DB.GetDataReader(sql);
            if (reader.HasRows == true)
            {
                reader.Read();
                materijal = CreateObject(reader);
                reader.Close();
            }

            DB.CloseConnection();

            return materijal;
        }
        private static Materijal CreateObject(SqlDataReader reader)
        {

            string naziv = reader["Naziv"].ToString();
            int kolicina = int.Parse(reader["Kolicina"].ToString());
            string vrsta = reader["Vrsta"].ToString();
            string datum = reader["Datum"].ToString();

            var materijal = new Materijal
            {
                Naziv = naziv,
                Kolicina = kolicina,
                Vrsta = vrsta,
                Datum = datum,

            };

            return materijal;
        }
        public bool PostojiMaterijal(string naziv)
        {
            bool exists = false;
          

            DB.OpenConnection();
            string query = "SELECT COUNT(*) FROM Materijal WHERE Naziv = @Naziv";
            using (SqlCommand command = new SqlCommand(query, DB.GetConnection()))
            {
                command.Parameters.AddWithValue("@Naziv", naziv);
                int count = (int)command.ExecuteScalar();
                exists = count > 0;
            }
        
            DB.CloseConnection();
            

            return exists;
        }

        public void UnesiMaterijal(string naziv, string kolicina, string vrsta, string datum, string entryType)
        {
            MaterijalRepozitori materijal = new MaterijalRepozitori();

            if (!decimal.TryParse(kolicina, out decimal parsedKolicina))
            {
                MessageBox.Show("Količina mora biti numerička vrijednost!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (PostojiMaterijal(naziv))
            {
             
               if(entryType == "Ulaz")
                {
                    DB.OpenConnection();
                    string sql = $"UPDATE Materijal SET Kolicina = Kolicina + @Kolicina WHERE Naziv = @Naziv";
                    using (SqlCommand updateCommand = new SqlCommand(sql, DB.GetConnection()))
                    {
                        updateCommand.Parameters.AddWithValue("@Kolicina", parsedKolicina);
                        updateCommand.Parameters.AddWithValue("@Naziv", naziv);

                        updateCommand.ExecuteNonQuery();
                    }
                    DB.CloseConnection();
                    MessageBox.Show("Količina materijala je uspješno povećana!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
               if(entryType == "Izlaz")
                {
                    DB.OpenConnection();
                    string sql = $"UPDATE Materijal SET Kolicina = Kolicina - @Kolicina,Datum = @Datum WHERE Naziv = @Naziv";
                    using (SqlCommand updateCommand = new SqlCommand(sql, DB.GetConnection()))
                    {
                        updateCommand.Parameters.AddWithValue("@Kolicina", parsedKolicina);
                        updateCommand.Parameters.AddWithValue("@Naziv", naziv);
                        updateCommand.Parameters.AddWithValue("@Datum", datum);

                        updateCommand.ExecuteNonQuery();
                    }
                    DB.CloseConnection();
                    MessageBox.Show("Količina materijala je uspješno smanjena!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }



            }
            else
            {
                DB.OpenConnection();
                string query = "INSERT INTO Materijal (Naziv, Kolicina, Vrsta, Datum) VALUES (@Naziv, @Kolicina, @Vrsta, @Datum)";
                using (SqlCommand command = new SqlCommand(query, DB.GetConnection()))
                {
                    command.Parameters.AddWithValue("@Naziv", naziv);
                    command.Parameters.AddWithValue("@Kolicina", parsedKolicina); // Parsed numeric value
                    command.Parameters.AddWithValue("@Vrsta", vrsta);
                    command.Parameters.AddWithValue("@Datum", datum); // Parsed date value


                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Materijal je uspješno evidentiran!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);



                DB.CloseConnection();
            }
        }

        public void ObrisiMaterijal(string naziv) 
        {
            DB.OpenConnection();
            string deleteQuery = "DELETE FROM Materijal WHERE Naziv = @Naziv";
            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, DB.GetConnection()))
            {
                deleteCommand.Parameters.AddWithValue("@Naziv", naziv);

                int rowsAffected = deleteCommand.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Materijal je uspješno obrisan!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Materijal s tim nazivom ne postoji!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
            }
            DB.CloseConnection();
        }

        public Materijal PretraziMaterijal(string naziv)
        {
            Materijal materijal = null;

           
                DB.OpenConnection();
                materijal = GetMaterijal(naziv);
                DB.CloseConnection();
           

            return materijal;
        }

        public static List<Materijal> GetMaterijals()
        {
            List<Materijal> materijali = new List<Materijal>();
            string sql = "SELECT * FROM Materijal";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Materijal materijal = CreateObject(reader);
                materijali.Add(materijal);
            }
            reader.Close();
            DB.CloseConnection();
            return materijali;
        }


    }
}
