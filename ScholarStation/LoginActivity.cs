using Android.App;
using Android.Widget;
using Android.OS;
using Android.Util;
using System.Threading.Tasks;
using Android.Content;

namespace ScholarStation
{
	[Activity (Label = "Log In",Icon = "@mipmap/icon")]	
	public class LoginActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			
			//Log.Info(tag, "STUFF WILL HAPPEN");
			base.OnCreate (savedInstanceState);
			string username = "";
			string password = "";
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Login);

			// Get our button from the layout resource,
			// and attach an event to it
			Button login = FindViewById<Button> (Resource.Id.LoginButton);
			TextView userName = FindViewById<TextView> (Resource.Id.UserName);
			TextView passWord = FindViewById<TextView> (Resource.Id.Password);
			userName.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				username = e.Text.ToString();
			};

			passWord.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				password = e.Text.ToString();
			};

			login.Click += async (sender, e) =>  {
				
				try{
					var login_er =new LoginUtility();
					Task<LoginResponse> asdfg = login_er.LoginAsync(username, password);

					LoginResponse result = await asdfg;
					if(result.validate){
						Intent intent = new Intent(this, typeof(HomeScreenActivity));
						var b = new Bundle();
						b.PutString("user",result.username);
						b.PutString("key",result.KEY);
						intent.PutExtras(b);

						StartActivity(intent);

						LoginInfo.username = result.username;
						LoginInfo.KEY = result.KEY;
					}else{
						Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
						AlertDialog alertDialog = builder.Create();
						alertDialog.SetTitle("Login Failed");
						alertDialog.SetMessage("Login Failed, Please Try Again");
						alertDialog.Show();

						//Log.Info(tag, "STUFF WILL HAPPEN"+ result.ToString());
					}
				}
				catch (AndroidException){
					
				}

			};

		}
	}
}


