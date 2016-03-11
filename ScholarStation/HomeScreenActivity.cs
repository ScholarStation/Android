
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

			var user= Intent.GetStringExtra("user");
			var key = Intent.GetStringExtra("key");
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
				ft.Replace (Resource.Id.FragmentLayout, new StudyCardFrag ());
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
		}
	}
}
