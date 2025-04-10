using (var conn = new SQLiteConnection("Data Source=database.db;Version=3;"))
{
    conn.Open();
    var cmd = new SQLiteCommand("INSERT INTO Assignments (CourseName, AssignmentName, DueDate, ReminderTime) VALUES (@course, @assignment, @dueDate, @reminder)", conn);
    cmd.Parameters.AddWithValue("@course", courseName);
    cmd.Parameters.AddWithValue("@assignment", assignmentName);
    cmd.Parameters.AddWithValue("@dueDate", dueDate);
    cmd.Parameters.AddWithValue("@reminder", reminderTime);
    cmd.ExecuteNonQuery();
}
