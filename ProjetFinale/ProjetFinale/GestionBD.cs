using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale
{
    internal class GestionBD
    {
        MySqlConnection con;
        static GestionBD gestionBD = null;

        public GestionBD()
        {
            this.con = new MySqlConnection("Server=localhost;Database=bdFinal;Uid=root;Pwd=root;");
        }
        public static GestionBD getInstance()
        {
            if (gestionBD == null)
                gestionBD = new GestionBD();

            return gestionBD;
        }
        public ObservableCollection<Usage> listeCompte(string a,string b)
        {
            ObservableCollection<Usage> liste = new ObservableCollection<Usage>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select typeCompte from usages where email = '" + a + "' and password = '" + b + "'";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                Usage us = new Usage()
                { 
                    TypeCompte = r.GetString("typeCompte")
                };
                liste.Add(us);
            }
            r.Close();
            con.Close();

            return liste;

        }

        public int inscription(Usage us)
        {
            string email = us.Email;
            string password = us.Password;
            string nom = us.Nom;
            string prenom = us.Prenom;
            string adresse = us.Adresse;
            string noTel = us.NoTel;
            string typeCompte = us.TypeCompte;
            int i = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand("P_inscription");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;


                commande.Parameters.AddWithValue("@newEmail", email);
                commande.Parameters.AddWithValue("@newPrenom", prenom);
                commande.Parameters.AddWithValue("@newNom", nom);
                commande.Parameters.AddWithValue("@newPassword", password);
                commande.Parameters.AddWithValue("@newAdresse", adresse);
                commande.Parameters.AddWithValue("@newNoTel", noTel);
                commande.Parameters.AddWithValue("@newTypeC", typeCompte);


                con.Open();
                commande.Prepare();
                i = commande.ExecuteNonQuery();
                con.Close();

            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();

                i = 0;
            }

            return i;
        }

    }
}
