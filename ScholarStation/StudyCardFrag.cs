
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

namespace ScholarStation
{
	public class StudyCardFrag : Fragment
	{
		private RecyclerView mRecyclerView;
		private RecyclerView.LayoutManager mLayoutManager;
		private RecyclerView.Adapter mAdapter;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.StudyCardLayout, container, false);

			return base.OnCreateView (inflater, container, savedInstanceState);
		}
	}
	public class RecyclerAdapter : RecyclerView.Adapter
	{
//		private List<Email> mEmails;
//
//		public RecyclerAdapter(List<Email> emails)
//		{
//			mEmails = emails;
//		}

		public class MyView : RecyclerView.ViewHolder
		{
			public View mMainView { get; set; }
			public TextView mName { get; set; }
			public TextView mSubject { get; set; }
			public TextView mMessage { get; set; }

			public MyView (View view) : base(view)
			{
				mMainView = view;
			}
		}

		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row, parent, false);

//			TextView txtName = row.FindViewById<TextView>(Resource.Id.txtName);
//			TextView txtSubject = row.FindViewById<TextView>(Resource.Id.txtSubject);
//			TextView txtMessage = row.FindViewById<TextView>(Resource.Id.txtMessage);
//
//			MyView view = new MyView(row) { mName = txtName, mSubject = txtSubject, mMessage = txtMessage };
			return view;
		}

		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			MyView myHolder = holder as MyView;
//			myHolder.mName.Text = mEmails[position].Name;
//			myHolder.mSubject.Text = mEmails[position].Subject;
//			myHolder.mMessage.Text = mEmails[position].Message;
		}

//		public override int ItemCount
//		{
////			get { return mEmails.Count; }
//		}
	}

}

