namespace hackathon_api.Models.DTOs;
public class UsersScoreDTO
{
    public int Rank { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Points { get; set; } 
    public int Level { get; set; }
}
