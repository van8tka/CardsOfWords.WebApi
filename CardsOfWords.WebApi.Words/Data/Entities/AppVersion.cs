using System.ComponentModel.DataAnnotations;

namespace CardsOfWords.WebApi.Words.Data.Entities;

public class AppVersion
{
    [Key] 
    public int Id { get; set; }
    [MaxLength(450)]
    public string ApplicationName { get; set; }
    [MaxLength(250)]
   
    public string Version { get; set; }
}
