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
    public sealed partial class TrajetEnCours : Page
    {
        string[] strVehicules = { "VUS", "Berline" };

        public TrajetEnCours()
        {
            this.InitializeComponent();
            cbTypeVehicule.ItemsSource = strVehicules;
            cbTypeVehicule.SelectedIndex = 0;
        }

        private void Valider_Click(object sender, RoutedEventArgs e)
        {
            if(cbTypeVehicule.SelectedIndex == 0)
            {
                tbDate.Text = "maintenant";
                tbHdepart.Text = "12h00pm";
                tbHarrivee.Text = "18h30pm";
                tbnbPlace.Text = "Le nombre de place disponible est de 5 passagers";
                tbPrix.Text = "Le prix de chaque billets est de 15$";
                Resultat.Visibility = Visibility.Visible;
            }
            else if(cbTypeVehicule.SelectedIndex == 1)
            {
                //tbDate.Text = DateTrajet;
                tbHdepart.Text = "12h00pm";
                tbHarrivee.Text = "18h30pm";
                tbnbPlace.Text = "Le nombre de place disponible est de 3 passagers";
                tbPrix.Text = "Le prix de chaque billets est de 10$";
                Resultat.Visibility = Visibility.Visible;
            }
            
        }
    }
}
