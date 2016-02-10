
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
	[Activity (Label = "Student Profile")]			
	public class StudentProfile : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.StudentProfile);
			TextView firstName = FindViewById<TextView> (Resource.Id.StudentFName);
			TextView lastName = FindViewById<TextView> (Resource.Id.StudentLName);
			TextView email = FindViewById<TextView> (Resource.Id.StudentEmail);
			TextView major = FindViewById<TextView> (Resource.Id.StudentMajor);
			TextView gender = FindViewById<TextView> (Resource.Id.StudentGender);
			TextView age = FindViewById<TextView> (Resource.Id.StudentAge);
			TextView year = FindViewById<TextView> (Resource.Id.StudentYear);

			var fName= Intent.GetStringExtra("fname");
			var lName = Intent.GetStringExtra("lname");
			var Smajor = Intent.GetStringExtra("major");
			var Semail = Intent.GetStringExtra("email");
			var Sgender = Intent.GetStringExtra("gender");
			var Syear = Intent.GetStringExtra("year");
			var Sage = Intent.GetStringExtra("age");
			//Console.WriteLine (fName + " @@@@@ " + lName);

			firstName.Text = fName;
			lastName.Text = lName;
			email.Text = Semail;
			major.Text = Smajor;
			gender.Text = Sgender;
			year.Text = Syear;
			age.Text = Sage;


			// Create your application here
		}
	}
}

