using System;

namespace ScholarStation
{
	public class StudyResponse
	{
		public string user{ get; set; }
		public string KEY{ get; set; }
		public string id{ get; set; }
		public string course{ get; set; }
		public string topic{ get; set; }
		public string date{ get; set; }
		public string time{ get; set; }
		public string[] members { get; set; }

		public override string ToString ()
		{
			return string.Format ("[StudyResponse: user={0}, KEY={1}, id={2}, course={3}, topic={4}, date={5}, time={6}, members={7}]", user, KEY, id, course, topic, date, time, members);
		}
	}
}

