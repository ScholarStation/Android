using System;

namespace ScholarStation
{
	public class StudyResponse
	{
		public StudyResponse (string user)
		{
			this.username = user;

		}
		public string username{ get; set;}
		public override string ToString ()
		{
			return string.Format ("[StudyResponse: username={0}]", username);
		}
	}
}

