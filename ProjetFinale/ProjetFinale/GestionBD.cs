using Microsoft.UI.Xaml.Controls;
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

        TextBlock tblUser;
        TextBlock infoCo;
        Frame mainFrame;
        NavigationViewItemHeader hdrAd;
        NavigationViewItemHeader hdrCo;
        NavigationViewItemHeader hdrPa;
        NavigationViewItem encours;
        NavigationViewItem termine;
        NavigationViewItem couts;
        NavigationViewItem trajets;
        NavigationViewItem historique;
        NavigationViewItem futur;
        NavigationViewItem reserver;
        TextBlock tblH;
        AppBarButton jconnexion;
        AppBarButton jdeconnexion;
        AppBarButton jinscription;

        public TextBlock TblUser { get => tblUser; set => tblUser = value; }
        public Frame MainFrame { get => mainFrame; set => mainFrame = value; }
        public TextBlock TblH { get => tblH; set => tblH = value; }
        public NavigationViewItemHeader HdrAd { get => hdrAd; set => hdrAd = value; }
        public NavigationViewItemHeader HdrCo { get => hdrCo; set => hdrCo = value; }
        public NavigationViewItemHeader HdrPa { get => hdrPa; set => hdrPa = value; }
        public NavigationViewItem Encours { get => encours; set => encours = value; }
        public NavigationViewItem Termine { get => termine; set => termine = value; }
        public NavigationViewItem Couts { get => couts; set => couts = value; }
        public NavigationViewItem Trajets { get => trajets; set => trajets = value; }
        public NavigationViewItem Historique { get => historique; set => historique = value; }
        public NavigationViewItem Futur { get => futur; set => futur = value; }
        public NavigationViewItem Reserver { get => reserver; set => reserver = value; }
        public TextBlock InfoCo { get => infoCo; set => infoCo = value; }
        public AppBarButton Jconnexion { get => jconnexion; set => jconnexion = value; }
        public AppBarButton Jdeconnexion { get => jdeconnexion; set => jdeconnexion = value; }
        public AppBarButton Jinscription { get => jinscription; set => jinscription = value; }

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
            commande.CommandText = "Select typeCompte,idUsage,prenom from usages where email = '" + a + "' and password = '" + b + "'";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                Usage us = new Usage()
                {
                    TypeCompte = r.GetString("typeCompte"),
                    IdUsage = r.GetInt32("idUsage"),
                    Prenom = r.GetString("prenom")
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

        public ObservableCollection<Trajet> getTrajet()
        {
            ObservableCollection<Trajet> liste = new ObservableCollection<Trajet>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from trajets where status = 'encours'";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                Trajet tr = new Trajet()
                {
                    IdTrajet = r.GetInt32("idTrajet"),
                    Immatriculation = r.GetString("immatriculation"),
                    IdUsage = r.GetInt32("idUsage"),
                    VilleDepart = r.GetString("villeDepart"),
                    VilleArrivee = r.GetString("villeArrivee"),
                    NbrArret = r.GetInt32("nbrArret"),
                    Status = r.GetString("status"),
                };
                liste.Add(tr);
            }
            r.Close();
            con.Close();

            return liste;

        }

        public ObservableCollection<Trajet> getTrajetTerminer()
        {
            ObservableCollection<Trajet> liste = new ObservableCollection<Trajet>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from trajets where status = 'terminer'";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                Trajet tr = new Trajet()
                {
                    IdTrajet = r.GetInt32("idTrajet"),
                    Immatriculation = r.GetString("immatriculation"),
                    IdUsage = r.GetInt32("idUsage"),
                    VilleDepart = r.GetString("villeDepart"),
                    VilleArrivee = r.GetString("villeArrivee"),
                    NbrArret = r.GetInt32("nbrArret"),
                    Status = r.GetString("status"),
                };
                liste.Add(tr);
            }
            r.Close();
            con.Close();

            return liste;

        }

        public ObservableCollection<Ville> getVille()
        {
            ObservableCollection<Ville> liste = new ObservableCollection<Ville>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select nomVille from ville";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                Ville vi = new Ville()
                {
                    NomVille = r.GetString("nomVille")
                };
                liste.Add(vi);
            }
            r.Close();
            con.Close();

            return liste;
        }

        public int ajoutTrajet(Trajet tr)
        {
            string immatriculation = tr.Immatriculation;
            int idUsage = MainWindow.idUsage;
            string villeDepart = tr.VilleDepart;
            string villeArrivee = tr.VilleArrivee;
            string status = "avenir";
            int i = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand("P_ajout_trajet");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;


                commande.Parameters.AddWithValue("@newImma", immatriculation);
                commande.Parameters.AddWithValue("@newIdUsage", idUsage);
                commande.Parameters.AddWithValue("@newVilleD", villeDepart);
                commande.Parameters.AddWithValue("@newVilleA", villeArrivee);
                commande.Parameters.AddWithValue("@newStatus", status);


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

        public ObservableCollection<Trajet> getTrajHist(String leStatus)
        {
            ObservableCollection<Trajet> liste = new ObservableCollection<Trajet>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select * from trajets where status = '" + leStatus + "' and idUsage = " + MainWindow.idUsage;

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                Trajet tr = new Trajet()
                {
                    IdTrajet = r.GetInt32("idTrajet"),
                    Immatriculation = r.GetString("immatriculation"),
                    IdUsage = r.GetInt32("idUsage"),
                    VilleDepart = r.GetString("villeDepart"),
                    VilleArrivee = r.GetString("villeArrivee"),
                    NbrArret = r.GetInt32("nbrArret"),
                    Status = r.GetString("status"),
                };
                liste.Add(tr);
            }
            r.Close();
            con.Close();

            return liste;

        }

        public ObservableCollection<Voiture> getVoiture()
        {
            ObservableCollection<Voiture> liste = new ObservableCollection<Voiture>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select salaireBrut, tauxRetenu from voitures where idUsager = (Select idUsage from usages where typeCompte = 'conducteur') ";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                Voiture vo = new Voiture()
                {
                    SalaireBrut = r.GetDouble("salaireBrut"),
                    TauxRetenu = r.GetDouble("tauxRetenu")
                };
                liste.Add(vo);
            }
            r.Close();
            con.Close();

            return liste;
        }

        public ObservableCollection<Usage> getNom()
        {
            ObservableCollection<Usage> liste = new ObservableCollection<Usage>();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "Select prenom, nom from usages where status = 'conducteur'";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();
            while (r.Read())
            {

                Usage us  = new Usage()
                {
                    Prenom = r.GetString("prenom"),
                    Nom = r.GetString("nom"),
                };
                liste.Add(us);
            }
            r.Close();
            con.Close();

            return liste;
        }

        public int addVille(Ville v)
        {
            int retour = 0;

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "insert into ville values (@ville)";

            commande.Parameters.AddWithValue("@ville", v.NomVille);

            con.Open();
            commande.Prepare();
            retour = commande.ExecuteNonQuery();

            con.Close();

            return retour;
        }

        public int ajoutVoiture(Voiture vo)
        {
            string immatriculation = vo.Immatriculation;
            int idUsage = MainWindow.idUsage;
            string typeVoiture = vo.TypeVoiture;
            int nbrPassagerMax = vo.NbrPassagerMax;
            int nbrPassagerDispo = vo.NbrPassagerDispo;
            double salaireBrut = vo.SalaireBrut;
            double salaireNet = (salaireBrut - (salaireBrut*0.1));
            int i = 0;

            try
            {
                MySqlCommand commande = new MySqlCommand("p_ajout_voiture");
                commande.Connection = con;
                commande.CommandType = System.Data.CommandType.StoredProcedure;


                commande.Parameters.AddWithValue("@newImma", immatriculation);
                commande.Parameters.AddWithValue("@newIdUsage", idUsage);
                commande.Parameters.AddWithValue("@newTypeVoiture", typeVoiture);
                commande.Parameters.AddWithValue("@newNbrPassagerMax", nbrPassagerMax);
                commande.Parameters.AddWithValue("@newNbrPassagerDispo", nbrPassagerDispo);
                commande.Parameters.AddWithValue("@newSalaireBrut", salaireBrut);
                commande.Parameters.AddWithValue("@newSalaireNet", salaireNet);


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
