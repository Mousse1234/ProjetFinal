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
    public sealed partial class Reservation : Page
    {
        public static int idSelection = 0;
        public static string selection = "";
        public static int placeDispo = 0;
        ObservableCollection<Trajet> laListe = new ObservableCollection<Trajet>();


        public Reservation()
        {
            this.InitializeComponent();
            lvTrajetD.ItemsSource = GestionBD.getInstance().getTrajetAvenir();
            laListe = GestionBD.getInstance().getTrajetAvenir();
            GestionBD.getInstance().NValideRes = valideRes;
            GestionBD.getInstance().NRefusRes = refusRes;


        }

        private void lvTrajetD_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            idSelection = Int32.Parse(laListe[lvTrajetD.SelectedIndex].IdTrajet.ToString());
            selection = lvTrajetD.SelectedItem.ToString();

            GestionBD.getInstance().MainFrame.Navigate(typeof(PageValidation));
        }

    }
}
