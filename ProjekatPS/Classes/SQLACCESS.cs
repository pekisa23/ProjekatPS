﻿using System;
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
                cmd.CommandText = @"UPDATE poslodavci SET brojfona= @brojfona, username = @username, password = @password WHERE imefirme = @imefirme;";
                cmd.Parameters.AddWithValue("imefirme", GlobZap.ime);
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
