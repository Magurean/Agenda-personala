using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda
{
    class Agenda
    {
        
        public List<Activitati> listaActivitati = new List<Activitati>();
        public static List<Agenda> listaAgende = new List<Agenda>();
        public Persoane detinator;

        public Agenda(Persoane persoana)
        {
            listaActivitati = new List<Activitati>();
            detinator = persoana;
        }

        public static Agenda CreateAgenda(Persoane persoana)
        {
            Agenda agenda = new Agenda(persoana);
            persoana.agenda = agenda;
            listaAgende.Add(agenda);
            Console.WriteLine("Agenda creata pentru: {0}", persoana.FullName);
            return agenda;
        }

        public static Activitati Create(Agenda agenda, string nume, string descriere, DateTime start, DateTime end)
        {
            Activitati activitate = new Activitati(nume, descriere, start, end);
            activitate.Participanti = new List<Persoane>();

            Console.WriteLine("Activitate creata: {0}", activitate.Show());
            agenda.listaActivitati.Add(activitate);
            return activitate;
        }

        public static Activitati Add(Persoane persoane, Activitati activitate)
        {           
            if (persoane.agenda == null)
                CreateAgenda(persoane);

            persoane.agenda.listaActivitati.Add(activitate);
            Console.WriteLine("Activitate adaugata in agenda lui {0}: {1}", persoane.FullName, activitate.Show());
            return activitate;
        }

        public static Activitati Remove(Persoane persoana, Activitati activitate)
        {
            if (persoana.agenda == null) 
                return activitate;

            persoana.agenda.listaActivitati.Remove(activitate);
            Console.WriteLine("Activitate eliminata din agenda lui {0}: {1}", persoana.FullName, activitate.Show());
            return activitate;
        }

        public static Activitati Delete(Activitati activitate)
        {
            foreach (Persoane person in activitate.Participanti)
               Remove(person, activitate);

            activitate.Participanti.Clear();

            Console.WriteLine("Activitate stearsa: {0}",activitate.Show());
            return activitate;
        }

        public static List<Activitati> CautareNume(Persoane persoane, string nume)
        {
            nume.ToLower().Trim();
            if (persoane.agenda == null)
              return new List<Activitati>();

            List<Activitati> rezultat = persoane.agenda.listaActivitati.Where(x => x.nume.ToLower().Contains(nume)).ToList();
            if(rezultat.Count ==0)
                Console.WriteLine("Nu au fost gasite rezultate dupa cuvantul '{0}'",nume);

            foreach (Activitati activitate in rezultat)
                Console.WriteLine("Rezultat cautare dupa cuvantul {0}: {1}", nume, activitate.Show());

            return rezultat;
        }

        public static List<Activitati> CautareInterval(Persoane persoane, DateTime start, DateTime end)
        {
            if (persoane.agenda == null)
              return new List<Activitati>();

            List<Activitati> rezultat = persoane.agenda.listaActivitati.Where(x => x.dataIncepere >= start && x.dataSfarsit <= end).ToList();

            if (rezultat.Count == 0)
                Console.WriteLine("Nu au fost gasite rezultate in intervalul {0} - {1}", start, end);

            foreach (Activitati activitate in rezultat)
                Console.WriteLine("Rezultat cautare dupa intervalul orar: {0}", activitate.Show());

            return rezultat;
        }

        public static Activitati Meeting(int durata, Persoane[] persoane)
        {
            DateTime timp = new DateTime();


            Activitati meeting = new Activitati("Meeting", "Discutii despre proiecte", timp, timp.AddHours(durata));
            meeting.Participanti = persoane.ToList();


            foreach (Persoane aux in persoane)
                if (aux.agenda != null)
                    foreach (Activitati activity in aux.agenda.listaActivitati)
                        if (activity.dataSfarsit > timp)
                            timp = activity.dataIncepere;

            meeting.dataIncepere = timp;
            meeting.dataSfarsit = timp.AddHours(durata);

            Console.WriteLine("Urmatoarea intalnire: {0}", meeting.Show());

            foreach (Persoane aux in persoane)
                aux.agenda.listaActivitati.Add(meeting);

            return meeting;
        }

    }
}
