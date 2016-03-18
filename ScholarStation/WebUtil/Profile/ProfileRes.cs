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

namespace ScholarStation.WebUtil.Profile
{
    class ProfileRes:WebResponse
    {
        public string fname { get; set; }
        public string lname { get; set; }
        public string major { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string year { get; set; }
        public int age { get; set; }
    }
}