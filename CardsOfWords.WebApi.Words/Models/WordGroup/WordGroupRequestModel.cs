using System.ComponentModel.DataAnnotations;

namespace CardsOfWords.WebApi.Words.Models.WordGroup
{
    public class WordGroupRequestModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int LanguageId { get; set; }
    }
}
