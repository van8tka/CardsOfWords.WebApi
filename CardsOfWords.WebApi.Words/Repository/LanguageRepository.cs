using AutoMapper;
using CardsOfWords.WebApi.Words.Data;
using CardsOfWords.WebApi.Words.Data.Entities;
using CardsOfWords.WebApi.Words.Models.Language;
using CardsOfWords.WebApi.Words.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CardsOfWords.WebApi.Words.Services
{
    public sealed class LanguageRepository : ILanguageRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public LanguageRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task Create(LanguageRequestModel model)
        {
            var item = _mapper.Map<Language>(model);
            await _dataContext.AddAsync<Language>(item);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
           var item = await _dataContext.Languages.FindAsync(id);
            if (item != null)
            {
                _dataContext.Remove(item);
                await _dataContext.SaveChangesAsync();
            }
        }

        public Task<IQueryable<Language>> Get()
        {
            return Task.Run(()=> _dataContext.Languages.AsQueryable());
        }

        public ValueTask<Language?> GetById(int id)
        {
            return _dataContext.Languages.FindAsync(id);
        }

        public async Task Update(int id, LanguageRequestModel model)
        {
            var item = await _dataContext.Languages.FindAsync(id);
            if(item!=null)
            {
                _mapper.Map(model, item);
                _dataContext.Languages.Update(item);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
