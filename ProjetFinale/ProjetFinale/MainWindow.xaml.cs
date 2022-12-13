using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinale
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        // VARIABLE DU COMPTE CONNECTÉ
        // connex = typeCompte (admin,conducteur,passager)
        public static string connex = "invite";
        // user = email
        public static string user = "invite";
        // idUsage = ID
        public static int idUsage = 0;
        // prenomCompte = prenom du detentaire du compte
        public static string prenomCompte = "invite";

        public MainWindow()
        {
            this.InitializeComponent();
            Title = "rUBERt";
            usagerC.Text = "Bienvenue: " + prenomCompte;
            GestionBD.getInstance().TblUser =  usagerC;
            GestionBD.getInstance().MainFrame = mainFrame;
            GestionBD.getInstance().TblH = tblHeader;

            GestionBD.getInstance().HdrAd = hdrA;
            GestionBD.getInstance().HdrCo = hdrC;
            GestionBD.getInstance().HdrPa = hdrP;

            GestionBD.getInstance().Encours = iEncours;
            GestionBD.getInstance().Termine = iTerminer;
            GestionBD.getInstance().Couts = iCouts;
            GestionBD.getInstance().AjoutVille = iAjoutVille;

            GestionBD.getInstance().Trajets = iTrajets;
            GestionBD.getInstance().Historique = iHistorique;
            GestionBD.getInstance().Futur = iFutur;

            GestionBD.getInstance().Reserver = reserver;

            GestionBD.getInstance().Jconnexion = connexion;
            GestionBD.getInstance().Jdeconnexion = deconnexion;
            GestionBD.getInstance().Jinscription = inscription;


            GestionBD.getInstance().Encours.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().Termine.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().Couts.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().AjoutVille.Visibility = Visibility.Collapsed;

            GestionBD.getInstance().Trajets.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().Historique.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().Futur.Visibility = Visibility.Collapsed;

            GestionBD.getInstance().HdrAd.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().HdrCo.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().HdrPa.Visibility = Visibility.Collapsed;

            GestionBD.getInstance().Reserver.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().InfoCo = infoCo;


            mainFrame.Navigate(typeof(TrajetDispo));
            tblHeader.Text = "Trajets à venir";
            
        }
        private void iRecherche_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "iEncours":
                    tblHeader.Text = "Trajet en cours";
                    mainFrame.Navigate(typeof(TrajetEnCours));
                    break;
                case "iTerminer":
                    tblHeader.Text = "Trajets termine";
                    mainFrame.Navigate(typeof(TrajetTerminer));
                    break;
                case "iCouts":
                    tblHeader.Text = "Couts";
                    mainFrame.Navigate(typeof(Couts));
                    break;
                case "iTrajets":
                    tblHeader.Text = "Ajout trajet";
                    mainFrame.Navigate(typeof(AjoutTrajet));
                    break;
                case "iFutur":
                    tblHeader.Text = "Trajets a venir";
                    mainFrame.Navigate(typeof(TrajetAvenir));
                    break;
                case "iHistorique":
                    tblHeader.Text = "Mon historique";
                    mainFrame.Navigate(typeof(MonHistorique));
                    break;
                case "reserver":
                    tblHeader.Text = "Reserver un trajet";
                    mainFrame.Navigate(typeof(Reservation));
                    break;
                case "iAjoutVille":
                    tblHeader.Text = "Ajouter une ville";
                    mainFrame.Navigate(typeof(AjoutVille));
                    break;
            }
        }

        private void inscription_Click(object sender, RoutedEventArgs e)
        {
            tblHeader.Text = "Inscription";
            mainFrame.Navigate(typeof(Inscription));
        }

        private void connexion_Click(object sender, RoutedEventArgs e)
        {
            tblHeader.Text = "Connexion";
            mainFrame.Navigate(typeof(Connexion));
        }

        private void deconnexion_Click(object sender, RoutedEventArgs e)
        {
            connex = "invite";
            user = "invite";
            idUsage = 0;
            prenomCompte = "invite";
            mainFrame.Navigate(typeof(TrajetDispo));
            tblHeader.Text = "Trajets disponibles";

            GestionBD.getInstance().TblUser.Text = "Bienvenue: " + prenomCompte;

            connexion.Visibility = Visibility.Visible;
            inscription.Visibility = Visibility.Visible;
            deconnexion.Visibility = Visibility.Collapsed;

            GestionBD.getInstance().Encours.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().Termine.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().Couts.Visibility = Visibility.Collapsed;

            GestionBD.getInstance().Trajets.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().Historique.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().Futur.Visibility = Visibility.Collapsed;

            GestionBD.getInstance().HdrAd.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().HdrCo.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().HdrPa.Visibility = Visibility.Collapsed;

            GestionBD.getInstance().Reserver.Visibility = Visibility.Collapsed;
        }
    }
}
