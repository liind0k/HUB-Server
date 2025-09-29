INSERT INTO Departments(
   DepartmentName
)
VALUES
('Computer Science'),
('Information Technology'),
('Informatics'),
('Computer Systems Engineering');

INSERT INTO Campuses(
    CampusName
)
VALUES
('Soshanguve'),
('Emalahleni'),
('Polokwane');

INSERT INTO CampusDepartment (CampusId, DepartmentId, PhoneNumber, Email, DepartmentLocation)
VALUES
((SELECT CampusId FROM Campuses WHERE CampusName='Soshanguve'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Computer Science'),'+27123829938','mollymoche@tut.ac.za','BUILDING 12 ROOM 132 AND 134'),
((SELECT CampusId FROM Campuses WHERE CampusName='Soshanguve'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Information Technology'),'+27123829041','chokoepn@tut.ac.z','BUILDING 12 ROOM 162'),
((SELECT CampusId FROM Campuses WHERE CampusName='Soshanguve'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Informatics'),'+27123829027','vanrooyenm@tut.ac.za','BUILDING 5 2ND FLOOR'),
((SELECT CampusId FROM Campuses WHERE CampusName='Soshanguve'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Computer Systems Engineering'),'+27123829812','matimake@tut.ac.za','BUILDING 12 ROOM 205');

INSERT INTO CampusDepartment (CampusId, DepartmentId, PhoneNumber, Email, DepartmentLocation)
VALUES
((SELECT CampusId FROM Campuses WHERE CampusName='Polokwane'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Computer Science'),'+27123456789','RankoanaTS@tut.ac.za','BUILDING 1-G247');

INSERT INTO CampusDepartment (CampusID, DepartmentId, PhoneNumber, Email, DepartmentLocation)
VALUES
((SELECT CampusId FROM Campuses WHERE CampusName='Emalahleni'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Computer Science'),'+27123456789','MakhubelaJK@tut.ac.za','BUILDING 14');


INSERT INTO Courses(
   courseCode, CourseName, Duration , NQFLevel ,DepartmentId
)
VALUES
('DPRS20', 'Computer Science', '3 years', 'Diploma', 1),
('DPRSF0', 'Computer Science(Extended)', '4 years', 'Diploma', 1),
('ADRS20', 'Computer Science', '2 years', 'Advanced Diploma', 1),
('DPMC20', 'Multimedia Computing','3 years', 'Diploma', 1),
('DPMCF0', 'Multimedia Computing(Extended)','4 years', 'Diploma', 1),
('ADMC20', 'Multimedia Computing','2 years', 'Advanced Diploma', 1),
('DPIT20', 'Information Technology', '3 years', 'Diploma', 2),
('DPITF0', 'Information Technology(Extended)', '4 years', 'Diploma', 2),
('ADIT20', 'Information Technology', '2 years', 'Advanced Diploma', 2),
('DPIF20', 'Informatics',' 3 years', 'Diploma', 3),
('DPIFF0', 'Informatics(Extended)','4 years', 'Diploma', 3),
('ADIF20', 'Informatics','2 years', 'Advanced Diploma', 3),
('DPYE20', 'Computer Systems Engineering',' 3 years', 'Diploma', 4),
('DPYEF0', 'Computer Systems Engineering(Extended)','4 years', 'Diploma', 4),
('ADYE20', 'Computer Systems Engineering','2 years', 'Advanced Diploma', 4);

INSERT INTO Modules(ModuleCode,ModuleName, Credits)
VALUES
('BCM115D','Business Cost Management', 15),
('BCMF15D','Business Cost Management(Foundation)', 15),
('BFS115D','Business Fundamentals', 15),
('BFSF15D','Business Fundamentals(Foundation)', 15),
('BUA216D','Business Analysis A', 15),
('BUB216D','Business Analysis B', 15),
('DBA216D','Database Management Systems A', 15),
('DBB216D','Database Management Systems B', 15),
('SIS216D','Introduction to Strategic Information Systems', 15),
('SYA216D','System Analysis A', 15),
('SYB216D','System Analysis B', 15),
('ITP216D','IT Project Management A', 15),
('IEA316D','Introduction to Enterprise Architecture', 15),
('ISD316D','Information System Deployment', 15),
('ITP316D','IT Project Management B', 15),
('PCT316D','Process Testing', 15),
('WIL316D','Work-Integrated Learning', 60),
('KWM117V','Knowledge Management',15),
('ITM117V','Information and Technology Management',15),
('PIF117V','Principles of Research',7),
('BAA117V','Business Analysis and Application',15),
('IAR117V','Information Systems Architecture',15),
('ITP117V','Information Technology Project Management',15),
('SIS117V','Strategic Information Systems',15),
('ISR117V','Information System Research',15),
('BAA118G','Advanced Business Analysis and Application',24),
('ARP108G','Advanced Research Project',24),
('ITP118G','Advanced IT Project Management',24),
('KWM118G','Advanced Knowledge Management',24),
('RIF118G','Research Methodology',24),
('FMI118G','','');



INSERT INTO CourseModule(CourseId, ModuleId)
VALUES
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='BCM115D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='BFS115D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='BUA216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='BUB216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='DBA216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='DBB216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='SIS216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='SYB216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='ITP216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='IEA316D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='ISD316D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='ITP316D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='PCT316D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIF20'), (SELECT ModuleId FROM Modules WHERE ModuleCode='WIL316D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='BCMF15D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='BFSF15D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='BUA216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='BUB216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='DBA216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='DBB216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='SIS216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='SYB216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='ITP216D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='IEA316D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='ISD316D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='ITP316D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='PCT316D')),
((SELECT CourseId FROM Courses WHERE CourseCode='DPIFF0'), (SELECT ModuleId FROM Modules WHERE ModuleCode='WIL316D'));

INSERT INTO Contacts(Title, FullName, Email)
VALUES
('Ms.', 'Irene Abraham-Samgeorge ', 'abrahamia@tut.ac.za'),
('Mr.', 'Dimakatso Malebana ', 'malebanadd@tut.ac.za'),
('Dr.', 'Anna Segooa ', 'segooama@tut.ac.za'),
('Dr.', 'Cecile Kgoetiane ', 'kgwetianech@tut.ac.za'),
('Ms.', 'Louise Brand ', 'Brandl@tut.ac.za'),
('Mr.', 'Mashithishi Phurutsi ', 'phurutsimb@tut.ac.za'),
('Dr.', 'Sam Adeyelure ', 'adeyelurets@tut.ac.za'),
('Mr.', 'Hezekiel Mashego', 'mashegohm@tut.ac.za'),
('Dr.', 'Stevens Mamorobela ', 'phaphadi@gmail.com');


INSERT INTO Services( ServiceTitle, ServiceDescription, ServiceUrl, Category )
VALUES 

('Subject additions and cancellations', 'Information about adding or cancelling subjects.', 'https://ienabler.tut.ac.za/pls/prodi41/w99pkg.mi_login', 'senior' ),
('Class & Test Timetables', 'Access your class and test schedules.', 'https://www.tut.ac.za/timetables', 'all' ),
('NO WALK-INS Policy', 'Important policy for new applicants.', 'https://applications-prod.tut.ac.za/', 'newcomer' ),
('Admissions', 'Information about application processes and deadlines.', 'https://applications-prod.tut.ac.za/', 'newcomer' ),
('Bursaries', 'Financial assistance and bursary information.', '', 'all' ),
('Intercampus Transfers', 'Transfers between TUT campuses (Computer Science students only)', 'https://ec.tut.ac.za/', 'senior' ),
('Re-admission', 'Re-admission after break in studies or exclusion.', 'https://ienabler.tut.ac.za/pls/prodi41/w99pkg.mi_login', 'senior' ),
('Special & Exit Examinations', 'Apply for special or exit examinations', 'https://www.tut.ac.za/exit-examination', 'senior' ),
('Probation', 'Handle probation notifications and requirements', '', 'senior' ),
('Other Admission Enquiries', 'Get help with application status, documentation, and campus changes.', '', 'newcomer' ),
('Residence Administration', 'Student accommodation and residence matters.', '', 'all' ),
('Recognition / Examption (CAT)', 'Get Accumulation and Transfer for previous qualifications.', '', 'all' ),
('WIL For Compuer Science', 'Get your WIL placement and requirements.', '', 'senior' ),
('Mentorship & Tutoring program', 'Mentorship program for guidance and support..', 'https://sds.onlinewebshop.net/', 'all' ),
('Studython', 'Studython program for academic support.', '', 'all' ),
('Peer to Peer learning', 'Peer to Peer learning program for academic support.', 'https://sds.onlinewebshop.net/', 'all' ),
('WIL For Informatics', 'Get your WIL placement and requirements.', '', 'senior' ),
('WIL For Information Technology', 'Get your WIL placement and requirements.', '', 'senior' ),
('Change of Course', 'Process for changing your academic course (not admission related).', 'https://ec.tut.ac.za/', 'senior' ),
('Financial Exclusion', 'Assistance with financial exclusion matters.', 'https://ienabler.tut.ac.za/pls/prodi41/w99pkg.mi_login', 'senior' ),
('Academic Exclusions', 'Information and appeals process for academic exclusions.', 'https://ec.tut.ac.za', 'senior' ),
('Mark Enquiries/Predicate Enquiries', 'Get assistance with mark-related queries and academic predicates.', 'https://os.tut.ac.za/ExamsLegacy', 'all' ),
('NSFAS Enquiries', 'National Student Financial Aid Scheme support and information.','https://www.nsfas.org.za', 'senior');

INSERT INTO CampusService(CampusId, ServiceId, Phone, Email, Location)
VALUES
((SELECT CampusId FROM Campuses WHERE CampusName='Soshanguve'), (SELECT ServiceId FROM Services WHERE ServiceTitle='Class & Test Timetables'), '+271234567890', 'admission@tut.ac.za',  'Building 5'),
((SELECT CampusId FROM Campuses WHERE CampusName='Emalahleni'), (SELECT ServiceId FROM Services WHERE ServiceTitle='Class & Test Timetables'), '+271234567890', 'admission@tut.ac.za',  'Building 5'),
((SELECT CampusId FROM Campuses WHERE CampusName='Polokwane'), (SELECT ServiceId FROM Services WHERE ServiceTitle='Class & Test Timetables'), '+271234567890', 'admission@tut.ac.za',  'Building 5'),
((SELECT CampusId FROM Campuses WHERE CampusName='Soshanguve'), (SELECT ServiceId FROM Services WHERE ServiceTitle='NSFAS Enquiries'), '+271234567890', 'info@nsfas.org',  'Building 10'),
((SELECT CampusId FROM Campuses WHERE CampusName='Emalahleni'), (SELECT ServiceId FROM Services WHERE ServiceTitle='NSFAS Enquiries'), '+271234567890', 'info@nsfas.org',  'Building 10'),
((SELECT CampusId FROM Campuses WHERE CampusName='Polokwane'), (SELECT ServiceId FROM Services WHERE ServiceTitle ='NSFAS Enquiries'), '+271234567890', 'info@nsfas.org',  'Building 10');


INSERT INTO Steps(CampusServiceId, StepsTitle, StepsDescription)
VALUES
(1,'Academic Department','Visit the Academic Department for Timetables' ),
(1, 'Issues','Report clashes to the Academic Department urgently'),
(2,'Academic Department','Visit the Academic Department for Timetables'),
(2, 'Issues','Report clashes to the Academic Department urgently'),
(3,'Academic Department','Visit the Academic Department for Timetables'),
(3, 'Issues','Report clashes to the Academic Department urgently'),
(4,'Enquiries','Visit the Financial Aid Office for enquiries'),
(4, 'OneStop','Get signatures from OneStop'),
(4, 'Issues','Visit NSFAS website for other issues'),
(5,'Enquiries','Visit the Financial Aid Office for enquiries'),
(5, 'OneStop','Get signatures from OneStop'),
(5, 'Issues','Visit NSFAS website for other issues'),
(6,'Enquiries','Visit the Financial Aid Office for enquiries'  ),
(6, 'OneStop','Get signatures from OneStop'),
(6, 'Issues','Visit NSFAS website for other issues');
