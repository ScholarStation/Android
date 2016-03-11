using System;

namespace ScholarStation
{
	public class StudyResponse
	{

		public StudyGroup[] studyGroups { get; set;}

		public override string ToString ()
		{
			string returnS = "";
			foreach (StudyGroup item in studyGroups) {
				returnS += item.ToString ();
			}
			return returnS;
		}


	}

}

