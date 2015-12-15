using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorporateAcademyPortalScheduleBusinessObject
{
    public class NewEvent
    {
        //Getters and Setter Properties For Batch Schedule
        public int EventId { set; get; }
        public int BatchId { set; get; }
        public DateTime Date { set; get; }
        public string Topic { set; get; }
        public string Trainer { set; get; }
        public int TheoryHours { set; get; }
        public int PracticalHours { set; get; }
    }
}
