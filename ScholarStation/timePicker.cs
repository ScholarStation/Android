
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
	public class timePicker : DialogFragment
	{
		private readonly Context _context;
		private int _hour;
		private int _min;
		private bool _is24hour;
		private readonly Android.App.TimePickerDialog.IOnTimeSetListener _listener;

		public timePicker(Context context, Android.App.TimePickerDialog.IOnTimeSetListener listener, int hour, int min, bool is24hour)
		{
			_context = context;
			_listener = listener;
			_hour = hour;
			_min = min;
			_is24hour = is24hour;
		}

		public override Dialog OnCreateDialog(Bundle savedState) {
			var dialog = new Android.App.TimePickerDialog (_context, _listener, _hour, _min, _is24hour);
			return dialog;
		}
	}
}

