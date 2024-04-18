using FileUploadWebAPI.Validators;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FileUploadAPI.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class FileUploadController : ControllerBase
  {
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
      if (!Request.Headers.TryGetValue("ApiKey", out var apiKey))
        return BadRequest("ApiKey header is missing.");

      Request.Headers.TryGetValue("Name", out var name);

      if (file == null || file.Length == 0)
        return BadRequest("File not selected or empty.");

      using (var streamReader = new StreamReader(file.OpenReadStream()))
      {
        var json = await streamReader.ReadToEndAsync();
        if (!FileFormatValidator.IsValidJson(json))
          return BadRequest("Invalid JSON format.");

        var people = JsonConvert.DeserializeObject<List<Person>>(json);

        var nameCounts = people.Count(p => p.Name == name);

        return Ok($"{name} has {nameCounts} instance(s)");
      }
    }
  }
}
