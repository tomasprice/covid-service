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
        static private RegisterServiceClient covidService = null;
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
                        AddContact();
                        break;
                    case 3:
                        GetPatientsSession();
                        break;
                    case 4:
                        EndSession();
                        break;
                }
                Console.ReadLine();
                Console.Clear();

            } while (userOperation != 5);
        }

        static private void Menu()
        {
            Console.WriteLine("******** Covid-19 Patients ********");
            Console.WriteLine("\n\n");
            Console.WriteLine("Select operation from bellow menu.");
            Console.WriteLine("1. Add Patient");
            Console.WriteLine("2. Add Contact");
            Console.WriteLine("3. Get Added Patients (returns session patients)");
            Console.WriteLine("4. End connection (ends session, returns patients)");
            Console.WriteLine("5. Exit");
            Console.Write("\nWhat should I do?: ");
        }

        static private void AddPatient()
        {
            Console.Clear();
            StartSession();
            TestMode();
            //Console.WriteLine("Patient data\n");

            //Console.Write("\tName: ");
            //var name = Console.ReadLine();

            //Console.Write("\tSurname: ");
            //var surname = Console.ReadLine();
            
            //Console.Write("\tAge: ");
            //var age = int.Parse(Console.ReadLine());

            //Console.Write("\tFirst symptoms: ");
            //var firstSymptoms = Convert.ToDateTime(Console.ReadLine());

            //Console.Write("\tTest date: ");
            //var testDate = Convert.ToDateTime(Console.ReadLine());

            //Console.Write("\tAddress: ");
            //var address = Console.ReadLine();

            //var patientContact = GetPatientContact();
            
            //covidService.AddPatient(new Patient.CovidPatient()
            //{
            //    Name = name,
            //    Surname = surname,
            //    Age = age,
            //    FirstSymptoms = firstSymptoms,
            //    TestDate = testDate,
            //    Address = address,
            //    PatientContact = patientContact
            //});
        }

        private static void TestMode()
        {
            covidService.AddPatient(new Patient.CovidPatient()
            {
                Name = "Ala",
                Surname = "Kot",
                Age = 42,
                FirstSymptoms = Convert.ToDateTime("21 / 11 / 2020 12:25:00"),
                TestDate = Convert.ToDateTime("21 / 11 / 2020 12:25:00"),
                Address = "Dluga 10",
                PatientContact = new List<Patient.Contact>()
            });
            Console.WriteLine("Auto added patient");
        }

        private static void AddContact()
        {
            Console.Clear();
            if (CheckSession())
            {
                Console.WriteLine("***Session not started.***");
                Console.WriteLine("***Start session first (AddPatient()).***");
                return;
            }

            var contact = new Patient.Contact
            {
                Name = "Contact",
                Surname = "Contact surname",
                Address = "Elk, Poland",
                ContactDate = Convert.ToDateTime("21/11/2020 12:25:00")
            };
            covidService.AddContact(contact);
            Console.WriteLine("Auto added contact");

            //Console.WriteLine("\n\tPatient contact ");
            //Console.Write("\t\tName: ");
            //var name = Console.ReadLine();

            //Console.Write("\t\tSurname: ");
            //var surname = Console.ReadLine();

            //Console.Write("\t\tContact date: ");
            //var contactDate = Convert.ToDateTime(Console.ReadLine());

            //Console.Write("\t\tAddress: ");
            //var address = Console.ReadLine();

            //patient.PatientContact.Add(new Patient.Contact
            //{
            //    Name = name,
            //    Surname = surname,
            //    Address = address,
            //    ContactDate = contactDate,
            //});
        }

        static private void StartSession()
        {
            if (covidService == null)
            {
                covidService = new CovidServiceReference.RegisterServiceClient();
            }
        }

        static private void EndSession()
        {
            Console.Clear();
            if (CheckSession())
            {
                Console.WriteLine("***Session not started.***");
                Console.WriteLine("***Start session first (AddPatient()).***");
                return;
            }
            var patients = covidService.EndSession();

            for (int i = 0; i < patients.Count(); i++)
            {
                var patient = patients[i];
                GetAllPatients(patient, i);
            }
            covidService = null;
            Console.WriteLine("\n\n***Session has ended.***");
        }

        static private bool CheckSession()
        {
            if (covidService == null)
            {
                return true;
            }

            return false;
        }

        private static void GetPatientsSession()
        {
            Console.Clear();
            if (CheckSession())
            {
                Console.WriteLine("***Session not started.***");
                Console.WriteLine("***Start session first (AddPatient()).***");
                return;
            }
            var patients = covidService.GetPatient();

            GetPatient(covidService.GetPatient());
        }

        private static void GetAllPatients(Patient.CovidPatient patient, int index)
        {
            Console.WriteLine($"\t***Displaying patient data for record {index}***");
            GetPatient(patient);
        }

        private static void GetPatient(Patient.CovidPatient patient)
        {
            Console.WriteLine("\n");

            // Patient
            Console.WriteLine($"\t\tName: {patient.Name}");
            Console.WriteLine($"\t\tSurname: {patient.Surname}");
            Console.WriteLine($"\t\tAge: {patient.Age}");
            Console.WriteLine($"\t\tFirst symptoms: {patient.FirstSymptoms}");
            Console.WriteLine($"\t\tDate of test: {patient.TestDate}");
            Console.WriteLine($"\t\tAddress: {patient.Address}");

            // Contact
            Console.WriteLine("\n\t\t***Contacts data***");
            foreach (var item in patient.PatientContact)
            { 
                Console.WriteLine($"\t\t\tName: {item.Name}");
                Console.WriteLine($"\t\t\tSurname: {item.Surname}");
                Console.WriteLine($"\t\t\tContact date: {item.ContactDate}");
                Console.WriteLine($"\t\t\tAddress: {item.Address}");
                Console.WriteLine();
            }
       
        }
    }
}
