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

namespace ScholarStation.WebUtil.StudyGroup
{
    class StudyEdtReq:WebRequest
    {
        public string owner { get; set; }
        public string _id { get; set; }
        public string course { get; set; }
        public string topic { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string[] members { get; set; }
    }
}