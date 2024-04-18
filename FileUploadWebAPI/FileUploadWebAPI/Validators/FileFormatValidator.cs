using System.Text.Json;

namespace FileUploadWebAPI.Validators
{
  public class FileFormatValidator
  {
    public static bool IsValidJson(string json)
    {
      try
      {
        JsonDocument.Parse(json);
        return true;
      }
      catch (JsonException)
      {
        return false;
      }
    }
  }
}
