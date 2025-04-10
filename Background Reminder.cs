using System.Timers;

class ReminderService
{
    private static Timer reminderTimer;

    public static void StartReminderService()
    {
        reminderTimer = new Timer(60000); // Check every 60 seconds
        reminderTimer.Elapsed += CheckReminders;
        reminderTimer.AutoReset = true;
        reminderTimer.Start();
    }

    private static void CheckReminders(object sender, ElapsedEventArgs e)
    {
        var upcomingAssignments = GetUpcomingAssignments();
        foreach (var assignment in upcomingAssignments)
        {
            ShowNotification(assignment);
        }
    }

    private static void ShowNotification(Assignment assignment)
    {
        Console.WriteLine($"Reminder: {assignment.AssignmentName} for {assignment.CourseName} is due on {assignment.DueDate}");
        // Optionally, trigger a pop-up notification in Windows
    }
}
