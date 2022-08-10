namespace CardsOfWords.WebApi.Words.Models.Word
{
    public class WordResponseModel
    {
        public int Id { get; set; }
        public string OriginalWord { get; set; }
        public string TranslateWord { get; set; }

        public string Transcription { get; set; }
        public int WordGroupId { get; set; }
    }
}
