using CardsOfWords.WebApi.Words.Models.AppVersion;
using CardsOfWords.WebApi.Words.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CardsOfWords.WebApi.Words.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AppVersionController : ControllerBase
{
    private readonly IAppVersionRepository _appVersionRepository;
    public AppVersionController(IAppVersionRepository appVersionRepository)
    {
        _appVersionRepository = appVersionRepository;
    }

    // GET: api/<AppVersionController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
         var items = await _appVersionRepository.Get();
        return Ok(items);
    }

    // GET api/<AppVersionController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _appVersionRepository.GetById(id);
        return Ok(item);
    }

    // POST api/<AppVersionController>
    [HttpPost]
    public async Task<IActionResult> Post(AppVersionRequestModel createRequest)
    {
        await _appVersionRepository.Create(createRequest);
        return Ok(new { message = "create new AppVersion"});
    }

    // PUT api/<AppVersionController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, AppVersionRequestModel updateRequest)
    {
        await _appVersionRepository.Update(id, updateRequest);
        return Ok(new { message = $"update AppVersion with id={id}" });
    }

    // DELETE api/<AppVersionController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _appVersionRepository.Delete(id);
        return Ok(new { message = $"delete AppVersion with id={id}" });
    }
}
