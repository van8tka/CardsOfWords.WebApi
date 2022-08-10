using System.ComponentModel.DataAnnotations;

namespace CardsOfWords.WebApi.Words.Models.Language
{
    public class LanguageRequestModel
    {
        [Required]
        public string Name { get; set; }
    }
}
