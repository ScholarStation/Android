﻿using System;

namespace ScholarStation
{
	public class StudyGroup
	{
//		public string username{ get; set; }
//		public string KEY { get; set; }
		public string owner { get; set; }
		public string _id{ get; set; }
		public string course{ get; set; }
		public string topic{ get; set; }
		public string date{ get; set; }
		public string time{ get; set; }
		public string[] members { get; set; }

		public StudyGroup(){
			members = new string[5];
		}

		public override string ToString ()
		{
			return string.Format ("[StudyGroup: id={0}, course={1}, topic={2}, date={3}, time={4}, members={5}]", _id, course, topic, date, time, members);
		}
	}
}

