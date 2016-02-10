using System;
using Newtonsoft.Json;
using RestSharp;
using Android.Util;
using System.Threading.Tasks;
namespace ScholarStation
{
	public class ProfileUtility
	{
		public Task<ProfileResponse> ProfileAsync(LoginResponse data){
				
			return Task.Run (() => {
				var client = new RestClient ("http://70.187.52.39:3000/ProfileApp");
				var req = new RestRequest (Method.POST);




				var json = req.JsonSerializer.Serialize (data);
				req.AddParameter ("application/json; charset=utf-8", json, ParameterType.RequestBody);
				//Console.WriteLine ("HELLLOOOO!>>?????");
				var returnStuff = client.Execute (req);
				ProfileResponse info = JsonConvert.DeserializeObject<ProfileResponse> (returnStuff.Content);
				Console.WriteLine (info);

				//var dict = JsonConvert.DeserializeObject<JsonArrayAttribute> (asd);
				return info;
			});
				

			
			

	}
}
				}
