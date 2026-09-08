# 🚗 DVLD — Driver & Vehicle Licensing Department System

![C#](https://img.shields.io/badge/Language-C%23-purple?style=flat-square&logo=csharp)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-CC2927?style=flat-square&logo=microsoftsqlserver)
![WinForms](https://img.shields.io/badge/UI-Windows%20Forms-blue?style=flat-square)
![Architecture](https://img.shields.io/badge/Architecture-3--Layer%20N--Tier-orange?style=flat-square)
![Framework](https://img.shields.io/badge/Framework-.NET%204.7.2-blueviolet?style=flat-square)
![UserControls](https://img.shields.io/badge/UI-Custom%20UserControls-teal?style=flat-square)
![Status](https://img.shields.io/badge/Status-Complete-brightgreen?style=flat-square)
![License](https://img.shields.io/badge/License-MIT-yellow?style=flat-square)

A full-scale **Driver and Vehicle Licensing Department** desktop application built with C# Windows Forms and SQL Server. Manages the complete lifecycle of driving licenses — from person registration and test scheduling, through license issuance, renewal, detention, and international licensing — all backed by a proper **3-layer (N-Tier) architecture** across **four** separate Visual Studio projects.

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

## 🗂️ Solution Structure (4 Projects)

```
Directory structure:
└── bashichda-dvld-v1.0/
    ├── README.md
    ├── DVLD Project Version 1.0.sln
    ├── DVLD Project Version 1.0/
    │   ├── App.config
    │   ├── DVLD Project Version 1.0.csproj
    │   ├── frmMain.cs
    │   ├── frmMain.Designer.cs
    │   ├── frmMain.resx
    │   ├── Program.cs
    │   ├── Applications/
    │   │   ├── Application Types/
    │   │   │   ├── frmApplicationTypes.cs
    │   │   │   ├── frmApplicationTypes.Designer.cs
    │   │   │   ├── frmApplicationTypes.resx
    │   │   │   ├── frmUpdateApplicationType.cs
    │   │   │   ├── frmUpdateApplicationType.Designer.cs
    │   │   │   └── frmUpdateApplicationType.resx
    │   │   ├── Controls/
    │   │   │   ├── ctrlApplicationBasicInfo.cs
    │   │   │   ├── ctrlApplicationBasicInfo.Designer.cs
    │   │   │   └── ctrlApplicationBasicInfo.resx
    │   │   ├── International License/
    │   │   │   ├── frmInternationalLicense.cs
    │   │   │   ├── frmInternationalLicense.Designer.cs
    │   │   │   ├── frmInternationalLicense.resx
    │   │   │   ├── frmListInternationalLicenses.cs
    │   │   │   ├── frmListInternationalLicenses.Designer.cs
    │   │   │   └── frmListInternationalLicenses.resx
    │   │   ├── LocalDrivingLicenseApplications/
    │   │   │   ├── ctrlDrivingLicenseApplicationInfo.cs
    │   │   │   ├── ctrlDrivingLicenseApplicationInfo.Designer.cs
    │   │   │   ├── ctrlDrivingLicenseApplicationInfo.resx
    │   │   │   ├── frmAddUpdateLocalDrivingLicenseApplication.cs
    │   │   │   ├── frmAddUpdateLocalDrivingLicenseApplication.Designer.cs
    │   │   │   ├── frmAddUpdateLocalDrivingLicenseApplication.resx
    │   │   │   ├── frmListLocalDrivingLicenseApplications.cs
    │   │   │   ├── frmListLocalDrivingLicenseApplications.Designer.cs
    │   │   │   ├── frmListLocalDrivingLicenseApplications.resx
    │   │   │   ├── frmLocalDrivingLicenseApplicationInfo.cs
    │   │   │   ├── frmLocalDrivingLicenseApplicationInfo.Designer.cs
    │   │   │   └── frmLocalDrivingLicenseApplicationInfo.resx
    │   │   ├── Release Detained License Application/
    │   │   │   ├── frmListDetainedLicense.cs
    │   │   │   ├── frmListDetainedLicense.Designer.cs
    │   │   │   ├── frmListDetainedLicense.resx
    │   │   │   ├── frmReleaseDetainedLicense.cs
    │   │   │   ├── frmReleaseDetainedLicense.Designer.cs
    │   │   │   └── frmReleaseDetainedLicense.resx
    │   │   ├── Renew Local License/
    │   │   │   ├── frmRenewLocalDrivingLicenseApplication.cs
    │   │   │   ├── frmRenewLocalDrivingLicenseApplication.Designer.cs
    │   │   │   └── frmRenewLocalDrivingLicenseApplication.resx
    │   │   └── ReplaceLostOrDemagedLicense/
    │   │       ├── frmReplaceLostOrDemagedLicense.cs
    │   │       ├── frmReplaceLostOrDemagedLicense.Designer.cs
    │   │       └── frmReplaceLostOrDemagedLicense.resx
    │   ├── Drivers/
    │   │   ├── frmListDrivers.cs
    │   │   ├── frmListDrivers.Designer.cs
    │   │   └── frmListDrivers.resx
    │   ├── Global Classes/
    │   │   ├── clsGlobal.cs
    │   │   ├── clsUtil.cs
    │   │   └── clsValidation.cs
    │   ├── Licenses/
    │   │   ├── frmShowPersonLicenseHistory.cs
    │   │   ├── frmShowPersonLicenseHistory.Designer.cs
    │   │   ├── frmShowPersonLicenseHistory.resx
    │   │   ├── Controls/
    │   │   │   ├── ctrlDriverLicenses.cs
    │   │   │   ├── ctrlDriverLicenses.Designer.cs
    │   │   │   └── ctrlDriverLicenses.resx
    │   │   ├── Detained License/
    │   │   │   ├── frmDetainLicense.cs
    │   │   │   ├── frmDetainLicense.Designer.cs
    │   │   │   └── frmDetainLicense.resx
    │   │   ├── International License/
    │   │   │   ├── frmDriverShowInternationalLicenseInfo.cs
    │   │   │   ├── frmDriverShowInternationalLicenseInfo.Designer.cs
    │   │   │   ├── frmDriverShowInternationalLicenseInfo.resx
    │   │   │   └── Control/
    │   │   │       ├── ctrlDriverInternationalLicenseInfo.cs
    │   │   │       ├── ctrlDriverInternationalLicenseInfo.Designer.cs
    │   │   │       └── ctrlDriverInternationalLicenseInfo.resx
    │   │   └── Local Licenses/
    │   │       ├── frmIssueDriverLicenseFirstTime.cs
    │   │       ├── frmIssueDriverLicenseFirstTime.Designer.cs
    │   │       ├── frmIssueDriverLicenseFirstTime.resx
    │   │       ├── frmShowDriverLicenseInfo.cs
    │   │       ├── frmShowDriverLicenseInfo.Designer.cs
    │   │       ├── frmShowDriverLicenseInfo.resx
    │   │       └── Controls/
    │   │           ├── ctrlDriverLicenseInfo.cs
    │   │           ├── ctrlDriverLicenseInfo.Designer.cs
    │   │           ├── ctrlDriverLicenseInfo.resx
    │   │           ├── ctrlDriverLicenseInfoWithFilter.cs
    │   │           ├── ctrlDriverLicenseInfoWithFilter.Designer.cs
    │   │           └── ctrlDriverLicenseInfoWithFilter.resx
    │   ├── Login/
    │   │   ├── frmLogin.cs
    │   │   ├── frmLogin.Designer.cs
    │   │   └── frmLogin.resx
    │   ├── People/
    │   │   ├── frmAddUpdatePerson.cs
    │   │   ├── frmAddUpdatePerson.Designer.cs
    │   │   ├── frmAddUpdatePerson.resx
    │   │   ├── frmFindPerson.cs
    │   │   ├── frmFindPerson.Designer.cs
    │   │   ├── frmFindPerson.resx
    │   │   ├── frmListPeople.cs
    │   │   ├── frmListPeople.Designer.cs
    │   │   ├── frmListPeople.resx
    │   │   ├── frmShowPersonInfo.cs
    │   │   ├── frmShowPersonInfo.Designer.cs
    │   │   ├── frmShowPersonInfo.resx
    │   │   └── Controls/
    │   │       ├── ctrlPersonCard.cs
    │   │       ├── ctrlPersonCard.Designer.cs
    │   │       ├── ctrlPersonCard.resx
    │   │       ├── ctrlPersonCardWithFilter.cs
    │   │       ├── ctrlPersonCardWithFilter.Designer.cs
    │   │       └── ctrlPersonCardWithFilter.resx
    │   ├── Properties/
    │   │   ├── AssemblyInfo.cs
    │   │   ├── Resources.Designer.cs
    │   │   ├── Resources.resx
    │   │   ├── Settings.Designer.cs
    │   │   └── Settings.settings
    │   ├── Test/
    │   │   ├── frmListTestAppointment.cs
    │   │   ├── frmListTestAppointment.Designer.cs
    │   │   ├── frmListTestAppointment.resx
    │   │   ├── frmScheduleTest.cs
    │   │   ├── frmScheduleTest.Designer.cs
    │   │   ├── frmScheduleTest.resx
    │   │   ├── frmTakeTest.cs
    │   │   ├── frmTakeTest.Designer.cs
    │   │   ├── frmTakeTest.resx
    │   │   ├── Controls/
    │   │   │   ├── ctrlScheduledTest.cs
    │   │   │   ├── ctrlScheduledTest.Designer.cs
    │   │   │   ├── ctrlScheduledTest.resx
    │   │   │   ├── ctrlScheduleTest.cs
    │   │   │   ├── ctrlScheduleTest.Designer.cs
    │   │   │   └── ctrlScheduleTest.resx
    │   │   └── Test Types/
    │   │       ├── frmEditTestTypes.cs
    │   │       ├── frmEditTestTypes.Designer.cs
    │   │       ├── frmEditTestTypes.resx
    │   │       ├── frmListTestTypes.cs
    │   │       ├── frmListTestTypes.Designer.cs
    │   │       └── frmListTestTypes.resx
    │   └── Users/
    │       ├── ctrlUserCard.cs
    │       ├── ctrlUserCard.Designer.cs
    │       ├── ctrlUserCard.resx
    │       ├── frmAddUpdateUser.cs
    │       ├── frmAddUpdateUser.Designer.cs
    │       ├── frmAddUpdateUser.resx
    │       ├── frmChangePassword.cs
    │       ├── frmChangePassword.Designer.cs
    │       ├── frmChangePassword.resx
    │       ├── frmManageUsers.cs
    │       ├── frmManageUsers.Designer.cs
    │       ├── frmManageUsers.resx
    │       ├── frmUserInfo.cs
    │       ├── frmUserInfo.Designer.cs
    │       └── frmUserInfo.resx
    ├── DVLD-BusinessLayer/
    │   ├── clsApplications.cs
    │   ├── clsApplicationTypes.cs
    │   ├── clsCountry.cs
    │   ├── clsDetainLicense.cs
    │   ├── clsDriver.cs
    │   ├── clsInternationalLicense.cs
    │   ├── clsLicense.cs
    │   ├── clsLicenseClass.cs
    │   ├── clsLocalDrivingLicenseApplication.cs
    │   ├── clsPerson.cs
    │   ├── clsTest.cs
    │   ├── clsTestAppointment.cs
    │   ├── clsTestTypes.cs
    │   ├── clsUser.cs
    │   ├── DVLD-BusinessLayer.csproj
    │   └── Properties/
    │       └── AssemblyInfo.cs
    ├── DVLD-DataAccessLayer/
    │   ├── clsApplicationData.cs
    │   ├── clsApplicationTypesData.cs
    │   ├── clsCountryData.cs
    │   ├── clsDataAccessSettings.cs
    │   ├── clsDetainedLicenseData.cs
    │   ├── clsDriverData.cs
    │   ├── clsInternationalLicensesData.cs
    │   ├── clsLicenseClassData.cs
    │   ├── clsLicenseData.cs
    │   ├── clsLocalDrivingLicenseApplicationData.cs
    │   ├── clsPersonData.cs
    │   ├── clsTestAppointmentData.cs
    │   ├── clsTestData.cs
    │   ├── clsTestTypesData.cs
    │   ├── clsUserData.cs
    │   ├── DVLD-DataAccessLayer.csproj
    │   └── Properties/
    │       └── AssemblyInfo.cs
    └── DVLD_Common/
        ├── clsEventLog.cs
        ├── DVLD_Common.csproj
        └── Properties/
            └── AssemblyInfo.cs

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
2. Copy `App.config.example` to `App.config` in the Presentation Layer project and fill in your credentials:
   ```csharp
   public static string connectionString =
       "Server=YOUR_SERVER;Database=DVLD;User Id=YOUR_USER;Password=YOUR_PASSWORD;";
   ```
   > ⚠️ Never commit this file with real credentials. Add it to `.gitignore` or use `App.config`.

3. Open `DVLD Project Version 1.0.sln
│
├── DVLD_Common/                       [Shared Layer — Utilities]
│   └── clsEventLog.cs                 # Centralized exception logger (Windows Event Log)` in Visual Studio
4. Set **DVLD Project Version 1.0** as the startup project
5. Press `Ctrl + F5`

---

## 🎮 Navigation

**Login** → `frmLogin` → `frmMain` (MDI container with full MenuStrip)

All screens open as `ShowDialog()` from the main menu — each module is self-contained.

---

## 📋 Exception Logging — Windows Event Log

All `try/catch` blocks across all 3 layers log exceptions to the **Windows Event Log** under a custom source `"DVLD"` — giving you a persistent, system-level audit trail of every runtime error without needing an external logging framework.

```csharp
catch (Exception ex)
{
    if (!EventLog.SourceExists("DVLD"))
        EventLog.CreateEventSource("DVLD", "Application");

    EventLog.WriteEntry("DVLD", ex.Message, EventLogEntryType.Error);
    // ... handle error
}
```

**Coverage — every layer logs:**

| Layer | What gets logged |
|---|---|
| `clsGlobal.cs` (Presentation) | Registry read/write failures |
| `clsPersonData.cs` (DAL) | SQL failures on person queries |
| `clsLicenseData.cs` (DAL) | SQL failures on license queries |
| All other `*Data.cs` files | Any DB exception in any CRUD operation |

**How to view logs:**
1. Press `Win + R` → type `eventvwr.msc` → Enter
2. Navigate to **Windows Logs → Application**
3. Filter by Source: `DVLD`

> ⚠️ `EventLog.CreateEventSource()` requires **Administrator privileges** on first run. After the source is created once, normal user rights are sufficient for writing.

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
- **Config:** `App.config` + `ConfigurationManager` — connection string outside source code
- **Storage:** Windows Registry (`Microsoft.Win32`) — credential persistence
- **Logging:** Windows Event Log (`System.Diagnostics.EventLog`) — exception audit trail
- **Architecture:** 3-Layer / N-Tier — 3 separate `.csproj` DLL projects
- **Pattern:** Static Factory, Private Constructor, Mode-based Save (Add/Update), Event-driven UserControls, Global session object

---

## 🔮 Possible Improvements

- [ ] Replace plain `sa` credentials with a dedicated SQL Server user with minimal permissions
- [ ] Hash or encrypt stored credentials — use `ProtectedData` (DPAPI) instead of plain registry strings
- [ ] Add **password hashing** for DB-stored passwords (currently plain text)
- [ ] Add **audit log** — track who did what and when (event log covers errors; extend to user actions)
- [ ] Wrap `EventLog.CreateEventSource()` in app installer to avoid needing admin on first run
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
