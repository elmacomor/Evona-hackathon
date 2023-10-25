namespace hackathon_api.Models.DTOs;
public class AchivementsGETDTO
{
    // title, points, icons

    /* achivement data */
    public string Name { get; set; } = string.Empty;
    public string Points { get; set; } = string.Empty;
    public string Icons { get; set; } = string.Empty;
    
    public string TreashHold { get; set; } = string.Empty;

    /* userData */
    public string UserTreashHold { get; set; } = string.Empty;

}
