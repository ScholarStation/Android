using System;
using Newtonsoft.Json;
using RestSharp;
using Android.Util;
using System.Threading.Tasks;

namespace ScholarStation
{
	public class LoginUtility
	{
		public Task<LoginResponse> LoginAsync(string userName, string passWord){
			return Task.Run (() => {
			var client = new RestClient("http://70.187.52.39:3000/LoginApp");
			var req = new RestRequest(Method.POST);
			string user = userName;
			string pass = passWord;
			var loginObject = new LoginRequest {
				username = user,
				password = pass,
			};

			var json = req.JsonSerializer.Serialize(loginObject);
			req.AddParameter("application/json; charset=utf-8", json, ParameterType.RequestBody);
			Console.WriteLine ("HELLLOOOO!>>?????");
			var returnStuff =  client.Execute(req);
			LoginResponse info = JsonConvert.DeserializeObject<LoginResponse> (returnStuff.Content);
			Console.WriteLine (info.KEY);

			//var dict = JsonConvert.DeserializeObject<JsonArrayAttribute> (asd);
			return info;


		}
			);}
		private class LoginRequest{
			public string username { get; set; }
			public string password { get; set; }
			public string RequestType { get; set; }
		}
	}

}


