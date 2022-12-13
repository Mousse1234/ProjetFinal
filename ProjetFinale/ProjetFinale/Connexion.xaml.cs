using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Connexion : Page
    {
       

        bool verif = true;
        ObservableCollection<Usage> listeCompte = new ObservableCollection<Usage>();
        public Connexion()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            reset();

            if (Email.Text.Trim() == "")
            {
                verif = false;
                errEmail.Visibility = Visibility.Visible;
            }

            if (Mdp.Password.Trim() == "")
            {
                verif = false;
                errMdp.Visibility = Visibility.Visible;
            }

            if (verif == true)
            {
                string a = Email.Text;
                string b = Mdp.Password;

                //retourne type de compte si le compte est existant
                listeCompte = GestionBD.getInstance().listeCompte(a,b);

                if (listeCompte.Count == 1)
                {
                    errConn.Visibility = Visibility.Collapsed;
                    //Fix update mainwindow usagerC lors de la connexion (change guest) FIX TRIM
                    MainWindow.connex = listeCompte[0].TypeCompte.ToString();
                    MainWindow.user = Email.Text;
                    MainWindow.idUsage = Int32.Parse(listeCompte[0].IdUsage.ToString());
                    MainWindow.prenomCompte = listeCompte[0].Prenom.ToString();

                    GestionBD.getInstance().TblUser.Text = "Bienvenue: " + MainWindow.prenomCompte;
                    GestionBD.getInstance().InfoCo.Visibility = Visibility.Collapsed;

                    //Fix le transfer vers le mainFrame apres la connexion
                    GestionBD.getInstance().MainFrame.Navigate(typeof(TrajetDispo));
                    GestionBD.getInstance().TblH.Text = "Trajets disponibles";

                    GestionBD.getInstance().Jconnexion.Visibility = Visibility.Collapsed; 
                    GestionBD.getInstance().Jinscription.Visibility = Visibility.Collapsed;
                    GestionBD.getInstance().Jdeconnexion.Visibility = Visibility.Visible;

                    if (MainWindow.connex == "admin")
                    {
                        GestionBD.getInstance().Encours.Visibility = Visibility.Visible;
                        GestionBD.getInstance().Termine.Visibility = Visibility.Visible;
                        GestionBD.getInstance().Couts.Visibility = Visibility.Visible;
                        GestionBD.getInstance().AjoutVille.Visibility = Visibility.Visible;

                        GestionBD.getInstance().Trajets.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().Historique.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().Futur.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().HdrAd.Visibility = Visibility.Visible;
                        GestionBD.getInstance().HdrCo.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().HdrPa.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().Reserver.Visibility = Visibility.Collapsed;
                    }
                    else if (MainWindow.connex == "conducteur")
                    {
                        GestionBD.getInstance().Encours.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().Termine.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().Couts.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().AjoutVille.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().Trajets.Visibility = Visibility.Visible;
                        GestionBD.getInstance().Historique.Visibility = Visibility.Visible;
                        GestionBD.getInstance().Futur.Visibility = Visibility.Visible;

                        GestionBD.getInstance().HdrAd.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().HdrCo.Visibility = Visibility.Visible;
                        GestionBD.getInstance().HdrPa.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().Reserver.Visibility = Visibility.Collapsed;

                    }
                    else if (MainWindow.connex == "passager")
                    {
                        GestionBD.getInstance().Encours.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().Termine.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().Couts.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().AjoutVille.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().Trajets.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().Historique.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().Futur.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().HdrAd.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().HdrCo.Visibility = Visibility.Collapsed;
                        GestionBD.getInstance().HdrPa.Visibility = Visibility.Visible;

                        GestionBD.getInstance().Reserver.Visibility = Visibility.Visible;
                        
                    }
                    else
                    {
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
                else if (listeCompte.Count == 0)
                {
                    errConn.Visibility = Visibility.Visible;
                }

                
            }
        }
        private void reset()
        {
            errEmail.Visibility = Visibility.Collapsed;
            errMdp.Visibility = Visibility.Collapsed;
        }
    }
}
