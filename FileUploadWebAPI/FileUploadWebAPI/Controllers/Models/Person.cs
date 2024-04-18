using FileUploadWebAPI.Controllers.Models;

public class Person
{
  public string Name { get; set; }
  public int Age { get; set; }
  public string Email { get; set; }
  public Address Address { get; set; }
  public List<string> Tags { get; set; }
}