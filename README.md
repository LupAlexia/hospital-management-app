# 🏥 Hospital Staff Management – C# Windows Forms Application

The project is a C# Windows Forms application developed using Visual Studio 2022 and is backed by a local MS SQL database. The application is in Romanian and it is designed to manage hospital personnel information at the Bistrița County Emergency Clinical Hospital.

## 📋 Project Description
Hospital Staff Management is a human resources management application tailored for hospital HR departments. It allows efficient tracking and administration of medical staff records.
It provides a more flexible and tailored alternative to government-issued HR software. It supports accurate and fast data handling, simplifying the daily operations of HR personnel in hospitals.

## 🗃️ Database Structure
The application uses a local SQL database named "MediciDatabase", which contains the following tables:
- Administrators – Stores user credentials for access control
- Doctors – Stores personal and professional information about medical staff
- Departments – Lists hospital departments
- Appointments – Schedules for patient consultations over a two-week period
- Photos – Stores file paths to each doctor’s photo

## 🖼️ Application Interface (Forms)
The application includes several Windows Forms:
- AutentificareForm – Login screen for administrators
- MainForm – Main dashboard with navigation options
- PrezentareForm – View doctors by department
- RegistruForm – Select a doctor to view personal info
- InfoForm – View doctor’s full profile and photo
- ModifInfoForm – Edit doctor’s information
- ProgramForm – View doctor’s schedule for a selected day

## 🧭 How to Use
- Login as an administrator using valid credentials.
- From the Main Menu, you can choose one of the following:
Medical Team – View all doctors in a specific department
Personal Information – Select and view or edit details for a specific doctor
Schedule – View a doctor’s appointments for a specific day
All data is read from and written to the local database securely.
