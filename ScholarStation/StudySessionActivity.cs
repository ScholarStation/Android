
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ScholarStation
{
	[Activity (Label = "StudySessionActivity")]			
	public class StudySessionActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.StudySessionScreen);
			TextView course = FindViewById<TextView> (Resource.Id.studyClass);
			TextView topic = FindViewById<TextView> (Resource.Id.sessionTopic);
			TextView date = FindViewById<TextView> (Resource.Id.date);
			TextView time = FindViewById<TextView> (Resource.Id.time);

			course.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				course = e.Text.ToString();
			};
			topic.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				topic = e.Text.ToString();
			};
			date.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				date = e.Text.ToString();
			};
			time.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				time = e.Text.ToString();
			};


			// Create your application here
		}
	}
}

