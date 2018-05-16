using System.Collections.Generic;
 
public static class DictionaryExtension
{
	public static string GenerateLinkParams(this Dictionary<string, object> @params)
	{
		var list = new List<string>();
		foreach (var param in @params)
			list.Add($"{param.Key}={param.Value}");
		return string.Join("&", list);
	}
}
