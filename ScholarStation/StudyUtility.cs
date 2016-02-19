using System;
using Newtonsoft.Json;
using RestSharp;
using Android.Util;
using System.Threading.Tasks;

namespace ScholarStation
{
	public class StudyUtility
	{
		public Task<StudyResponse> StudyAsync(string userName, string course, string topic, string date, string time, string[] members){
			return Task.Run (() => {
				var client = new RestClient ("http://70.187.52.39:3000/StudyUtility/Create");
				var req = new RestRequest (Method.POST);
				string user = userName;
				string c = course;
				string t = topic;
				string d = date;
				string Time = time;
				string[] m = members;
				var studyObject = new LoginRequest {
					username = user,
					course = c,
					topic = t,
					date = d,
					time = Time,
					members = m,
				};
				var json = req.JsonSerializer.Serialize (studyObject);
				req.AddParameter ("application/json; charset=utf-8", json, ParameterType.RequestBody);
				Console.WriteLine ("HELLLOOOO!>>?????");
				var returnStuff = client.Execute (req);
				LoginResponse info = JsonConvert.DeserializeObject<LoginResponse> (returnStuff.Content);
			}
			);}
			
	}
}

