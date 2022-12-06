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

    }
}
