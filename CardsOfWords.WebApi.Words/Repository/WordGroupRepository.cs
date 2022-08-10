using AutoMapper;
using CardsOfWords.WebApi.Words.Data;
using CardsOfWords.WebApi.Words.Data.Entities;
using CardsOfWords.WebApi.Words.Models.WordGroup;
using CardsOfWords.WebApi.Words.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CardsOfWords.WebApi.Words.Services
{
    public class WordGroupRepository : IWordGroupRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public WordGroupRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task Create(WordGroupRequestModel model)
        {
            var item = _mapper.Map<WordGroup>(model);
            await _dataContext.AddAsync<WordGroup>(item);
            await _dataContext.SaveChangesAsync();
        }
        public async Task Update(int id, WordGroupRequestModel model)
        {
            var item = await _dataContext.WordGroups.FindAsync(id);
            if (item != null)
            {
                _mapper.Map(model, item);
                _dataContext.WordGroups.Update(item);
                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var item = await _dataContext.WordGroups.FindAsync(id);
            if (item != null)
            {
                _dataContext.WordGroups.Remove(item);
                await _dataContext.SaveChangesAsync();
            }
        }

        public Task<IQueryable<WordGroup>> Get()
        {
            return Task.Run(()=> _dataContext.WordGroups.AsQueryable());
        }

        public ValueTask<WordGroup?> GetById(int id)
        {
            return _dataContext.WordGroups.FindAsync(id);
        }
  
        public Task<IQueryable<WordGroup>> GetByLanguage(int idLanguage)
        {
            return Task.Run(()=>_dataContext.WordGroups.Where(x=>x.LanguageId == idLanguage));
        }
    }
}
