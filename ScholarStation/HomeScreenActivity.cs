
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
	[Activity (Label = "Home Screen")]			
	public class HomeScreenActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.HomeScreen);

			Button profile = FindViewById<Button> (Resource.Id.ProfileButton);


			var user= Intent.GetStringExtra("user");
			var key = Intent.GetStringExtra("key");
			Console.WriteLine (user + " @@@@@ " + key);

			LoginResponse data = new LoginResponse (user, key);
				
			profile.Click += async (sender, e) => {

				var Pgetter = new ProfileUtility();
				ProfileResponse result = await Pgetter.ProfileAsync(data);

				Intent intent = new Intent(this, typeof(StudentProfile));
				var b = new Bundle();
				b.PutString("fname",result.fname);
				b.PutString("lname",result.lname);
				b.PutString("major",result.major);
				b.PutString("email",result.email);
				b.PutString("gender",result.gender);
				b.PutString("year",result.year);
				b.PutString("age",result.age.ToString());
				intent.PutExtras(b);
				StartActivity(intent);
			};

			// Create your application here
		}
	}
}

