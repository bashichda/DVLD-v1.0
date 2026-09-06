# 🚗 DVLD — Driver & Vehicle Licensing Department System

![C#](https://img.shields.io/badge/Language-C%23-purple?style=flat-square&logo=csharp)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=flat-square&logo=microsoftsqlserver)
![WinForms](https://img.shields.io/badge/UI-Windows%20Forms-blue?style=flat-square)
![Architecture](https://img.shields.io/badge/Architecture-3--Layer%20N--Tier-orange?style=flat-square)
![Framework](https://img.shields.io/badge/Framework-.NET%204.7.2-blueviolet?style=flat-square)
![UserControls](https://img.shields.io/badge/UI-Custom%20UserControls-teal?style=flat-square)
![Status](https://img.shields.io/badge/Status-Complete-brightgreen?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-yellow?style=flat-square)

A full-scale **Driver and Vehicle Licensing Department** desktop application built with C# Windows Forms and SQL Server. Manages the complete lifecycle of driving licenses — from person registration and test scheduling, through license issuance, renewal, detention, and international licensing — all backed by a proper **3-layer (N-Tier) architecture** across three separate Visual Studio projects.

---

## 📸 Preview

```
┌─────────────────────────────────────────────────────────────────────────┐
│  🏛️ DVLD  │  Application ▼  │  People  │  Drivers  │  Users  │  Account ▼ │
├─────────────────────────────────────────────────────────────────────────┤
│   Application ▼                                                         │
│    ├── Driving Licence Services ▶                                       │
│    │    ├── New Driving License ▶                                        │
│    │    │    ├── Local License                                           │
│    │    │    └── International License                                   │
│    │    ├── Renew Driving License                                        │
│    │    ├── Replacement for Lost or Damaged License                      │
│    │    ├── Release Detained Driving License                             │
│    │    └── Retake Test                                                  │
│    ├── Manage Applications ▶                                            │
│    │    ├── Local Driving License Applications                           │
│    │    └── International License Applications                           │
│    ├── Detain Licenses ▶                                                │
│    │    ├── Manage Detained Licenses                                     │
│    │    ├── Detain License                                               │
│    │    └── Release Detained License                                     │
│    ├── Manage Applications Types                                         │
│    └── Manage Test Types                                                 │
└─────────────────────────────────────────────────────────────────────────┘
```

---

## ✨ Features

### 👤 People & Drivers
- Full person registry — name, national ID, DOB, address, phone, country, gender
- Add / edit / find / list people with custom `ctrlPersonCardWithFilter` UserControl
- Driver management — linked to person records

### 📋 License Applications
- **New local driving license** — tabbed wizard: Person selection → Application info
- **Renew** expired local driving license
- **Replace** lost or damaged license
- **Retake test** for failed applicants
- **New international license** — requires active Class 3 local license, 1-year validity
- List, filter, cancel, delete, and view all applications
- Smart context menu — dynamically enables/disables actions based on application status

### 🧪 Tests & Scheduling
- 3 sequential tests per application: **Vision → Written → Street**
- Schedule test appointments per test type
- Take test — record pass/fail result
- Sequential enforcement: can't take written until vision passes, etc.

### 🪪 Licenses
- Issue driving license (first time — after passing all 3 tests)
- View license info and full history per person
- Local and international license info screens
- Detain and release licenses with confirmation

### 👥 User Management
- Full CRUD on system users
- Change password
- Current user info and account settings
- Login with username + password

### 📊 Application Types & Test Types Management
- Edit fees for each application type
- Manage test type definitions

---

## 🗂️ Solution Structure (3 Projects)

```
DVLD Project Version 1.0.sln
│
├── DVLD Project Version 1.0/          [Presentation Layer — WinForms]
│   ├── frmMain.cs                     # MDI main window + menu navigation
│   ├── Login/
│   │   └── frmLogin.cs                # Login screen
│   ├── People/
│   │   ├── frmListPeople.cs           # List with filter
│   │   ├── frmAddUpdatePerson.cs      # Add/Edit person
│   │   ├── frmFindPerson.cs           # Find by national ID
│   │   ├── frmShowPersonInfo.cs       # Full person card
│   │   └── Controls/
│   │       ├── ctrlPersonCard.cs          # Reusable person info display
│   │       └── ctrlPersonCardWithFilter.cs # Filter + select person UserControl
│   ├── Applications/
│   │   ├── Application Types/         # List + edit application fees
│   │   ├── Controls/
│   │   │   └── ctrlApplicationBasicInfo.cs  # Reusable application info panel
│   │   ├── LocalDrivingLicenseApplications/
│   │   │   ├── frmAddUpdateLocalDrivingLicenseApplication.cs
│   │   │   ├── frmListLocalDrivingLicenseApplications.cs
│   │   │   ├── frmLocalDrivingLicenseApplicationInfo.cs
│   │   │   └── ctrlDrivingLicenseApplicationInfo.cs
│   │   ├── International License/
│   │   ├── Release Detained License Application/
│   │   ├── Renew Local License/
│   │   └── ReplaceLostOrDemagedLicense/
│   ├── Licenses/
│   │   ├── Local Licenses/            # Issue, show, controls with filter
│   │   ├── International License/     # Show international license info
│   │   ├── Detained License/          # Detain screen
│   │   └── frmShowPersonLicenseHistory.cs
│   ├── Drivers/
│   │   └── frmListDrivers.cs
│   ├── Test/
│   │   ├── frmListTestAppointment.cs  # Schedule test per type
│   │   ├── frmScheduleTest.cs
│   │   ├── frmTakeTest.cs
│   │   ├── Test Types/                # List + edit test types
│   │   └── Controls/                  # ctrlScheduleTest, ctrlScheduledTest
│   ├── Users/
│   │   ├── frmManageUsers.cs
│   │   ├── frmAddUpdateUser.cs
│   │   ├── frmUserInfo.cs
│   │   ├── frmChangePassword.cs
│   │   └── ctrlUserCard.cs
│   └── Global Classes/
│       ├── clsGlobal.cs               # CurrentUser session object
│       ├── clsUtil.cs
│       └── clsValidation.cs
│
├── DVLD-BusinessLayer/                [Business Logic Layer]
│   ├── clsApplications.cs             # Base application class + enums
│   ├── clsApplicationTypes.cs         # Application type fees management
│   ├── clsLocalDrivingLicenseApplication.cs  # Full driving license workflow
│   ├── clsLicense.cs                  # Local license
│   ├── clsLicenseClass.cs             # License classes (motorcycle, car, truck...)
│   ├── clsInternationalLicense.cs     # International license (extends Application)
│   ├── clsDetainLicense.cs            # License detention
│   ├── clsPerson.cs                   # Person entity
│   ├── clsDriver.cs                   # Driver entity (linked to Person)
│   ├── clsUser.cs                     # System user
│   ├── clsTest.cs                     # Test result
│   ├── clsTestAppointment.cs          # Test appointment
│   ├── clsTestTypes.cs                # Vision / Written / Street
│   └── clsCountry.cs                  # Country lookup
│
└── DVLD-DataAccessLayer/              [Data Access Layer]
    ├── clsDataAccessSettings.cs       # Connection string
    ├── clsPersonData.cs
    ├── clsDriverData.cs
    ├── clsUserData.cs
    ├── clsApplicationData.cs
    ├── clsApplicationTypesData.cs
    ├── clsLocalDrivingLicenseApplicationData.cs
    ├── clsLicenseData.cs
    ├── clsLicenseClassData.cs
    ├── clsInternationalLicensesData.cs
    ├── clsDetainedLicenseData.cs
    ├── clsTestData.cs
    ├── clsTestAppointmentData.cs
    ├── clsTestTypesData.cs
    └── clsCountryData.cs
```

---

## 🧱 3-Layer Architecture

```
┌────────────────────────────────────────────────────────────────┐
│            PRESENTATION LAYER (WinForms)                       │
│  frmMain (MDI) → all frm* and ctrl* forms/controls            │
│  → Calls Business Layer classes only                           │
└───────────────────────────┬────────────────────────────────────┘
                            │ depends on
┌───────────────────────────▼────────────────────────────────────┐
│              BUSINESS LOGIC LAYER                              │
│  clsApplications ──► clsLocalDrivingLicenseApplication        │
│  clsLicense, clsInternationalLicense, clsDetainLicense        │
│  clsPerson, clsDriver, clsUser                                 │
│  clsTest, clsTestAppointment, clsTestTypes                    │
│  → Calls Data Access Layer only                                │
└───────────────────────────┬────────────────────────────────────┘
                            │ depends on
┌───────────────────────────▼────────────────────────────────────┐
│              DATA ACCESS LAYER                                 │
│  Raw SQL via SqlConnection / SqlCommand                        │
│  Parameterized queries (SQL injection safe)                    │
│  → Talks directly to SQL Server                                │
└───────────────────────────┬────────────────────────────────────┘
                            │ queries
┌───────────────────────────▼────────────────────────────────────┐
│                     SQL SERVER DATABASE                        │
│  People · Drivers · Users · Licenses · LicenseClasses         │
│  Applications · LocalDrivingLicenseApplications               │
│  InternationalLicenses · DetainedLicenses                     │
│  Tests · TestAppointments · TestTypes · ApplicationTypes      │
└────────────────────────────────────────────────────────────────┘
```

---

## 🔄 License Application Workflow

```
Register Person
      │
      ▼
New Local Driving License Application
      │
      ▼
Schedule Vision Test → Take Test
      │ Pass
      ▼
Schedule Written Test → Take Test
      │ Pass
      ▼
Schedule Street Test → Take Test
      │ Pass
      ▼
Issue Local Driving License 🪪
      │
      ├──► Renew (when expired)
      ├──► Replace (lost/damaged)
      ├──► Detain → Release
      └──► Issue International License (Class 3 only, 1-year validity)
```

---

## 🧩 Custom UserControls

One of the strongest design decisions in this project — reusable UserControls that encapsulate both UI and logic:

| UserControl | Used In | Purpose |
|---|---|---|
| `ctrlPersonCard` | Show person info screens | Displays full person details (name, DOB, national ID, phone, address, gender avatar) |
| `ctrlPersonCardWithFilter` | Add application, find person | Search by national ID + display card — raises `OnPersonSelected` event |
| `ctrlApplicationBasicInfo` | Application detail screens | Shows application ID, status, fees, date, applicant, created by |
| `ctrlDrivingLicenseApplicationInfo` | Local DL app screens | Shows DL app info + embeds `ctrlApplicationBasicInfo` |
| `ctrlDriverLicenseInfo` | License screens | Displays full local license details |
| `ctrlDriverLicenseInfoWithFilter` | International license screen | Search by license ID + display — raises `OnLicenseSelected` event |
| `ctrlDriverInternationalLicenseInfo` | International license screens | Displays international license details |
| `ctrlDriverLicenses` | Person license history | Shows all licenses for a driver |
| `ctrlScheduleTest` | Schedule test screen | Schedule a test appointment |
| `ctrlScheduledTest` | Test appointment screen | Shows a scheduled test with result |
| `ctrlUserCard` | User management screens | Displays user details |

---

## 🚀 Getting Started

### Prerequisites
- **Visual Studio 2019+**
- **SQL Server** (Express or full) + **SSMS**
- **.NET Framework 4.7.2**

### Setup

1. Restore or create the DVLD SQL Server database
2. Update the connection string in `DVLD-DataAccessLayer/clsDataAccessSettings.cs`:
   ```csharp
   public static string connectionString =
       "Server=YOUR_SERVER;Database=DVLD;User Id=YOUR_USER;Password=YOUR_PASSWORD;";
   ```
   > ⚠️ Never commit this file with real credentials. Add it to `.gitignore` or use `App.config`.

3. Open `DVLD Project Version 1.0.sln` in Visual Studio
4. Set **DVLD Project Version 1.0** as the startup project
5. Press `Ctrl + F5`

---

## 🎮 Navigation

**Login** → `frmLogin` → `frmMain` (MDI container with full MenuStrip)

All screens open as `ShowDialog()` from the main menu — each module is self-contained.

---

## 🔐 Credential Persistence — Windows Registry

The `clsGlobal` class includes a **Remember Me** feature that stores login credentials in the Windows Registry instead of a plain file:

```csharp
// Save credentials
Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\DVLD", "Username", username);
Registry.SetValue(@"HKEY_CURRENT_USER\SOFTWARE\DVLD", "Password", password);

// Load credentials
string user = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\DVLD", "UserName", null) as string;
string pass = Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\DVLD", "Password", null) as string;
```

| Method | Description |
|---|---|
| `RememberUsernameAndPassword(user, pass)` | Writes credentials to `HKEY_CURRENT_USER\SOFTWARE\DVLD` |
| `GetStoredCredential(ref user, ref pass)` | Reads stored credentials back on app startup |

> ⚠️ **Security note:** Credentials are stored as plain strings in the registry. For production, consider encrypting using `ProtectedData` (DPAPI) before writing.

---

## 🛠️ Technologies Used

- **Language:** C# (.NET Framework 4.7.2)
- **UI:** Windows Forms — Forms, UserControls, MDI, MenuStrip, DataGridView, TabControl, ContextMenuStrip, ErrorProvider, LinkLabel
- **Database:** SQL Server (`System.Data.SqlClient`) — parameterized queries
- **Storage:** Windows Registry (`Microsoft.Win32`) — credential persistence
- **Architecture:** 3-Layer / N-Tier — 3 separate `.csproj` DLL projects
- **Pattern:** Static Factory, Private Constructor, Mode-based Save (Add/Update), Event-driven UserControls, Global session object

---

## 🔮 Possible Improvements

- [ ] Move connection string to `App.config` and add to `.gitignore`
- [ ] Hash or encrypt stored credentials — use `ProtectedData` (DPAPI) instead of plain registry strings
- [ ] Add **password hashing** for DB-stored passwords (currently plain text)
- [ ] Add **audit log** — track who did what and when
- [ ] Add **reports** — generate PDF license stats, application summaries
- [ ] Add **async/await** for DB calls to prevent UI freezing
- [ ] Replace `system()` calls and make fully cross-platform
- [ ] Migrate to **Entity Framework** or **stored procedures** for cleaner DAL

---

## 👨‍💻 Author

> Built with ❤️ as a capstone C# enterprise project — simulating a real government licensing department system.

Feel free to fork, star ⭐, or contribute!

---

## 📄 License

This project is licensed under the **MIT License** — free to use and modify.
