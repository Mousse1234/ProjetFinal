using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale
{
    internal class Trajets
    {
        string dateTrajet;
        string hdepart;
        string harrivee;
        string vehicules;
        int nbPlace;
        int prixPlace;
        
        public string DateTrajet { get => dateTrajet; set => dateTrajet = value; }
        public string Hdepart { get => hdepart; set => hdepart = value; }
        public string Harrivee { get => harrivee; set => harrivee = value; }
        public string Vehicules { get => vehicules; set => vehicules = value; }
        public int NbPlace { get => nbPlace; set => nbPlace = value; }
        public int PrixPlace { get => prixPlace; set => prixPlace = value; }

        public override string ToString()
        {
            return  "Date du trajet" + DateTrajet + "Heure départ" + Hdepart +  "heure arrivee" + Harrivee +
                    "type de véhicule" + Vehicules + "nb place" + NbPlace + " prix de place" + PrixPlace;
        }

    }
}
