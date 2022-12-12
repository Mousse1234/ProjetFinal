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
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinale
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutVille : Page
    {
        bool verif = true;
        
        public AjoutVille()
        {
            this.InitializeComponent();
        }


        private void Click_Click(object sender, RoutedEventArgs e)
        {
            verif = true;
            reset();

            var isNumber = new Regex(@"[1-9]+");

            if (tbNomVille.Text.Trim() == "")
            {
                verif = false;
                tblerr.Visibility = Visibility.Visible;
                tblerr.Text = "Aucun nom de ville a été insérer";
            }

            if (isNumber.IsMatch(tbNomVille.Text))
            {
                verif = false;
                tblerr.Visibility = Visibility.Visible;
                tblerr.Text = "Le nom entré doit être composé de lettres";
            }
            
            if (verif == true)
            {
                Ville v = new Ville()
                {
                    NomVille = tbNomVille.Text,
                };

                if (GestionBD.getInstance().addVille(v) > 0)
                {
                    tblok.Visibility = Visibility.Visible;
                    tblerr.Visibility = Visibility.Collapsed;
                }
                else
                {
                    tblok.Visibility = Visibility.Collapsed;
                    tblerr.Visibility = Visibility.Visible;

                }

            }
            
        }

        private void reset()
        {
            tblerr.Visibility = Visibility.Collapsed;
            tblok.Visibility = Visibility.Collapsed;
        }
    }
}
