using System;
using System.Collections.Generic;
using System.Linq;

namespace HospitalManagementSystem
{
    public class Doctor
    {
        public int Id;
        public string Name;
        public string Specialty;

        public Doctor(int id, string name, string specialty)
        {
            Id = id;
            Name = name;
            Specialty = specialty;
        }
    }
    public class Patient
    {
        public int Id;
        public string Name;
        public int Age;
        public Patient(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }

    public class HospitalRoom
    {
        public int Number;
        public int Capacity;
        public List<Patient> Patients;

        public HospitalRoom(int number, int capacity)
        {
            Number = number;
            Capacity = capacity;
            Patients = new List<Patient>();
        }

        public bool AddPatient(Patient patient)
        {
            if (Patients.Count >= Capacity)
            {
                Console.WriteLine($"Палата {Number} заповнена.");
                return false;
            }

            Patients.Add(patient);
            Console.WriteLine($"Пацієнта {patient.Name} додано до палати {Number}.");
            return true;
        }
    }

    public class MedicalRecord
    {
        public Patient Patient;
        public Doctor Doctor;
        public DateTime Date;
        public string Description;

        public MedicalRecord(Patient patient, Doctor doctor, DateTime date, string description)
        {
            Patient = patient;
            Doctor = doctor;
            Date = date;
            Description = description;
        }
    }
    public class Hospital
    {
        private List<Doctor> Doctors = new List<Doctor>();
        private List<Patient> Patients = new List<Patient>();
        private List<HospitalRoom> Rooms = new List<HospitalRoom>();
        private List<MedicalRecord> Records = new List<MedicalRecord>();

        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                Console.WriteLine("Неможливо додати некоректного лікаря.");
                return;
            }

            Doctors.Add(doctor);
            Console.WriteLine($"Додано лікаря: {doctor.Name} ({doctor.Specialty})");
        }

        public void RegisterPatient(Patient patient)
        {
            if (patient == null || string.IsNullOrWhiteSpace(patient.Name) || patient.Age <= 0)
            {
                Console.WriteLine("Некоректні дані пацієнта.");
                return;
            }

            Patients.Add(patient);
            Console.WriteLine($"Зареєстровано пацієнта: {patient.Name}, {patient.Age} років");
        }

        public void CreateRoom(HospitalRoom room)
        {
            if (room == null)
            {
                Console.WriteLine("Неможливо створити некоректну палату.");
                return;
            }

            Rooms.Add(room);
            Console.WriteLine($"Створено палату №{room.Number} (Місткість: {room.Capacity})");
        }

        public void HospitalizePatient(int patientId, int roomNumber)
        {
            var patient = Patients.FirstOrDefault(p => p.Id == patientId);
            var room = Rooms.FirstOrDefault(r => r.Number == roomNumber);

            if (patient == null)
            {
                Console.WriteLine($"Пацієнт з ID {patientId} не знайдений.");
                return;
            }

            if (room == null)
            {
                Console.WriteLine($"Палата №{roomNumber} не знайдена.");
                return;
            }

            room.AddPatient(patient);
        }

        public void AddMedicalRecord(MedicalRecord record)
        {
            if (record == null)
            {
                Console.WriteLine("Неможливо додати порожній медичний запис.");
                return;
            }

            Records.Add(record);
            Console.WriteLine($"Додано медичний запис для пацієнта {record.Patient.Name}");
        }

        public List<MedicalRecord> GetPatientHistory(int patientId)
        {
            return Records.Where(r => r.Patient.Id == patientId)
                          .OrderByDescending(r => r.Date)
                          .ToList();
        }

        public string GetStatistics()
        {
            int totalPatients = Patients.Count;
            int totalDoctors = Doctors.Count;
            int totalRooms = Rooms.Count;
            int totalRecords = Records.Count;
            int occupiedRooms = Rooms.Count(r => r.Patients.Count > 0);

            return $"\n=== СТАТИСТИКА ===\n" +
                   $"Лікарів: {totalDoctors}\n" +
                   $"Пацієнтів: {totalPatients}\n" +
                   $"Палат: {totalRooms} (зайнятих: {occupiedRooms})\n" +
                   $"Медичних записів: {totalRecords}\n";
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Program demo = new Program();
            demo.Run();

            Console.WriteLine("\nНатисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }

        public void Run()
        {
            Console.WriteLine("=== СИСТЕМА УПРАВЛІННЯ ЛІКАРНЕЮ ===\n");

            Hospital hospital = new Hospital();

            var doctor1 = new Doctor(1, "Іванов Іван", "Терапевт");
            var doctor2 = new Doctor(2, "Петрова Марія", "Хірург");
            hospital.AddDoctor(doctor1);
            hospital.AddDoctor(doctor2);

            var patient1 = new Patient(1, "Коваленко Тарас", 35);
            var patient2 = new Patient(2, "Шевченко Ольга", 28);
            hospital.RegisterPatient(patient1);
            hospital.RegisterPatient(patient2);

            var room1 = new HospitalRoom(101, 2);
            var room2 = new HospitalRoom(102, 1);
            hospital.CreateRoom(room1);
            hospital.CreateRoom(room2);

            hospital.HospitalizePatient(1, 101);
            hospital.HospitalizePatient(2, 102);

            var record1 = new MedicalRecord(patient1, doctor1, DateTime.Now, "ГРВІ, курс лікування на 5 днів");
            var record2 = new MedicalRecord(patient2, doctor2, DateTime.Now.AddDays(-2), "Операція на апендиксі, відновлення");
            hospital.AddMedicalRecord(record1);
            hospital.AddMedicalRecord(record2);

            Console.WriteLine("\n--- ІСТОРІЯ ПАЦІЄНТА ---");
            var history = hospital.GetPatientHistory(1);
            foreach (var record in history)
            {
                Console.WriteLine($"  Дата: {record.Date.ToShortDateString()}");
                Console.WriteLine($"  Лікар: {record.Doctor.Name}");
                Console.WriteLine($"  Опис: {record.Description}\n");
            }
            Console.WriteLine(hospital.GetStatistics());
        }
    }
}