using System;
using System.Threading.Tasks;

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
		/// Request types.
		/// </summary>
		public enum RequestTypes {Login,ProfileReq,ProfileEdt,StudyDel,StudyCrt,StudyEdt};

		//URL stings
		private const string Login = "http://70.187.52.39:3000/LoginApp";
		private const string ProfileReq = "http://70.187.52.39:3000/ProfileApp";
		private const string ProfileEdit = "...";//not implemented
		private const string StudyReq = "http://70.187.52.39:3000/StudyUtility/GetStudyGroupsByMember";
		private const string StudyCrt = "http://70.187.52.39:3000/StudyUtility/Create";
		private const string StudyEdt = "http://70.187.52.39:3000/StudyUtility/EditByID";
		private const string StudyDel = "http://70.187.52.39:3000/StudyUtility/DeleteByID";

		/// <summary>
		/// Makes call to specific server path based on the Return type
		/// </summary>
		/// <returns>The async.</returns>
		public Task<Type> RequestAsync(){
			//runs Async
			return Task.Run(()=>{
				//find type requests
			
		
				return Type;
			});

	}
}
}

