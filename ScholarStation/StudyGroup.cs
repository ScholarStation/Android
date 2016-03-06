using System;

namespace ScholarStation
{
	public class StudyGroup
	{
		
		public string id{ get; set; }
		public string course{ get; set; }
		public string topic{ get; set; }
		public string date{ get; set; }
		public string time{ get; set; }
		public string[] members { get; set; }

		public override string ToString ()
		{
			return string.Format ("[StudyGroup: id={0}, course={1}, topic={2}, date={3}, time={4}, members={5}]", id, course, topic, date, time, members);
		}
	}
}

