
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget; 
using Android.Support.V7.App;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ScholarStation
{
	[Activity (Label = "Home Screen", Icon = "@mipmap/icon")]			
	public class HomeScreenActivity : AppCompatActivity
	{
		DrawerLayout drawerLayout;
		NavigationView navigationView;
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.mainDrawer);
			drawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);

			var toolbar = FindViewById<Toolbar> (Resource.Id.appBar);
			SetSupportActionBar (toolbar);
			SupportActionBar.SetTitle (Resource.String.app_name);
			SupportActionBar.SetDisplayHomeAsUpEnabled (true);
			SupportActionBar.SetDisplayUseLogoEnabled (true);

			navigationView = FindViewById<NavigationView> (Resource.Id.nav_view);
			navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

			var drawerToggle = new ActionBarDrawerToggle (this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
			drawerLayout.SetDrawerListener (drawerToggle);
			drawerToggle.SyncState ();

//			Button profile = FindViewById<Button> (Resource.Id.ProfileButton);
//			Button createStudySession = FindViewById<Button> (Resource.Id.CreateStudySession);
//			Button viewStudy = FindViewById<Button> (Resource.Id.ViewSS);
//
			var user= Intent.GetStringExtra("user");
			var key = Intent.GetStringExtra("key");
//			Console.WriteLine (user + " @@@@@ " + key);
//
//			LoginResponse data = new LoginResponse (user, key);
//				
//			profile.Click += async (sender, e) => {
//
//				var Pgetter = new ProfileUtility();
//				ProfileResponse result = await Pgetter.ProfileAsync(data);
//
//				Intent intent = new Intent(this, typeof(StudentProfile));
//				var b = new Bundle();
//				b.PutString("fname",result.fname);
//				b.PutString("lname",result.lname);
//				b.PutString("major",result.major);
//				b.PutString("email",result.email);
//				b.PutString("gender",result.gender);
//				b.PutString("year",result.year);
//				b.PutString("age",result.age.ToString());
//				intent.PutExtras(b);
//				StartActivity(intent);
//			};
//
//			createStudySession.Click += delegate(object sender, EventArgs e) {
//				Intent studySessionIntent = new Intent(this, typeof(StudySessionActivity));
//				StartActivity(studySessionIntent);
//			};
//
//			//StudyResponse studyData = new StudyResponse (LoginInfo.username, LoginInfo.KEY);
//
//			viewStudy.Click += async (sender, e) =>  {
//				var studyInfo = new StudyRequest();
//				StudyResponse info = await studyInfo.StudyRequestAsync(LoginInfo.username, LoginInfo.KEY);
//
//				Intent studySessionIntent = new Intent(this, typeof(ViewStudySessionActivity));
//				var studyBundle = new Bundle();
//				studyBundle.PutString("owner", info.owner);
//				studyBundle.PutString("course", info.course);
//				studyBundle.PutString("topic", info.topic);
//				studyBundle.PutString("date", info.date);
//				studyBundle.PutString("time", info.time);
//				studyBundle.PutString("members", info.members[0]);
//				studyBundle.PutString("members", info.members[1]);
//				studyBundle.PutString("members", info.members[2]);
//				studyBundle.PutString("members", info.members[3]);
//				studyBundle.PutString("members", info.members[4]);
//				studySessionIntent.PutExtras(studyBundle);
//				StartActivity(studySessionIntent);
//			};
//			// Create your application here
		}

		void NavigationView_NavigationItemSelected (object sender, NavigationView.NavigationItemSelectedEventArgs e)
		{
			var ft = FragmentManager.BeginTransaction ();
			ft.AddToBackStack (null);
			switch (e.MenuItem.ItemId) {
			case Resource.Id.nav_home:
				ft.Replace (Resource.Id.FragmentLayout, new homeScreenFragment ());
				ft.AddToBackStack (null);
				ft.Commit ();
				break;
			case Resource.Id.nav_profile:
				ft.Replace(Resource.Id.FragmentLayout, new studentProfileFragment ());
				ft.AddToBackStack (null);
				ft.Commit ();
				break;
			case Resource.Id.nav_study:
				ft.Replace (Resource.Id.FragmentLayout, new studySessionFragment ());
				ft.AddToBackStack (null);
				ft.Commit ();
				break;
			}
			drawerLayout.CloseDrawers ();
		}


		public override void OnBackPressed ()
		{
			if(FragmentManager.BackStackEntryCount!= 0) {
				FragmentManager.PopBackStack ();// fragmentManager.popBackStack();
			} else {
				base.OnBackPressed ();
			}  

				Intent studySessionIntent = new Intent(this, typeof(ViewStudySessionActivity));
				var studyBundle = new Bundle();
//				studyBundle.PutString("owner", info.owner);
//				studyBundle.PutString("course", info.course);
//				studyBundle.PutString("topic", info.topic);
//				studyBundle.PutString("date", info.date);
//				studyBundle.PutString("time", info.time);
//				studyBundle.PutString("members", info.members[0]);
//				studyBundle.PutString("members", info.members[1]);
//				studyBundle.PutString("members", info.members[2]);
//				studyBundle.PutString("members", info.members[3]);
//				studyBundle.PutString("members", info.members[4]);
//				studySessionIntent.PutExtras(studyBundle);
				Console.Write(info);
				StartActivity(studySessionIntent);
			};
			// Create your application here

		}
	}
}

