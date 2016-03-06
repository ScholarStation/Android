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
				var studyR = new StudyRequest{
					//userName = LoginInfo.username,

				};
				var client = new RestClient ("http://70.187.52.39:3000/StudyUtility/GetStudyGroupsByMember");
				var req = new RestRequest (Method.POST);
				var json = req.JsonSerializer.Serialize (studyR);
				req.AddParameter ("application/json; charset=utf-8", json, ParameterType.RequestBody);
				//Console.WriteLine ("HELLLOOOO!>>?????");
				var returnStuff = client.Execute (req);
				StudyResponse info = JsonConvert.DeserializeObject<StudyResponse> (returnStuff.Content);
				Console.WriteLine (info);

				//var dict = JsonConvert.DeserializeObject<JsonArrayAttribute> (asd);
				return info;
			});
		}
	}
}

