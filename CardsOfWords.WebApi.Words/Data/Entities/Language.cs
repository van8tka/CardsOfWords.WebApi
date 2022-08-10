using System.ComponentModel.DataAnnotations;

namespace CardsOfWords.WebApi.Words.Data.Entities;

public class Language
{
    [Key]
    public int Id { get; set; }
    [MaxLength(255)]
    public string Name { get; set; }
    public ICollection<WordGroup> WordGroups { get; set; }
}
