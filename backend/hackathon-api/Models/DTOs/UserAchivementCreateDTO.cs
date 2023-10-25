namespace hackathon_api.Models.DTOs;

public class UserAchivementCreateDTO
{
    public string UserId { get; set; } = string.Empty;
    public string AchivementType { get; set; } = string.Empty;
    public long GameId { get; set; }
}
