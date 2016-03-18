using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using ScholarStation.WebUtil.Login;
using ScholarStation.WebUtil.Profile;
using ScholarStation.WebUtil.StudyGroup;


namespace ScholarStation
{
	/// <summary>
	/// Web utility This class handles the API calls to Scholar Station Nod3 server 
	/// Refactored version from 3/16
	/// </summary>
	public class WebUtility
	{
		public WebUtility ()
		{
		}

		/// <summary>
		/// Request types.will we need these?
		/// 
		/// </summary>
		public enum RequestTypes
		{
			Login,
			ProfileReq,
			ProfileEdt,
			StudyReq,
			StudyCrt,
			StudyEdt,
			StudyDel,
			StudySrc
		};

		//URL stings
		private const string Login = "http://70.187.52.39:3000/LoginApp";
		private const string ProfileReq = "http://70.187.52.39:3000/ProfileApp";
		private const string ProfileEdt = "...";//not implemented
		private const string StudyReq = "http://70.187.52.39:3000/StudyUtility/GetStudyGroupsByMember";
		private const string StudyCrt = "http://70.187.52.39:3000/StudyUtility/Create";
		private const string StudyEdt = "http://70.187.52.39:3000/StudyUtility/EditByID";
		private const string StudyDel = "http://70.187.52.39:3000/StudyUtility/DeleteByID";
		private const string StudySrc = "...";//not implemented

		/// <summary>
		/// Makes call to specific server path based on the Return type
		/// </summary>
		/// <returns>The async.</returns>
		public Task<Type> RequestAsync (WebRequest payload)
		{

            Console.WriteLine("Entered Web REQUEST");
            
			//runs Async
			return Task.Run (() => {

                //local variables Client etc
                RestClient restClient;
                RestRequest restRequest = new RestRequest(Method.POST);
                Type responseData;
                IRestResponse restResponse;
                // serarliaze payload and add header
                var jsonPayload = restRequest.JsonSerializer.Serialize(payload);
                restRequest.AddParameter("application/json; charset=utf-8", jsonPayload, ParameterType.RequestBody);


                //find type requests, Create REST Client and Request
                if (typeof(Type) == typeof(LoginRes))
                {
                    restClient = new RestClient(Login);
                }
                else if (typeof(Type) == typeof(ProfileRes))
                {
                    restClient = new RestClient(ProfileReq);
                }
                else if (typeof(Type) == typeof(ProfileEdtRes))
                {
                    restClient = new RestClient(ProfileEdt);
                }
                else if (typeof(Type) == typeof(StudyRes))
                {
                    restClient = new RestClient(StudyReq);
                }
                else if (typeof(Type) == typeof(StudyCrtRes))
                {
                    restClient = new RestClient(StudyCrt);
                }
                else if (typeof(Type) == typeof(StudyEdtRes))
                {
                    restClient = new RestClient(StudyEdt);
                }
                else if (typeof(Type) == typeof(StudyDelRes))
                {
                    restClient = new RestClient(StudyCrt);
                }
                else if (typeof(Type) == typeof(StudySrcRes))
                {
                    restClient = new RestClient(StudySrc);
                }
                else throw new Exception("Incorrect Type");

                //execute and desearlize data
                restResponse = restClient.Execute(restRequest);
                responseData = JsonConvert.DeserializeObject<Type>(restResponse.Content);

                return responseData;

            });

		}

        
	}
}

