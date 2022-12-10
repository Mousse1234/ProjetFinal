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

            GestionBD.getInstance().Trajets = iTrajets;
            GestionBD.getInstance().Historique = iHistorique;
            GestionBD.getInstance().Futur = iFutur;

            GestionBD.getInstance().Reserver = reserver;

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
                    //mainFrame.Navigate(typeof(Terminer));
                    break;
                case "iCouts":
                    tblHeader.Text = "Couts";
                    //mainFrame.Navigate(typeof(couts));
                    break;
                case "iTrajets":
                    tblHeader.Text = "Ajout trajet";
                    mainFrame.Navigate(typeof(AjoutTrajet));
                    break;
                case "iFutur":
                    tblHeader.Text = "Trajets a venir";
                    //mainFrame.Navigate(typeof(Futur));
                    break;
                case "iHistorique":
                    tblHeader.Text = "Historique";
                    //mainFrame.Navigate(typeof(Historique));
                    break;
                case "reserver":
                    tblHeader.Text = "Reserver un trajet";
                    //mainFrame.Navigate(typeof(Historique));
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

        
  
    }
}
