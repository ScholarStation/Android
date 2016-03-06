
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
using Java.Util;
using System.Threading.Tasks;

namespace ScholarStation
{
	[Activity (Label = "StudySessionActivity", Theme="@android:style/Theme.Holo.Light")]			
	public class StudySessionActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			
			ArrayList members = new ArrayList();
			base.OnCreate (savedInstanceState);
			string studyCourse = "";
			string studyTopic = "";
			string studyDate = "";
			string studyTime = "";
			string studyMember1 = "";
			string studyMember2 = "";
			string studyMember3 = "";
			string studyMember4 = "";
			string studyMember5 = "";
			SetContentView (Resource.Layout.StudySessionScreen);
			TextView course = FindViewById<TextView> (Resource.Id.courseStudy);
			TextView topic = FindViewById<TextView> (Resource.Id.SessionTopic);
			TextView date = FindViewById<TextView> (Resource.Id.date);
			TextView time = FindViewById<TextView> (Resource.Id.time);
			TextView member1 = FindViewById<TextView> (Resource.Id.Member1);
			TextView member2 = FindViewById<TextView> (Resource.Id.Member2);
			TextView member3 = FindViewById<TextView> (Resource.Id.Member3);
			TextView member4 = FindViewById<TextView> (Resource.Id.Member4);
			TextView member5 = FindViewById<TextView> (Resource.Id.Member5);
			Button create = FindViewById<Button> (Resource.Id.createSessionButton);

			course.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyCourse = e.Text.ToString();
			};
			topic.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyTopic = e.Text.ToString();
			};
			date.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyDate = e.Text.ToString();
			};
			time.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyTime = e.Text.ToString();
			};
			member1.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyMember1 = e.Text.ToString();
				members.Add(studyMember1);
			};
			member2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyMember2 = e.Text.ToString();
				members.Add(studyMember2);
			};
			member3.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyMember3 = e.Text.ToString();
				members.Add(studyMember3);
			};
			member4.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyMember4 = e.Text.ToString();
				members.Add(studyMember4);
			};
			member5.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyMember5 = e.Text.ToString();
				members.Add(studyMember5);
			};
			create.Click += async (sender, e) => {
				var createStudySession = new StudyUtility();
				Task<StudyResponse> stuff = createStudySession.StudyAsync(studyCourse, studyTopic, studyDate, studyTime, members);
			};
		}
	}
}

