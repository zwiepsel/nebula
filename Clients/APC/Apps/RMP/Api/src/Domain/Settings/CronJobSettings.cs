namespace Nebula.Clients.APC.Apps.RMP.Api.Domain.Settings;

public class CronJobSettings
{
    public string SendEmailMessagesCronExpression { get; set; } = null!;
    public string SendEmailMessagesNotificationUri { get; set; } = null!;
    public string SendRiskRemindersCronExpression { get; set; } = null!;
    public string SendRiskRemindersNotificationUri { get; set; } = null!;
}