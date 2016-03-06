using System;

namespace ScholarStation
{
	public class ProfileResponse
	{
		//profile info
		public string fname{get;set;}
		public string lname{get;set;}
		public string major{get;set;}
		public string email{get;set;}
		public string gender{get;set;}
		public string year{get;set;}
		public int age{get;set;}
		//Login info
		public string KEY { get; set; }
		public string username{ get; set;}
		//study groups 


		public override string ToString ()
		{
			return string.Format ("[ProfileResponse: fname={0}, lname={1}, major={2}, email={3}, gender={4}, year={5}, age={6}]", fname, lname, major, email, gender, year, age);
		}


	}
}

