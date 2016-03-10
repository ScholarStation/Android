using System;
using Newtonsoft.Json;
using RestSharp;
using Android.Util;
using System.Threading.Tasks;
using Java.Util;

namespace ScholarStation
{
	public class EditStudyUtility
	{
		public Task<StudyResponse> EditStudyAsync(string username, string Key, string ID, string course, string topic, string date, string time, string[] members){
			Console.Write ("We made it");
			return Task.Run (() => {
				var client = new RestClient ("http://70.187.52.39:3000/StudyUtility/EditByID");
				var req = new RestRequest (Method.POST);
				string userName = username;
				string k = Key;
				string id = ID;
				string c = course;
				string t = topic;
				string d = date;
				string time1 = time;
				string[] m = members;
				var editStudyObject = new StudyGroupCreate {
					username = userName,
					KEY = k,
					_id = id,
					owner = userName,
					course = c,
					topic = t,
					date = d,
					time = time,
					members = m
				};

				var json = req.JsonSerializer.Serialize (editStudyObject);
				req.AddParameter ("application/json; charset=utf-8", json, ParameterType.RequestBody);
				Console.WriteLine ("HELLLOOOO!>>?????");
				var returnStuff = client.Execute (req);
				StudyResponse info = JsonConvert.DeserializeObject<StudyResponse> (returnStuff.Content);

				return info;
			}
			);}
	}
}

