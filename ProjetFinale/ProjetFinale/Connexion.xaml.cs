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
    public sealed partial class Connexion : Page
    {

        bool verif = true;
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
                //connection route menu
            }
        }
        private void reset()
        {
            errEmail.Visibility = Visibility.Collapsed;
            errMdp.Visibility = Visibility.Collapsed;
        }
    }
}
