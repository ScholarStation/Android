﻿using System;
using Newtonsoft.Json;
using RestSharp;
using Android.Util;
using System.Threading.Tasks;
using Java.Util;

namespace ScholarStation
{
	public class StudyUtility
	{
		public Task<StudyResponse> StudyAsync(string username, string Key, string course, string topic, string date, string time, ArrayList members){
			return Task.Run (() => {
				var client = new RestClient ("http://70.187.52.39:3000/StudyUtility/Create");
				var req = new RestRequest (Method.POST);
				string userName = username;
				string k = Key;
				string c = course;
				string t = topic;
				string d = date;
				string time1 = time;
				ArrayList m = members;
				var studyObject = new StudyRequest {
					user = userName,
					key = k,
					course = c,
					topic = t,
					date = d,
					time = time1,
					members = m
				};

				var json = req.JsonSerializer.Serialize (studyObject);
				req.AddParameter ("application/json; charset=utf-8", json, ParameterType.RequestBody);
				Console.WriteLine ("HELLLOOOO!>>?????");
				var returnStuff = client.Execute (req);
				StudyResponse info = JsonConvert.DeserializeObject<StudyResponse> (returnStuff.Content);

				return info;
			}
			);}
		private class StudyRequest{
			public string user { get; set; }
			public string key { get; set; }
			public string course { get; set; }
			public string topic { get; set; }
			public string date { get; set; }
			public string time { get; set; }
			public ArrayList members { get; set; }
		}
	}
}

