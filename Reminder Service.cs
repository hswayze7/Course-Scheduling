static void Main()
{
    ReminderService.StartReminderService();
    Application.Run(new MainForm()); // Your main application window
}
