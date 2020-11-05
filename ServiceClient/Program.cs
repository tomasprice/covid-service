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

        static void Main(string[] args)
        {
            // 21/11/2020 12:25:00
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
            Console.Clear();
            Console.WriteLine("Patient data\n");

            Console.Write("\tName: ");
            var name = Console.ReadLine();

            Console.Write("\tSurname: ");
            var surname = Console.ReadLine();
            
            Console.Write("\tAge: ");
            var age = int.Parse(Console.ReadLine());

            Console.Write("\tFirst symptoms: ");
            var firstSymptoms = Convert.ToDateTime(Console.ReadLine());

            Console.Write("\tTest date: ");
            var testDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("\tAddress: ");
            var address = Console.ReadLine();

            var patientContact = GetPatientContact();
            
            covidService.AddPatient(new Patient.Patient()
            {
                Name = name,
                Surname = surname,
                Age = age,
                FirstSymptoms = firstSymptoms,
                TestDate = testDate,
                Address = address,
                PatientContact = patientContact
            });
        }

        private static Patient.PatientContact GetPatientContact()
        {
            Console.WriteLine("\n\tPatient contact ");
            Console.Write("\t\tName: ");
            var name = Console.ReadLine();

            Console.Write("\t\tSurname: ");
            var surname = Console.ReadLine();

            Console.Write("\t\tTest date: ");
            var contactDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("\t\tAddress: ");
            var address = Console.ReadLine();

            return new Patient.PatientContact
            {
                Name = name,
                Surname = surname,
                Address = address,
                ContactDate = contactDate,
            };
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
