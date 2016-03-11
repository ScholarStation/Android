
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ScholarStation
{
	[Activity (Label = "ViewStudySessionActivity", Theme="@android:style/Theme.Holo.Light")]			
	public class ViewStudySessionActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			
			SetContentView (Resource.Layout.ViewStudySessionScreen);
			base.OnCreate (savedInstanceState);

			TextView vCourse = FindViewById<TextView> (Resource.Id.vCourse);
			TextView vDate = FindViewById<TextView> (Resource.Id.vDate);
			TextView vTime = FindViewById<TextView> (Resource.Id.vTime);
			TextView vTopic = FindViewById<TextView> (Resource.Id.vTopic);
			TextView vMember1 = FindViewById<TextView> (Resource.Id.vMember1);
			TextView vMember2 = FindViewById<TextView> (Resource.Id.vMember2);
			TextView vMember3 = FindViewById<TextView> (Resource.Id.vMember3);
			TextView vMember4 = FindViewById<TextView> (Resource.Id.vMember4);
			TextView vMember5 = FindViewById<TextView> (Resource.Id.vMember5);

//			var vC = Intent.GetStringExtra ("course");
//			vCourse.Text = vC;
		}
	}
}

