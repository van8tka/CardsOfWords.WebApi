using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardsOfWords.WebApi.Words.Data.Entities;

public class WordGroup
{
    [Key]
    public int Id { get; set; }
    [MaxLength(250)]
    public string Name { get; set; }
    public int LanguageId { get; set; }
    [ForeignKey("LanguageId")]
    public Language Language { get; set; }
    public ICollection<Word> Words { get; set; }
}
