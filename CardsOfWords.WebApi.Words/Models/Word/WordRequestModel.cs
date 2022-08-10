using System.ComponentModel.DataAnnotations;

namespace CardsOfWords.WebApi.Words.Models.Word
{
    public class WordRequestModel
    {
        [Required]
        public string OriginalWord { get; set; }
        [Required]
        public string TranslateWord { get; set; }
 
        public string Transcription { get; set; }
        [Required]
        public int WordGroupId { get; set; }

    }
}
