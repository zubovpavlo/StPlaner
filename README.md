BCSH1
Téma:
Jednoduchá databázová aplikace pro správu studijního plánu

Zubov Pavlo										Pardubice
ST67136										16 . 04 . 2025
________________________________________
Popis projektu:
Aplikace umožňuje studentům:
•	Přidávat, upravovat a prohlížet studijní předměty
•	Automaticky generovat plán domácí přípravy podle jednotlivých kurzů
•	Označovat studijní aktivity jako splněné
•	Přihlašovat se a spravovat svůj účet
Data jsou uchovávána ve formátu JSON bez použití externí databáze. Aplikace je vytvořena jako desktopová aplikace pomocí Windows Forms.
________________________________________
Implementované funkce:
•	Registrace a přihlášení uživatelů
•	Správa seznamu předmětů
•	Automatická tvorba rozvrhu na základě kreditové hodnoty
•	Výpočet celkového pokroku v kurzu
•	Možnost označit splněné aktivity
________________________________________
Popis tříd
Student
Reprezentuje entitu studenta.
Atributy:
•	int ID – identifikátor studenta
•	string Name – celé jméno studenta
•	string Username – uživatelské jméno (login)
•	string Password – heslo (nešifrované, pouze pro demonstrační účely)
•	List<int> Courses – seznam ID přiřazených kurzů
Konstruktory:
•	Student() – výchozí konstruktor
•	Student(int id, string name, string username, string password) – konstruktor s validací vstupů
________________________________________
Course
Reprezentuje studijní předmět.
Atributy:
•	int ID
•	string Name
•	int ECTS
•	DateTime StartDate, EndDate
•	string Status – například "aktivní"
•	List<StudySchedule> StudySchedules – seznam aktivit
•	double Progress – vypočítaný pokrok (v procentech)
Konstruktory:
•	Course()
•	Course(int id, string name, int ects, DateTime startDate, DateTime endDate, string status)
Metody:
•	CalculateProgress() – vypočítává pokrok na základě dokončených aktivit
________________________________________
StudySchedule
Reprezentuje jednotlivou studijní aktivitu v rámci předmětu.
Atributy:
•	int ID
•	DateTime Date
•	int CourseID
•	string CourseName
•	double StudyHours
•	bool Completed
Konstruktory:
•	StudySchedule()
•	StudySchedule(int id, DateTime date, int courseId, string courseName, double studyHours, bool completed)
________________________________________
AuthenticationService
Zajišťuje autentizaci a správu uživatelských účtů.
Metody:
•	Authenticate(string username, string password) – ověřuje přihlášení
•	GetCurrentUser() – vrací aktuálně přihlášeného uživatele
•	Logout() – odhlášení
•	RegisterStudent(Student student) – registrace nového uživatele
•	DeleteStudent(Student student) – odstranění účtu
•	IsUsernameTaken(string username) – kontrola dostupnosti uživatelského jména
•	GetNextStudentID() – generování nového ID
________________________________________
ScheduleService
Zajišťuje tvorbu a úpravu studijního rozvrhu.
Metody:
•	GenerateStudySchedule(Course course) – generuje plán aktivit
•	UpdateStudySchedule(Course course, List<StudySchedule> existingSchedules) – aktualizuje plán kurzu
________________________________________
JsonDataManager
Statická třída pro práci s lokálně uloženými daty ve formátu JSON.
Metody:
•	LoadStudents(), SaveStudents()
•	LoadCourses(), SaveCourses()
•	LoadStudySchedules(), SaveStudySchedules()
•	LoadData<T>(), SaveData<T>() – privátní generické metody pro načtení a zápis
________________________________________
DateTimeUtils
Pomocná třída pro práci s daty a časem.
Metody:
•	CalculateDaysBetween(DateTime start, DateTime end) – počet dnů mezi dvěma daty
•	FormatStudyHours(double studyHours) – formátování počtu hodin do čitelné podoby
•	GetCzechHolidays(int year) – seznam státních svátků v ČR
________________________________________
Program
Hlavní třída aplikace.
Metoda:
•	Main() – vstupní bod programu, spouští formulář LoginForm
________________________________________
