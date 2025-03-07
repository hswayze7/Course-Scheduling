List<Assignment> GetUpcomingAssignments()
{
    List<Assignment> assignments = new List<Assignment>();
    using (var conn = new SQLiteConnection("Data Source=database.db;Version=3;"))
    {
        conn.Open();
        var cmd = new SQLiteCommand("SELECT * FROM Assignments WHERE ReminderTime <= @now", conn);
        cmd.Parameters.AddWithValue("@now", DateTime.Now);
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            assignments.Add(new Assignment
            {
                Id = Convert.ToInt32(reader["Id"]),
                CourseName = reader["CourseName"].ToString(),
                AssignmentName = reader["AssignmentName"].ToString(),
                DueDate = Convert.ToDateTime(reader["DueDate"]),
                ReminderTime = Convert.ToDateTime(reader["ReminderTime"])
            });
        }
    }
    return assignments;
}
