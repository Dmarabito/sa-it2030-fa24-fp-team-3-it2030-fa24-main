namespace sa_it2030_fa24_fp_team_3_it2030_fa24.Models
{
    public class Message
    {
      public int Id { get; set; }
      public string Page {  get; set; }
      public string Nickname {  get; set; }
      public string Body { get; set; }
      public DateTime SentTime { get; set; }
    }
}
