using AutoMapper;
using CardsOfWords.WebApi.Words.Data;
using CardsOfWords.WebApi.Words.Data.Entities;
using CardsOfWords.WebApi.Words.Models.AppVersion;
using CardsOfWords.WebApi.Words.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CardsOfWords.WebApi.Words.Services;

public sealed class AppVersionRepository : IAppVersionRepository
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public AppVersionRepository(DataContext dataContext, IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task Create(AppVersionRequestModel model)
    {
        var appVersion = _mapper.Map<AppVersion>(model);
        await _dataContext.AddAsync<AppVersion>(appVersion);
        await _dataContext.SaveChangesAsync();
    }
    public async Task Update(int id, AppVersionRequestModel model)
    {
        var item = await _dataContext.AppVersions.FindAsync(id);
        if (item != null)
        {
            _mapper.Map(model, item);
            _dataContext.AppVersions.Update(item);
            await _dataContext.SaveChangesAsync();
        }
    }
    public async Task Delete(int id)
    {
        var item = await _dataContext.AppVersions.FindAsync(id);
        if (item != null)
        {
            _dataContext.AppVersions.Remove(item);
            await _dataContext.SaveChangesAsync();
        }
    }

    public Task<IQueryable<AppVersion>> Get()
    {
        return Task.Run(()=> _dataContext.AppVersions.AsQueryable());
    }

    public ValueTask<AppVersion?> GetById(int id)
    {
        return _dataContext.AppVersions.FindAsync(id);
    }
}
