using System;

namespace ScholarStation
{
	public class LoginResponse


	{


		public LoginResponse(string user, string key){

			this.KEY = key;
			this.username = user;
		}
			public string KEY { get; set; }
			public string username{ get; set;}
			public bool validate { get; set; }
		public override string ToString ()
		{
			return string.Format ("[LoginResponse: key={0}, user={1}, validate={2}]", KEY, username, validate);
		}
	
	}
}

