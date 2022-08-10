using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardsOfWords.WebApi.Words.Data.Entities
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(650)]
        public string OriginalWord { get; set; }
        [MaxLength(650)]
        public string TranslateWord { get; set; }
        [MaxLength(650)]
        public string Transcription { get; set; }
        public int WordGroupId { get; set; }
        [ForeignKey("WordGroupId")]
        public WordGroup WordGroup { get; set; }
    }
}
