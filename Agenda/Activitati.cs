using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    class Activitati
    { 
        
        //nume, descriere, data ora incepere, data ora sfarsit
         public DateTime dataIncepere;
         public DateTime dataSfarsit;
         string descriere;
         public string nume;
         public List<Persoane> Participanti;


        public Activitati(string name, string description, DateTime dataStart, DateTime dataEnd)
        {
            nume = name;
            descriere = description;
            dataIncepere = dataStart;
            dataSfarsit = dataEnd;
        }
        public string Show()
        {
            return $"{nume}, {dataIncepere.ToString()}, {dataSfarsit.ToString()}";
        }

    }
}
