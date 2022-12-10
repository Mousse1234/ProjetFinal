using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale
{
    internal class Ville
    {
        string nomVille;

        public string NomVille { get => nomVille; set => nomVille = value; }

        public override string ToString()
        {
            return nomVille;
        }
    }
}
