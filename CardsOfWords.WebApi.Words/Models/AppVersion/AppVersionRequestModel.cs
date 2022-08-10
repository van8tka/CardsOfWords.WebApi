using System.ComponentModel.DataAnnotations;

namespace CardsOfWords.WebApi.Words.Models.AppVersion
{
    public class AppVersionRequestModel
    {
        [Required]
        public string ApplicationName { get; set; }
        [Required]
        public string Version { get; set; }
    }
}
