using System;
using System.Data.SQLite;

class Program
{
    static void Main()
    {
        using (var conn = new SQLiteConnection("Data Source=database.db;Version=3;"))
        {
            conn.Open();
            var cmd = new SQLiteCommand("SELECT * FROM Assignments", conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Assignment: {reader["AssignmentName"]}, Due: {reader["DueDate"]}");
            }
        }
    }
}
