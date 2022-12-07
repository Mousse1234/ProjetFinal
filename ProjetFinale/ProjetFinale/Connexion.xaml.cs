﻿using Microsoft.UI.Xaml;
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

            if (Mdp.Text.Trim() == "")
            {
                verif = false;
                errMdp.Visibility = Visibility.Visible;
            }

            if (verif == true)
            {
                string a = Email.Text;
                string b = Mdp.Text;

                //retourne type de compte si le compte est existant
                listeCompte = GestionBD.getInstance().listeCompte(a,b);

                if (listeCompte.Count == 1)
                {
                    errConn.Visibility = Visibility.Collapsed;
                    //Fix update mainwindow usagerC lors de la connexion (change guest) FIX TRIM
                    MainWindow.connex = listeCompte[0].ToString();
                    MainWindow.user = Email.Text;

                    GestionBD.getInstance().TblUser.Text = "Bienvenue: " + MainWindow.user;

                    //Fix le transfer vers le mainFrame apres la connexion
                    GestionBD.getInstance().MainFrame.Navigate(typeof(Inscription));

                    if (MainWindow.connex == "admin")
                    {
                        GestionBD.getInstance().BobPannel.Visibility = Visibility.Visible;

                        GestionBD.getInstance().AlicePannel.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().PanePannel.Visibility = Visibility.Collapsed;
                    }
                    else if (MainWindow.connex == "conducteur")
                    {
                        GestionBD.getInstance().BobPannel.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().AlicePannel.Visibility = Visibility.Visible;

                        GestionBD.getInstance().PanePannel.Visibility = Visibility.Collapsed;
                    }
                    else if (MainWindow.connex == "passager")
                    {
                        GestionBD.getInstance().BobPannel.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().AlicePannel.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().PanePannel.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        GestionBD.getInstance().BobPannel.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().AlicePannel.Visibility = Visibility.Collapsed;

                        GestionBD.getInstance().PanePannel.Visibility = Visibility.Collapsed;
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
