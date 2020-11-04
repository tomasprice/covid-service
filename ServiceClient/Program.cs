using ServiceClient.CovidServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceClient
{
    class Program
    {
        static private RegisterServiceClient covidService = new CovidServiceReference.RegisterServiceClient();
        static private int userOperation;
        static private Patient.Patient Patient;
        static private Patient.PatientContact PatientContact;

        static void Main(string[] args)
        {

            do
            {
                Menu();
                userOperation = int.Parse(Console.ReadLine());
                switch (userOperation)
                {
                    case 1:
                        AddPatient();
                        break;
                    case 2:
                        GetPatientsSession();
                        break;
                    case 3:
                        GetPatientsSession();
                        break;
                }

            } while (userOperation != 4);
        }

        static private void Menu()
        {
            Console.WriteLine("******** Covid-19 Patients ********");
            Console.WriteLine("\n\n");
            Console.WriteLine("Select operation from bellow menu.");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Get Added Patients (for session)");
            Console.WriteLine("3. End connection (returns patiens list)");
            Console.WriteLine("4. Exit");
            Console.Write("\nWhat should I do?: ");
        }

        static private void AddPatient()
        {
            string name;
            string surname;
            int age;
            DateTime firstSymptoms;
            DateTime testDate;
            string address;

            Console.Clear();
            Console.WriteLine("Type patient data...\n");

            Console.Write("\t\tName: ");
            name = Console.ReadLine();

            Console.Write("\t\tSurname: ");
            surname = Console.ReadLine();
            
            Console.Write("\t\tAge: ");
            age = int.Parse(Console.ReadLine());

            Console.Write("\t\tFirst symptoms: ");
            firstSymptoms = Convert.ToDateTime(Console.ReadLine());

            Console.Write("\t\tTest date: ");
            testDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("\t\tAddress: ");
            address = Console.ReadLine();

            covidService.AddPatient(new Patient.Patient()
            {
                Name = name,
                Surname = surname,
                Age = age,
                FirstSymptoms = firstSymptoms,
                TestDate = testDate,
                Address = address
            });
        }

        private static void GetPatientsSession()
        {
            var patients = covidService.GetPatients();

            foreach (var item in patients)
            {
                GetPatient(item);
            }
        }

        private static void GetPatient(Patient.Patient patient)
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tPatient");

            Console.WriteLine($"\t\tName: {patient.Name}");
            Console.WriteLine($"\t\tSurname: {patient.Surname}");
            Console.WriteLine($"\t\tAge: {patient.Age}");
            Console.WriteLine($"\t\tFirst symptoms: {patient.Age}");
            Console.WriteLine($"\t\tDate of test: {patient.Age}");
            Console.WriteLine($"\t\tAddress: {patient.Age}");

        }
    }
}
