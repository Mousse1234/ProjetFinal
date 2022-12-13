// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutTrajet : Page
    {
        int nbrPlaceDispo;
        int nbrPlaceMax;
        public AjoutTrajet()
        {
            this.InitializeComponent();
            cbxDep.ItemsSource = GestionBD.getInstance().getVille();
            cbxArr.ItemsSource = GestionBD.getInstance().getVille();
            cbxVoiture.Items.Add("vus");
            cbxVoiture.Items.Add("berline");

            if (cbxVoiture.SelectedIndex == 0)
            {
                nbrPlaceDispo = 5;
                nbrPlaceMax = 5;
            }
            else
            {
                nbrPlaceDispo = 3;
                nbrPlaceMax = 3;
            }
        }

        private void ajoutT_Click(object sender, RoutedEventArgs e)
        {
            Trajet tr = new Trajet()
            {
                Immatriculation = tbxImm.Text,
                VilleDepart = cbxDep.SelectedItem.ToString() ,
                VilleArrivee = cbxArr.SelectedItem.ToString()
            };

            if (GestionBD.getInstance().ajoutTrajet(tr) > 0)
            {
                trajetValide.Visibility = Visibility.Visible;
                errTrajet.Visibility = Visibility.Collapsed;
            }
            else
            {
                trajetValide.Visibility = Visibility.Collapsed;
                errTrajet.Visibility = Visibility.Visible;

            }

            Voiture vo = new Voiture()
            {
                Immatriculation = tbxImm.Text,
                IdUsager = MainWindow.idUsage,
                TypeVoiture = cbxVoiture.SelectedItem.ToString(),
                //IdTrajet = 0 (se fera automatiquement et correspondera avec id trajet de Trajet() si la table voitures et trajets debute vide)
                NbrPassagerMax = nbrPlaceMax,
                NbrPassagerDispo = nbrPlaceDispo,
                SalaireBrut = 0,
                TauxRetenu = 0.1,
                SalaireNet = 0
            };

            if (GestionBD.getInstance().ajoutVoiture(vo) > 0)
            {
                trajetValide.Visibility = Visibility.Visible;
                errTrajet.Visibility = Visibility.Collapsed;
            }
            else
            {
                trajetValide.Visibility = Visibility.Collapsed;
                errTrajet.Visibility = Visibility.Visible;

            }
        }
    }
}
