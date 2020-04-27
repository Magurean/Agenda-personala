using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace Agenda
{
    internal class Persoane
    {
        
        string nume;
        string prenume;
        string data;
        string email;
        public Agenda agenda;
        public static List<Persoane> persoane = new List<Persoane>();

        public Persoane(string linie)
        {                            
            string[] tokens=linie.Split(',');
            nume = tokens[0];
            prenume = tokens[1];
            data = tokens[2];
            email = tokens[3];           
        }

        public static Persoane CreatePerson(string linie)
        {
            Persoane persoana = new Persoane(linie); 
            persoane.Add(persoana);
            Console.WriteLine("Persoana creata: {0}", persoana.FullName);
            return persoana;
        }

        public string FullName { get { return nume + " " + prenume; } }
        public string DataNastere { get { return data; } }   
        public string Email { get { return email; } }

    }
}