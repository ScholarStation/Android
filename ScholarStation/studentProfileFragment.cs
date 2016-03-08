
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
			ProfileResponse result = Pgetter.ProfileAsync(data);

			TextView firstName = view.FindViewById<TextView> (Resource.Id.StudentFName);
			TextView lastName = view.FindViewById<TextView> (Resource.Id.StudentLName);
			TextView email = view.FindViewById<TextView> (Resource.Id.StudentEmail);
			TextView major = view.FindViewById<TextView> (Resource.Id.StudentMajor);
			TextView gender = view.FindViewById<TextView> (Resource.Id.StudentGender);
			TextView age = view.FindViewById<TextView> (Resource.Id.StudentAge);
			TextView year = view.FindViewById<TextView> (Resource.Id.StudentYear);

			var fName= result.fname;
			var lName = result.lname;
			var Smajor = result.major;
			var Semail = result.email;
			var Sgender = result.gender;
			var Syear = result.year;
			var Sage = result.age.ToString();

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

