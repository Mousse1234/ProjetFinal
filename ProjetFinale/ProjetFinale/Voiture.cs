using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;

namespace ProjetFinale
{
    internal class Voiture
    {
        string immatriculation;
        int idUsager;
        string typeVoiture;
        int idTrajet;
        int nbrPassagerMax;
        int nbrPassagerDispo;
        double salaireBrut;
        double tauxRetenu;
        double salaireNet;

        public string Immatriculation { get => immatriculation; set => immatriculation = value; }
        public int IdUsager { get => idUsager; set => idUsager = value; }
        public string TypeVoiture { get => typeVoiture; set => typeVoiture = value; }
        public int IdTrajet { get => idTrajet; set => idTrajet = value; }
        public int NbrPassagerMax { get => nbrPassagerMax; set => nbrPassagerMax = value; }
        public int NbrPassagerDispo { get => nbrPassagerDispo; set => nbrPassagerDispo = value; }
        public double SalaireBrut { get => salaireBrut; set => salaireBrut = value; }
        public double TauxRetenu { get => tauxRetenu; set => tauxRetenu = value; }
        public double SalaireNet { get => salaireNet; set => salaireNet = value; }
    }
}
