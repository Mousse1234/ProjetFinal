using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale
{
    internal class LesCoutsFinal
    {
        string prenom;
        string nom;
        decimal salaireBrut;
        decimal salaireNet;
        decimal tauxRetenu;

        public string Prenom { get => prenom; set => prenom = value; }
        public string Nom { get => nom; set => nom = value; }
        public decimal SalaireBrut { get => salaireBrut; set => salaireBrut = value; }
        public decimal SalaireNet { get => salaireNet; set => salaireNet = value; }
        public decimal TauxRetenu { get => tauxRetenu; set => tauxRetenu = value; }

        public override string ToString()
        {
            return prenom + ' ' + nom + ' ' + salaireBrut + ' ' + salaireNet + ' ' + tauxRetenu + ' ';
        }
    }
}
