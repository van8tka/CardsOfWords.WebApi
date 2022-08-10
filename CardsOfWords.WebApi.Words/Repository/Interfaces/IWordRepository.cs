using CardsOfWords.WebApi.Words.Data.Entities;
using CardsOfWords.WebApi.Words.Models.Word;

namespace CardsOfWords.WebApi.Words.Repository.Interfaces
{
    public interface IWordRepository
    {
        Task<IQueryable<Word>> Get();
        Task<IQueryable<Word>> Get(int skipCount, int takeCount);
        Task<IQueryable<Word>> GetByWordGroup(int idWordGroup, int skipCount, int takeCount);
        Task<IQueryable<Word>> GetByLanguage(int idLanguage, int skipCount, int takeCount);
        ValueTask<Word?> GetById(int id);
        Task Create(WordRequestModel model);
        Task Update(int id, WordRequestModel model);
        Task Delete(int id);
    }
}
