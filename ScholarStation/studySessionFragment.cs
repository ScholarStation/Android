
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ScholarStation
{
	public class studySessionFragment : Fragment,Android.App.DatePickerDialog.IOnDateSetListener,Android.App.TimePickerDialog.IOnTimeSetListener
	{
		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.StudySessionScreen, container, false);
			view.FindViewById<EditText>(Resource.Id.date).Click += (object sender, EventArgs e) => 
			{
				var dialog = new DatePickerFrag(Activity,DateTime.Now,this);
				dialog.Show(FragmentManager,null);
			};
			view.FindViewById<EditText>(Resource.Id.time).Click += (object sender, EventArgs e) => 
			{
				var dialog = new timePicker(Activity,this,DateTime.Now.Hour,DateTime.Now.Minute,false);
				dialog.Show(FragmentManager,null);
			};

			Button CreateButton = view.FindViewById<Button>(Resource.Id.createSessionButton);
			string[] members = new string[5];
			string studyCourse = "";
			string studyTopic = "";
			string studyDate = "";
			string studyTime = "";
			string studyMember1 = "";
			string studyMember2 = "";
			string studyMember3 = "";
			string studyMember4 = "";
			string studyMember5 = "";

			TextView course = view.FindViewById<TextView> (Resource.Id.courseStudy);
			TextView topic = view.FindViewById<TextView> (Resource.Id.SessionTopic);
			TextView date = view.FindViewById<TextView> (Resource.Id.date);
			TextView time = view.FindViewById<TextView> (Resource.Id.time);
			TextView member1 = view.FindViewById<TextView> (Resource.Id.Member1);
			TextView member2 = view.FindViewById<TextView> (Resource.Id.Member2);
			TextView member3 = view.FindViewById<TextView> (Resource.Id.Member3);
			TextView member4 = view.FindViewById<TextView> (Resource.Id.Member4);
			TextView member5 = view.FindViewById<TextView> (Resource.Id.Member5);

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
				members[0] = studyMember1;
			};
			member2.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyMember2 = e.Text.ToString();
				members[1] = studyMember2;
			};
			member3.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyMember3 = e.Text.ToString();
				members[2] = studyMember3;
			};
			member4.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyMember4 = e.Text.ToString();
				members[3] = studyMember4;
			};
			member5.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				studyMember5 = e.Text.ToString();
				members[4] = studyMember5;
			};
			CreateButton.Click += async (sender, e) => {

				StudyUtility createStudySession = new StudyUtility();

				Task<StudyResponse> stuff = createStudySession.StudyAsync(LoginInfo.username, LoginInfo.KEY, studyCourse, studyTopic, studyDate, studyTime, members);
				StudyResponse result = await stuff;
				var ft = FragmentManager.BeginTransaction ();
				ft.Replace (Resource.Id.FragmentLayout, new homeScreenFragment ());
				ft.AddToBackStack (null);
				ft.Commit ();
				Toast.MakeText (Activity,"Study Group Created", ToastLength.Short).Show ();
			};
						

			return view;
		}
			

		public void OnDateSet(DatePicker view, int year, int month, int day)
		{
			var date = new DateTime (year, month + 1, day);
			View.FindViewById<EditText> (Resource.Id.date).Text = date.ToString ("yyyy MMMMM dd");

		}

		public void OnTimeSet(TimePicker view, int hour, int minute)
		{
			if (hour == 0)
				hour = hour + 12;
			else if (hour > 12)
				hour = hour - 12;
			//corrects minutes to the correct format 0-> 00 etc.
			string formattedMinutes;
			switch (minute) {
			case 0:
				formattedMinutes = "00";
				break;
			case 1:
				formattedMinutes = "01";
				break;
			case 2:
				formattedMinutes = "02";
				break;
			case 3: 
				formattedMinutes = "03";
				break;
			case 4:
				formattedMinutes = "04";
				break;
			case 5:
				formattedMinutes = "05";
				break;
			case 6:
				formattedMinutes = "06";
				break;
			case 7:
				formattedMinutes = "07";
				break;
			case 8:
				formattedMinutes = "08";
				break;
			case 9: 
				formattedMinutes = "09";
				break;				
			default:
				formattedMinutes = minute.ToString ();
				break;
			}

			string test = string.Format ("{0}:{1}", hour, formattedMinutes);
			View.FindViewById<EditText> (Resource.Id.time).Text = test;
		}
	}
}

