using AutoMapper;
using CardsOfWords.WebApi.Words.Data;
using CardsOfWords.WebApi.Words.Data.Entities;
using CardsOfWords.WebApi.Words.Models.Word;
using CardsOfWords.WebApi.Words.Repository.Interfaces;

namespace CardsOfWords.WebApi.Words.Services
{
    public class WordRepository : IWordRepository
    {

        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        public WordRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        public async Task Create(WordRequestModel model)
        {
            var item = _mapper.Map<Word>(model);
            await _dataContext.AddAsync<Word>(item);
            await _dataContext.SaveChangesAsync();
        }
        public async Task Update(int id, WordRequestModel model)
        {
            var item = await _dataContext.Words.FindAsync(id);
            if (item != null)
            {
                _mapper.Map(model, item);
                _dataContext.Words.Update(item);
                await _dataContext.SaveChangesAsync();
            }
        }
        public async Task Delete(int id)
        {
            var item = await _dataContext.Words.FindAsync(id);
            if (item != null)
            {
                _dataContext.Words.Remove(item);
                await _dataContext.SaveChangesAsync();
            }
        }

        public Task<IQueryable<Word>> Get()
        {
            return Task.Run(()=> _dataContext.Words.AsQueryable<Word>());
        }

        public ValueTask<Word?> GetById(int id)
        {
            return _dataContext.Words.FindAsync(id);
        }

        public Task<IQueryable<Word>> Get(int skipCount, int takeCount)
        {
            return Task.Run(() => _dataContext.Words.OrderBy(x=>x.Id).Skip(skipCount).Take(takeCount).AsQueryable<Word>());
        }
 
        public Task<IQueryable<Word>> GetByLanguage(int idLanguage, int skipCount , int takeCount)
        {
            return Task.Run(() => _dataContext.Words.Where(x => x.WordGroup.LanguageId == idLanguage).OrderBy(x => x.Id).Skip(skipCount).Take(takeCount).AsQueryable<Word>());
        }

        public Task<IQueryable<Word>> GetByWordGroup(int idWordGroup, int skipCount, int takeCount)
        {
            return Task.Run(() => _dataContext.Words.Where(x=>x.WordGroupId == idWordGroup).OrderBy(x=>x.Id).Skip(skipCount).Take(takeCount).AsQueryable<Word>());
        }
    }
}
