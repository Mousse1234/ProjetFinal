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
    public sealed partial class Menu : Page
    {
        public Menu()
        {
            this.InitializeComponent();
        }
        private void iRecherche_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            ContentDialog dialog = new ContentDialog();
            dialog.Title = "Test";
            dialog.CloseButtonText = "OK";
            dialog.Content = iRecherche.Text;

            dialog.ShowAsync();

        }


        private void iVilles_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.mainFrame.Navigate(typeof(villes));
        }

        private void iEncours_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.mainFrame.Navigate(typeof(Encours));
        }

        private void iTerminer_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.mainFrame.Navigate(typeof(Terminer));
        }

        private void iCouts_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.mainFrame.Navigate(typeof(couts));
        }

        private void iTrajets_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.mainFrame.Navigate(typeof(Trajets));
        }

        private void iHistorique_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.mainFrame.Navigate(typeof(BlankPage1));
        }

        private void iFutur_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.mainFrame.Navigate(typeof(Futur));
        }

        private void iConnexion_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.mainFrame.Navigate(typeof(Connect));
        }
    }
}
