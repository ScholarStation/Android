
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

namespace ScholarStation
{
	public class DatePickerFrag : DialogFragment
	{
		private readonly Context _context;
		private DateTime _date;
		private readonly Android.App.DatePickerDialog.IOnDateSetListener _listner;

		public DatePickerFrag(Context context, DateTime date, Android.App.DatePickerDialog.IOnDateSetListener listener)
		{
			_context = context;
			_date = date;
			_listner = listener;
		}

		public override Dialog OnCreateDialog(Bundle savedState)
		{
			var dialog = new Android.App.DatePickerDialog (_context, _listner, _date.Year, _date.Month, _date.Day);
			return dialog;
		}
	}
}

