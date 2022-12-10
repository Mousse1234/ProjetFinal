using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale
{
    internal class Trajet
    {
        int idTrajet;
        string immatriculation;
        int idUsage;
        string villeDepart;
        string villeArrivee;
        int nbrArret;
        string status;

        public int IdTrajet { get => idTrajet; set => idTrajet = value; }
        public string Immatriculation { get => immatriculation; set => immatriculation = value; }
        public int IdUsage { get => idUsage; set => idUsage = value; }
        public string VilleDepart { get => villeDepart; set => villeDepart = value; }
        public string VilleArrivee { get => villeArrivee; set => villeArrivee = value; }
        public int NbrArret { get => nbrArret; set => nbrArret = value; }
        public string Status { get => status; set => status = value; }

        public override string ToString()
        {
            return "Id: " + idTrajet + "\nImmatriculation: " + immatriculation + "\nId conducteur: " + idUsage + 
                    "\nVille depart: " + villeDepart + "\nVille arrivee: " + villeArrivee + "\nNombre d'arret: " + nbrArret + "\nStatus: " + status;
        }
    }
}
