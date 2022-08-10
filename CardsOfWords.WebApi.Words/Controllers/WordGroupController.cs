using AutoMapper;
using CardsOfWords.WebApi.Words.Models.WordGroup;
using CardsOfWords.WebApi.Words.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CardsOfWords.WebApi.Words.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WordGroupController : ControllerBase
{
    private readonly IWordGroupRepository _repository;
    private readonly IMapper _mapper;
    public WordGroupController(IWordGroupRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // GET: api/<Controller>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var itemsRaw = await _repository.Get();
        var items = await itemsRaw.ToListAsync();
        var result = _mapper.Map<List<WordGroupResponseModel>>(items);
        return Ok(result);
    }
    // GET api/<Controller>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _repository.GetById(id);
        var result = _mapper.Map<WordGroupResponseModel>(item);
        return Ok(result);
    }

    // GET api/<Controller>/<Action>/5
    [Route("[action]/{idLanguage}")]
    [HttpGet]
    public async Task<IActionResult> GetByLanguage(int idLanguage)
    {
        var itemsRaw = await _repository.GetByLanguage(idLanguage);
        var items = await itemsRaw.ToListAsync();
        var result = _mapper.Map<List<WordGroupResponseModel>>(items);
        return Ok(result);
    }

    //Post api/<Controller>
    [HttpPost]
    public async Task<IActionResult> Post(WordGroupRequestModel model)
    {
        await _repository.Create(model);
        return Ok(new { message = "create new item" });
    }
    //Put api/<Controller>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, WordGroupRequestModel model)
    {
        await _repository.Update(id, model);
        return Ok(new { message = $"update item with id = {id}" });
    }
    //Delete api/<Controller>/5
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.Delete(id);
        return Ok(new { message = $"delete item with id = {id}" });
    }
}
