using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetFinale
{
    internal class Usage
    {
        int idUsage;
        string email;
        string password;
        string nom;
        string prenom;
        string adresse;
        string noTel;
        string typeCompte;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Adresse { get => adresse; set => adresse = value; }
        public string NoTel { get => noTel; set => noTel = value; }
        public string TypeCompte { get => typeCompte; set => typeCompte = value; }
        public int IdUsage { get => idUsage; set => idUsage = value; }

        public override string ToString()
        {
            return idUsage + email +  password +  nom +  prenom +  adresse +  noTel +  typeCompte ;
        }


    }
}
