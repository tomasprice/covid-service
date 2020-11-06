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
                        EndSession();
                        break;
                }
                Console.ReadLine();
                Console.Clear();

            } while (userOperation != 4);
        }

        static private void Menu()
        {
            Console.WriteLine("******** Covid-19 Patients ********");
            Console.WriteLine("\n\n");
            Console.WriteLine("Select operation from bellow menu.");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Get Added Patients (returns session patients)");
            Console.WriteLine("3. End connection (ends session, returns patients)");
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
            
            covidService.AddPatient(new Patient.CovidPatient()
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
        static private void EndSession()
        {
            var patients = covidService.EndSession();

            for (int i = 0; i < patients.Count(); i++)
            {
                var patient = patients[i];
                GetPatient(patient, i);
            }

            Console.WriteLine("\n\n***Session has ended.***");
        }

        private static Patient.Contact GetPatientContact()
        {
            Console.WriteLine("\n\tPatient contact ");
            Console.Write("\t\tName: ");
            var name = Console.ReadLine();

            Console.Write("\t\tSurname: ");
            var surname = Console.ReadLine();

            Console.Write("\t\tContact date: ");
            var contactDate = Convert.ToDateTime(Console.ReadLine());

            Console.Write("\t\tAddress: ");
            var address = Console.ReadLine();

            return new Patient.Contact
            {
                Name = name,
                Surname = surname,
                Address = address,
                ContactDate = contactDate,
            };
        }

        private static void GetPatientsSession()
        {
            Console.Clear();
            var patients = covidService.GetPatients();

            for (int i = 0; i < patients.Count(); i++)
            {
                var patient = patients[i];
                GetPatient(patient, i);
            }
        }

        private static void GetPatient(Patient.CovidPatient patient, int index)
        {
            Console.WriteLine("\n");
            Console.WriteLine($"\t***Displaying patient data for record {index}***");

            // Patient
            Console.WriteLine($"\t\tName: {patient.Name}");
            Console.WriteLine($"\t\tSurname: {patient.Surname}");
            Console.WriteLine($"\t\tAge: {patient.Age}");
            Console.WriteLine($"\t\tFirst symptoms: {patient.Age}");
            Console.WriteLine($"\t\tDate of test: {patient.Age}");
            Console.WriteLine($"\t\tAddress: {patient.Age}");

            // Contact
            Console.WriteLine("\t\t***Patient contact data***");
            Console.WriteLine($"\t\t\tName: {patient.PatientContact.Name}");
            Console.WriteLine($"\t\t\tSurname: {patient.PatientContact.Surname}");
            Console.WriteLine($"\t\t\tContact date: {patient.PatientContact.ContactDate}");
            Console.WriteLine($"\t\t\tAddress: {patient.PatientContact.Address}");


        }
    }
}
