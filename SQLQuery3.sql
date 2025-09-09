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

INSERT INTO CampusDepartment (CampusId, DepartmentId)
VALUES
((SELECT CampusId FROM Campuses WHERE CampusName='Soshanguve'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Computer Science')),
((SELECT CampusId FROM Campuses WHERE CampusName='Soshanguve'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Information Technology')),
((SELECT CampusId FROM Campuses WHERE CampusName='Soshanguve'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Informatics')),
((SELECT CampusId FROM Campuses WHERE CampusName='Soshanguve'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Computer Systems Engineering'));

INSERT INTO CampusDepartment (CampusId, DepartmentId)
VALUES
((SELECT CampusId FROM Campuses WHERE CampusName='Polokwane'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Computer Science'));

INSERT INTO CampusDepartment (CampusID, DepartmentId)
VALUES
((SELECT CampusId FROM Campuses WHERE CampusName='Emalahleni'), (SELECT DepartmentId FROM Departments WHERE DepartmentName='Computer Science'));

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


INSERT INTO Services( ServiceTitle, ServiceDescription, ServiceUrl, Category )
VALUES 

('Class & Test Timetables', 'Access your class and test schedules.', 'https://www.tut.ac.za/timetables', 'all' ),
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
(2,'Enquiries','Visit the Financial Aid Office for enquiries'  ),
(2, 'Enquiries','Visit the Financial Aid Office for enquiries'),
(2, 'OneStop','Get signatures from OneStop'),
(2, 'Issues','Visit NSFAS website for other issues'),
(1,'Enquiries','Visit the Financial Aid Office for enquiries'  ),
(1, 'Enquiries','Visit the Financial Aid Office for enquiries'),
(1, 'OneStop','Get signatures from OneStop'),
(1, 'Issues','Visit NSFAS website for other issues'),
(3,'Enquiries','Visit the Financial Aid Office for enquiries'  ),
(3, 'Enquiries','Visit the Financial Aid Office for enquiries'),
(3, 'OneStop','Get signatures from OneStop'),
(3, 'Issues','Visit NSFAS website for other issues');