using CardsOfWords.WebApi.Words.Data.Entities;
using CardsOfWords.WebApi.Words.Models.AppVersion;

namespace CardsOfWords.WebApi.Words.Repository.Interfaces;

public interface IAppVersionRepository
{
    Task<IQueryable<AppVersion>> Get();
    ValueTask<AppVersion?> GetById(int id);
    Task Create(AppVersionRequestModel model);
    Task Update(int id, AppVersionRequestModel model);
    Task Delete(int id);
}
