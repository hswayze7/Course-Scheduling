CREATE TABLE Assignments (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    CourseName TEXT NOT NULL,
    AssignmentName TEXT NOT NULL,
    DueDate DATETIME NOT NULL,
    ReminderTime DATETIME NOT NULL
);
