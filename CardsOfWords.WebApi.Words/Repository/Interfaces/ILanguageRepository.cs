using CardsOfWords.WebApi.Words.Data.Entities;
using CardsOfWords.WebApi.Words.Models.Language;

namespace CardsOfWords.WebApi.Words.Repository.Interfaces
{
    public interface ILanguageRepository
    {
        Task<IQueryable<Language>> Get();
        ValueTask<Language?> GetById(int id);
        Task Create(LanguageRequestModel model);
        Task Update(int id, LanguageRequestModel model);
        Task Delete(int id);
    }
}
