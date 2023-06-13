using Newtonsoft.Json.Linq;

namespace Lagosanto.Services;

public class StringToArrayConverterService
{
    
    public static JArray Convert(string? content)
    {
        if (content != null)
        {
            JArray jsonArray = JArray.Parse(content);
        
            return jsonArray;
        }
        
        return new JArray();
    }
    
}