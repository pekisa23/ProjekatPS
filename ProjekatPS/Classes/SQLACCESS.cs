using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjekatPS.Classes
{
    class SQLACCESS
    {
        public SQLACCESS()
        {

        }


        public bool SaveZaposleni(Zaposleni zap)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=database1.db;Version=3;");
            if (sQLiteConnection.State == ConnectionState.Closed)
                sQLiteConnection.Open();

            try
            {

                String query = "insert into radnici (IME,BRFON,USERNAME,PASSWORD)values('" + zap.Ime + "','" + zap.BrojTelefona + "','" + zap.Username + "','" + zap.Password + "')";
                SQLiteCommand cmd = new SQLiteCommand(query, sQLiteConnection);
                cmd.ExecuteScalar();
                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                sQLiteConnection.Close();
            }

        }

        public bool UpdateFir()
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=database1.db;Version=3;");
            if (sQLiteConnection.State == ConnectionState.Closed)
                sQLiteConnection.Open();

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sQLiteConnection);
                cmd.CommandText = @"UPDATE poslodavci SET imefirme = @imefirme, username = @username, password = @password, imefirme = @imefirme WHERE brojfona= @brojfona";
                cmd.Parameters.AddWithValue("imefirme", GlobFir.ime);
                cmd.Parameters.AddWithValue("brojfona", GlobFir.brojTelefona);
                cmd.Parameters.AddWithValue("username", GlobFir.username);
                cmd.Parameters.AddWithValue("password", GlobFir.password);
                cmd.ExecuteNonQuery();
                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                sQLiteConnection.Close();
            }
        }

        public bool UpdateRad()
        {

            SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=database1.db;Version=3;");
            if (sQLiteConnection.State == ConnectionState.Closed)
                sQLiteConnection.Open();

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sQLiteConnection);
                cmd.CommandText = @"UPDATE radnici SET IME= @ime, username = @username, password = @password, radiZa= @radiZa WHERE BRFON = @brojfona;";
                cmd.Parameters.AddWithValue("ime", GlobZap.ime);
                cmd.Parameters.AddWithValue("brojfona", GlobZap.brojTelefona);
                cmd.Parameters.AddWithValue("username", GlobZap.username);
                cmd.Parameters.AddWithValue("password", GlobZap.password);
                cmd.Parameters.AddWithValue("radiZa", GlobZap.radiKod);
                cmd.ExecuteNonQuery();
                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                sQLiteConnection.Close();
            }

            
               
            }

        public bool UpdateRad1()
        {

            SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=database1.db;Version=3;");
            if (sQLiteConnection.State == ConnectionState.Closed)
                sQLiteConnection.Open();

            try
            {
                SQLiteCommand cmd = new SQLiteCommand(sQLiteConnection);
                cmd.CommandText = @"UPDATE radnici SET IME= @ime, username = @username, password = @password WHERE BRFON = @brojfona;";
                cmd.Parameters.AddWithValue("ime", GlobZap.ime);
                cmd.Parameters.AddWithValue("brojfona", GlobZap.brojTelefona);
                cmd.Parameters.AddWithValue("username", GlobZap.username);
                cmd.Parameters.AddWithValue("password", GlobZap.password);
                cmd.ExecuteNonQuery();
                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                sQLiteConnection.Close();
            }



        }

        public bool CheckZap()
        {
            SQLiteConnection sQLiteConnection1 = new SQLiteConnection("Data Source=database1.db;Version=3;");
            if (sQLiteConnection1.State == ConnectionState.Closed)
                sQLiteConnection1.Open();

            try
            {
                String query1 = "select count(1) from poslodavci where id=CAST (@radiZa as INTEGER)";
                SQLiteCommand cmd1 = new SQLiteCommand(query1, sQLiteConnection1);

                cmd1.CommandType = CommandType.Text;
                cmd1.Parameters.AddWithValue("radiZa", Convert.ToInt64(GlobZap.radiKod));
                int count = Convert.ToInt32(cmd1.ExecuteScalar());



                if (count == 1)
                {
                    return true;
                }
                else
                    return false;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                sQLiteConnection1.Close();
            }
        }

        public bool SaveFirme(Firme fir)
        {
            SQLiteConnection sQLiteConnection = new SQLiteConnection("Data Source=database1.db;Version=3;");
            if (sQLiteConnection.State == ConnectionState.Closed)
                sQLiteConnection.Open();

            try
            {

                String query = "insert into poslodavci (imefirme,brojfona,USERNAME,PASSWORD)values('" + fir.ImeF + "','" + fir.BrojTelefonaF + "','" + fir.UsernameF + "','" + fir.PasswordF + "')";
                SQLiteCommand cmd = new SQLiteCommand(query, sQLiteConnection);
                cmd.ExecuteScalar();
                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                sQLiteConnection.Close();
            }

        }
    }

}
