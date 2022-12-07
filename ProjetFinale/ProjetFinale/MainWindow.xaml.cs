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
        public static string connex = "invite";
        public static string user = "invite";

        public MainWindow()
        {
            this.InitializeComponent();
            Title = "rUBERt";
            usagerC.Text = "Bienvenue: " + user;
            GestionBD.getInstance().TblUser =  usagerC;
            GestionBD.getInstance().MainFrame = mainFrame;

            GestionBD.getInstance().BobPannel = adminSec;
            GestionBD.getInstance().AlicePannel = conducteurSec;
            GestionBD.getInstance().PanePannel = passagerSec;

            
                adminSec.Visibility = Visibility.Collapsed;

                conducteurSec.Visibility = Visibility.Collapsed;

                passagerSec.Visibility = Visibility.Collapsed;
            
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
                    tblHeader.Text = "Trajets";
                    //mainFrame.Navigate(typeof(Trajets));
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
