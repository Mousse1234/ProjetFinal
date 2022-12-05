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

     public MainWindow()
        {
            this.InitializeComponent();
        }
        private void iRecherche_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {

        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            var item = (NavigationViewItem)args.SelectedItem;

            switch (item.Name)
            {
                case "iVilles":
                    tblHeader.Name = "Ajout ville";
                    mainFrame.Navigate(typeof(villes));
                    break;
                case "iEncours":
                    tblHeader.Name = "Trajet en cours";
                    mainFrame.Navigate(typeof(Encours));
                    break;
                case "iTerminer":
                    tblHeader.Name = "Trajets termine";
                    mainFrame.Navigate(typeof(Terminer));
                    break;
                case "iCouts":
                    tblHeader.Name = "Couts";
                    mainFrame.Navigate(typeof(couts));
                    break;
            }
        }

        private void inscription_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Inscription));
        }

        private void connexion_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Connexion));
        }
    }
}
