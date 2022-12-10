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
    public sealed partial class Inscription : Page
    {
        bool verif = true;
        public Inscription()
        {
            this.InitializeComponent();
            cbType1.Items.Add("conducteur"); 
            cbType1.Items.Add("passager");
        }


     

       

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            reset();

            if (Nom1.Text.Trim() == "")
            {
                verif = false;
                errNom1.Visibility = Visibility.Visible;
            }

            if (Email1.Text.Trim() == "")
            {
                verif = false;
                errEmail1.Visibility = Visibility.Visible;
                errEmail1.Text = "Entrez votre Email";
            }

            if (Prenom1.Text.Trim() == "")
            {
                verif = false;
                errPrenom1.Visibility = Visibility.Visible;
            }

            if (Num1.Text.Trim() == "")
            {
                verif = false;
                errNum1.Visibility = Visibility.Visible;
            }

            if (Mdp1.Text.Trim() == "")
            {
                verif = false;
                errMdp1.Visibility = Visibility.Visible;
            }
            if (VerifMdp1.Text.Trim() == "")
            {
                verif = false;
                errVerifMdp1.Visibility = Visibility.Visible;
                errVerifMdp1.Text = "Repeter votre mot de passe";
            }

            if (Adresse1.Text.Trim() == "")
            {
                verif = false;
                errAdresse1.Visibility = Visibility.Visible;
            }

            if (Mdp1.Text != VerifMdp1.Text)
            {
                verif = false;
                errVerifMdp1.Visibility = Visibility.Visible;
                errVerifMdp1.Text = "Les mots de passe ne correspondent pas";
            }

            if (verif == true)
            {
                Usage us = new Usage()
                {
                    Email = Email1.Text,
                    Password = Mdp1.Text,
                    Prenom = Prenom1.Text,
                    Nom = Nom1.Text,
                    Adresse = Adresse1.Text,
                    NoTel = Num1.Text,
                    TypeCompte = cbType1.SelectedItem.ToString()
                };

                if (GestionBD.getInstance().inscription(us) > 0)
                {
                    inscValide.Visibility = Visibility.Visible;
                }
                else
                {
                    inscValide.Visibility = Visibility.Collapsed;
                    Email1.Text = "Email deja existant";
                    errEmail1.Visibility = Visibility.Visible;
                }
            }
        }

        private void reset()
        {
            errNom1.Visibility = Visibility.Collapsed;
            errEmail1.Visibility = Visibility.Collapsed;
            errPrenom1.Visibility = Visibility.Collapsed;
            errNum1.Visibility = Visibility.Collapsed;
            errAdresse1.Visibility = Visibility.Collapsed;
            errMdp1.Visibility = Visibility.Collapsed;
            errVerifMdp1.Visibility = Visibility.Collapsed;
        }

        /*private void listeCategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Usage m = (Usage)listeStatut.SelectedItem;
        }*/
    }
}
