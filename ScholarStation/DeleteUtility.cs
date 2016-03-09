using System;
using Newtonsoft.Json;
using RestSharp;
using Android.Util;
using System.Threading.Tasks;
using Java.Util;

namespace ScholarStation
{
	public class DeleteUtility
	{
		public Task<DeleteResponse> DeleteAsync(string username, string key, string ID){
			return Task.Run (() => {
				var client = new RestClient ("http://70.187.52.39:3000/StudyUtility/DeleteByID");
				var req = new RestRequest (Method.POST);
				string user = username;
				string k = key;
				string id = ID;
				var deleteObject = new DeleteRequest{
					username = user,
					KEY = k,
					_id = id
				};
				var json = req.JsonSerializer.Serialize (deleteObject);
				req.AddParameter ("application/json; charset=utf-8", json, ParameterType.RequestBody);
				Console.WriteLine ("HELLLOOOO!>>?????");
				var returnStuff = client.Execute (req);
				DeleteResponse info = JsonConvert.DeserializeObject<DeleteResponse> (returnStuff.Content);

				return info;
			});
		}
		private class DeleteRequest{
			public string username { get; set; }
			public string KEY { get; set; }
			public string _id { get; set; }
		}
	}
}

