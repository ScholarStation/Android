
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

namespace ScholarStation
{
	public class studentProfileFragment : Fragment
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			// Use this to return your custom view for this Fragment
			// return inflater.Inflate(Resource.Layout.YourFragment, container, false);
			View view = inflater.Inflate(Resource.Layout.StudentProfile, container, false);
			var user= Activity.Intent.GetStringExtra("user");
			var key = Activity.Intent.GetStringExtra("key");

			LoginResponse data = new LoginResponse (user, key);
			var Pgetter = new ProfileUtility();

				Task<ProfileResponse> result = Pgetter.ProfileAsync(data);

			var finishedResult = result.Result;
			


			TextView firstName = view.FindViewById<TextView> (Resource.Id.StudentFName);
			TextView lastName = view.FindViewById<TextView> (Resource.Id.StudentLName);
			TextView email = view.FindViewById<TextView> (Resource.Id.StudentEmail);
			TextView major = view.FindViewById<TextView> (Resource.Id.StudentMajor);
			TextView gender = view.FindViewById<TextView> (Resource.Id.StudentGender);
			TextView age = view.FindViewById<TextView> (Resource.Id.StudentAge);
			TextView year = view.FindViewById<TextView> (Resource.Id.StudentYear);

			var fName= finishedResult.fname;
			var lName = finishedResult.lname;
			var Smajor = finishedResult.major;
			var Semail = finishedResult.email;
			var Sgender = finishedResult.gender;
			var Syear = finishedResult.year;
			var Sage = finishedResult.age.ToString();

			firstName.Text = fName;
			lastName.Text = lName;
			email.Text = Semail;
			major.Text = Smajor;
			gender.Text = Sgender;
			year.Text = Syear;
			age.Text = Sage;

			return view;
		}
	}
}

