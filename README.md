# StPlaner

**Jednoduchá databázová aplikace pro správu studijního plánu**

## Popis projektu

Aplikace umožňuje studentům:

- Přidávat, upravovat a prohlížet studijní předměty  
- Automaticky generovat plán domácí přípravy podle jednotlivých kurzů  
- Označovat studijní aktivity jako splněné  
- Přihlašovat se a spravovat svůj účet  

Data jsou uchovávána ve formátu **JSON** bez použití externí databáze.  
Aplikace je vytvořena jako desktopová aplikace pomocí **Windows Forms** (C#, .NET Framework).

## Implementované funkce

- Registrace a přihlášení uživatelů  
- Správa seznamu předmětů  
- Automatická tvorba rozvrhu na základě kreditové hodnoty  
- Výpočet celkového pokroku v kurzu  
- Možnost označit splněné aktivity  

## Popis tříd

### Student
Reprezentuje entitu studenta.

**Atributy:**
- `int ID`
- `string Name`
- `string Username`
- `string Password`
- `List<int> Courses`

**Konstruktory:**
- `Student()`
- `Student(int id, string name, string username, string password)`

### Course
Reprezentuje studijní předmět.

**Atributy:**
- `int ID`
- `string Name`
- `int ECTS`
- `DateTime StartDate`, `EndDate`
- `string Status`
- `List<StudySchedule> StudySchedules`
- `double Progress`

**Konstruktory:**
- `Course()`
- `Course(int id, string name, int ects, DateTime startDate, DateTime endDate, string status)`

**Metody:**
- `CalculateProgress()`

### StudySchedule
Reprezentuje jednotlivou studijní aktivitu v rámci předmětu.

**Atributy:**
- `int ID`
- `DateTime Date`
- `int CourseID`
- `string CourseName`
- `double StudyHours`
- `bool Completed`

**Konstruktory:**
- `StudySchedule()`
- `StudySchedule(int id, DateTime date, int courseId, string courseName, double studyHours, bool completed)`

### AuthenticationService

**Metody:**
- `Authenticate(string username, string password)`
- `GetCurrentUser()`
- `Logout()`
- `RegisterStudent(Student student)`
- `DeleteStudent(Student student)`
- `IsUsernameTaken(string username)`
- `GetNextStudentID()`

### ScheduleService

**Metody:**
- `GenerateStudySchedule(Course course)`
- `UpdateStudySchedule(Course course, List<StudySchedule> existingSchedules)`

### JsonDataManager

**Metody:**
- `LoadStudents()`, `SaveStudents()`
- `LoadCourses()`, `SaveCourses()`
- `LoadStudySchedules()`, `SaveStudySchedules()`
- `LoadData<T>()`, `SaveData<T>()`

### DateTimeUtils

**Metody:**
- `CalculateDaysBetween(DateTime start, DateTime end)`
- `FormatStudyHours(double studyHours)`
- `GetCzechHolidays(int year)`

### Program

**Metoda:**
- `Main()` – vstupní bod programu, spouští `LoginForm`
