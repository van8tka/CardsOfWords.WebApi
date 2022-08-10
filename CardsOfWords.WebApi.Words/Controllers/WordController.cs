using AutoMapper;
using CardsOfWords.WebApi.Words.Models.Word;
using CardsOfWords.WebApi.Words.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardsOfWords.WebApi.Words.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<WordController> _logger;
        public WordController(ILogger<WordController> logger, IWordRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/<Controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("get all words");
            var itemsRaw = await _repository.Get();
            var items = await itemsRaw.ToListAsync();
            var result = _mapper.Map<List<WordResponseModel>>(items);
            return Ok(result);
        }
        // GET api/<Controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation($"get word by id = {id}");
            var item = await _repository.GetById(id);
            var result = _mapper.Map<WordResponseModel>(item);
            return Ok(result);
        }

        // GET api/<Controller>/<action>/15/10
        [Route("[action]/{skip}/{take}")]
        [HttpGet]
        public async Task<IActionResult> GetPage(int skip=0, int take=50)
        {
            _logger.LogInformation($"get words by skip = {skip}, take = {take}");
            var itemsRaw = await _repository.Get(skip, take);
            var items = await itemsRaw.ToListAsync();
            var result = _mapper.Map<List<WordResponseModel>>(items);
            return Ok(result);
        }

        // GET api/<Controller>/<Action>/5/15/10
        [Route("[action]/{idLanguage}/{skip}/{take}")]
        [HttpGet]
        public async Task<IActionResult> GetByLanguage(int idLanguage, int skip=0, int take=50)
        {
            _logger.LogInformation($"get words by idLanguage = {idLanguage}, skip = {skip}, take = {take}");
            var itemsRaw = await _repository.GetByLanguage(idLanguage, skip, take);
            var items = await itemsRaw.ToListAsync();
            var result = _mapper.Map<List<WordResponseModel>>(items);
            return Ok(result);
        }

        // GET api/<Controller>/5/15/10
        [Route("[action]/{idWordGroup}/{skip}/{take}")]
        [HttpGet]
        public async Task<IActionResult> GetByWordGroup(int idWordGroup, int skip=0, int take=50)
        {
            _logger.LogInformation($"get words by idWordGroup = {idWordGroup}, skip = {skip}, take = {take}");
            var itemsRaw = await _repository.GetByWordGroup(idWordGroup, skip, take);
            var items = await itemsRaw.ToListAsync();
            var result = _mapper.Map<List<WordResponseModel>>(items);
            return Ok(result);
        }

        //Post api/<Controller>
        [HttpPost]
        public async Task<IActionResult> Post(WordRequestModel model)
        {
            _logger.LogInformation($"create new word: OriginalWord= {model.OriginalWord}, TranslateWord = {model.TranslateWord}, Transcription = {model.Transcription}, idWordGroup = {model.WordGroupId}");
            await _repository.Create(model);
            return Ok(new { message = "create new item" });
        }
        //Put api/<Controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, WordRequestModel model)
        {
            _logger.LogInformation($"update new id = {id}: OriginalWord= {model.OriginalWord}, TranslateWord = {model.TranslateWord}, Transcription = {model.Transcription}, idWordGroup = {model.WordGroupId}");
            await _repository.Update(id, model);
            return Ok(new { message = $"update item with id = {id}" });
        }
        //Delete api/<Controller>/5
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"delete word by id = {id}");
           await _repository.Delete(id);
            return Ok(new { message = $"delete item with id = {id}" });
        }
    }
}
