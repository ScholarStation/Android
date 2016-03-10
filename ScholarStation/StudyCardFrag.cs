
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
using Android.Support.V7.Widget;
using System.Threading.Tasks;
using Android.Support.Design.Widget;

namespace ScholarStation
{
	public class StudyCardFrag : Fragment
	{
		public void createFragment(StudyGroup sg,bool create ){
			var ft = FragmentManager.BeginTransaction ();
			if (create) {
			
				ft.Replace (Resource.Id.FragmentLayout, new studySessionFragment ());
			} else {
				
				ft.Replace (Resource.Id.FragmentLayout, new studySessionFragment (sg));
			}
			ft.AddToBackStack (null);
			ft.Commit ();

		}

		 class RecyclerAdapter : RecyclerView.Adapter
		{
			private List<StudyGroup> mStudyGroup;
			private RecyclerView mRecyclerView;
			private StudyCardFrag thisFrag;


			public RecyclerAdapter(List<StudyGroup> studyGroup,RecyclerView rv,StudyCardFrag thisFrag)
			{
				mStudyGroup = studyGroup;
				mRecyclerView = rv;
				this.thisFrag=thisFrag;
			}

			public class MyView : RecyclerView.ViewHolder
			{
				public View mMainView { get; set; }
				public TextView mOwner { get; set; }
				public TextView mCourse { get; set; }
				public TextView mTopic { get; set; }

				public MyView (View view) : base(view)
				{
					mMainView = view;
				}
			}

			public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
			{
				View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row, parent, false);

				TextView studyOwner = row.FindViewById<TextView>(Resource.Id.studyOwner);
				TextView studyCourse = row.FindViewById<TextView>(Resource.Id.studyCourse);
				TextView studyTopic = row.FindViewById<TextView>(Resource.Id.studyTopic);
				MyView view = new MyView(row) { mOwner = studyOwner, mCourse = studyCourse, mTopic = studyTopic };
				return view;
			}

			public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
			{
				MyView myHolder = holder as MyView;
				myHolder.mMainView.Click += mMainView_Click;
				myHolder.mOwner.Text = mStudyGroup[position].owner;
				myHolder.mCourse.Text = mStudyGroup[position].course;
				myHolder.mTopic.Text = mStudyGroup[position].topic;
			}

			void mMainView_Click(object sender, EventArgs e)
			{
				int position =mRecyclerView.GetChildPosition((View)sender);
				// THIS LINE OF CODE IS GARBAGE K? ......int indexPosition = (mStudyGroup.Count - 1) - position;
				Console.WriteLine("CLicked Study Group:"+mStudyGroup[position]._id+"Opening edit menu");


				//test
				thisFrag.createFragment(mStudyGroup[position],false);
			}


			public override int ItemCount
			{
				get { return mStudyGroup.Count; }
			}
		}




		private RecyclerView mRecyclerView;
		private FloatingActionButton mFab;
		//private ListView mListView;
		private RecyclerView.LayoutManager mLayoutManager;
		private RecyclerView.Adapter mAdapter;
		private List<StudyGroup> mStudyGroup;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);




		}

	

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.StudyCardLayout, container, false);
			mRecyclerView = view.FindViewById<RecyclerView> (Resource.Id.recyclerView);
			//mListView = view.FindViewById<ListView> (Resource.Id.lvToDoList);
			mFab = view.FindViewById<FloatingActionButton> (Resource.Id.fab);
			mFab.Click += (sender, e) => {
				Toast.MakeText(Activity, "YOU CLICKED IT", ToastLength.Short).Show();
				createFragment(null,true);
			};
			mStudyGroup = new List<StudyGroup> ();
			StudyRequest asyncStudyRquest = new StudyRequest ();
			Task<StudyResponse> data = asyncStudyRquest.StudyRequestAsync (LoginInfo.username, LoginInfo.KEY);

			StudyResponse results = data.Result;
			List<StudyGroup> resultsList = new List<StudyGroup> (results.studyGroups);

			for (int i = 0; i <resultsList.Count; i++) {
				
				mStudyGroup.Add (resultsList[i]); 
			}

			mLayoutManager = new LinearLayoutManager (view.Context);
			mRecyclerView.SetLayoutManager (mLayoutManager);
			mAdapter = new RecyclerAdapter (mStudyGroup,mRecyclerView,this);
			mRecyclerView.SetAdapter (mAdapter);

			return view;
		}

	}


}

