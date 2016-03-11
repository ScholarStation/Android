using System;
using Newtonsoft.Json;
using RestSharp;
using Android.Util;
using System.Threading.Tasks;

namespace ScholarStation
{
	public class StudyRequest
	{
		public Task<StudyResponse> StudyRequestAsync(string userName, string key){
			return Task.Run (() => {
				var client = new RestClient ("http://70.187.52.39:3000/StudyUtility/GetStudyGroupsByMember");
				var req = new RestRequest (Method.POST);
				string user = userName;
				string k = key;
				var studyR = new studyInfo{
					username = user,
					KEY = k
				};
			
				var json = req.JsonSerializer.Serialize (studyR);
				req.AddParameter ("application/json; charset=utf-8", json, ParameterType.RequestBody);
				//Console.WriteLine ("HELLLOOOO!>>?????");
				var returnStuff = client.Execute (req);
				Console.Write(returnStuff.Content);
				StudyResponse info = JsonConvert.DeserializeObject<StudyResponse> (returnStuff.Content);
				Console.WriteLine (info);

				//var dict = JsonConvert.DeserializeObject<JsonArrayAttribute> (asd);
				return info;
			});
		}
		private class studyInfo{
			public string username { get; set; }
			public string KEY { get; set; }
		}
	}
}

