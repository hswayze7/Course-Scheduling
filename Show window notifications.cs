using System.Windows.Forms;

void ShowWindowsNotification(string message)
{
    NotifyIcon notifyIcon = new NotifyIcon()
    {
        Icon = SystemIcons.Information,
        Visible = true
    };
    notifyIcon.ShowBalloonTip(3000, "Assignment Reminder", message, ToolTipIcon.Info);
}
