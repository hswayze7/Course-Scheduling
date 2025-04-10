using System.Diagnostics;

public static void ShowMacNotification(string title, string message)
{
    string script = $"osascript -e 'display notification \"{message}\" with title \"{title}\"'";
    Process.Start("/bin/bash", $"-c \"{script}\"");
}

// Example Usage:
ShowMacNotification("Assignment Reminder", "Your assignment for CS101 is due tomorrow!");
