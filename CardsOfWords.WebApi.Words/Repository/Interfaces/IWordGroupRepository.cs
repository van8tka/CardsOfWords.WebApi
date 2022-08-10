using CardsOfWords.WebApi.Words.Data.Entities;
using CardsOfWords.WebApi.Words.Models.WordGroup;

namespace CardsOfWords.WebApi.Words.Repository.Interfaces
{
    public interface IWordGroupRepository
    {
        Task<IQueryable<WordGroup>> Get();
        Task<IQueryable<WordGroup>> GetByLanguage(int idLanguage);
        ValueTask<WordGroup?> GetById(int id);
        Task Create(WordGroupRequestModel model);
        Task Update(int id, WordGroupRequestModel model);
        Task Delete(int id);
    }
}
