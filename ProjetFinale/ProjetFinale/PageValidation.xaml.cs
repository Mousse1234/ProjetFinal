// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProjetFinale
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageValidation : Page
    {
        public PageValidation()
        {
            this.InitializeComponent();
            textValidation.Text = Reservation.selection.ToString();
            GestionBD.getInstance().NValideRes.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().NRefusRes.Visibility = Visibility.Collapsed;

        }

        private void oui_Click(object sender, RoutedEventArgs e)
        {
            GestionBD.getInstance().MainFrame.Navigate(typeof(Reservation));
            GestionBD.getInstance().NValideRes.Visibility = Visibility.Visible;
            GestionBD.getInstance().NRefusRes.Visibility = Visibility.Collapsed;

            GestionBD.getInstance().resPlace(Reservation.idSelection);

        }

        private void non_Click(object sender, RoutedEventArgs e)
        {
            GestionBD.getInstance().MainFrame.Navigate(typeof(Reservation));
            GestionBD.getInstance().NValideRes.Visibility = Visibility.Collapsed;
            GestionBD.getInstance().NRefusRes.Visibility = Visibility.Visible;

        }
    }
}
