using System;

namespace ScholarStation
{
	public class DeleteResponse
	{
		public string username { get; set; }
		public string KEY { get; set; }
		public string _id { get; set; }

		public override string ToString ()
		{
			return string.Format ("[DeleteResponse: username={0}, KEY={1}, _id={2}]", username, KEY, _id);
		}
	}
}

