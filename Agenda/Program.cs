using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;


namespace Agenda
{
    class Program
    {
        public static List<Persoane> listaPersoane = new List<Persoane>();
        public static List<Agenda> listaAgende = new List<Agenda>();
        
        static void Main(string[] args)
        {

            string[] lines = Read();
            Persoane[] persoana = new Persoane[lines.Length];
            Agenda[] agenda = new Agenda[lines.Length];


            for (int i = 0; i < lines.Length; i++)
            {
                persoana[i] = Persoane.CreatePerson(lines[i]);
                listaPersoane.Add(persoana[i]);
                agenda[i] = Agenda.CreateAgenda(persoana[i]);
                listaAgende.Add(agenda[i]);
            }

            //Console.WriteLine(pers[0].FullName);
            //Console.WriteLine(pers[0].DataNastere);
            //Console.WriteLine(pers[0].Email);

            Activitati alergat = Agenda.Create(agenda[0], "Alergat", "Alerg prin parc", new DateTime(2020, 01, 01, 10, 00, 01), new DateTime(2020,01,01,11,00,01));
            Activitati citit = Agenda.Create(agenda[0], "Citit", "Carti despre c#", new DateTime(2020, 01, 02, 12, 11, 11), new DateTime(2020, 01, 02, 15, 02, 02));

            Agenda.Add(persoana[1], alergat);
            Agenda.Add(persoana[1], citit);
            Agenda.Add(persoana[2], alergat);
            Agenda.Add(persoana[0], citit);
            Agenda.Remove(persoana[0], citit);
            Agenda.Delete(alergat);
            Agenda.CautareNume(persoana[2], "alergat");
            Agenda.CautareInterval(persoana[0], new DateTime(2020, 01, 01, 09, 00, 00), new DateTime(2020, 01, 01, 12, 00, 01));
            Agenda.Meeting(3, persoana);

            Console.ReadKey();
        }
        public static string[] Read()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string csvLocation = Path.Combine(executableLocation, "Lista.csv");
            StreamReader file = new StreamReader(csvLocation);
            string[] lines = File.ReadAllLines(csvLocation);
            return lines;
        }
    }
}
