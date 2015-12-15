using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CorporateAcademyPortalScheduleData
{
    public class ScheduleDataAccess
    {
        public CorporateAcademyPortalDataClassesDataContext objDataContext = new CorporateAcademyPortalDataClassesDataContext();
        /// <summary>
        /// Method for Inserting values into NewEvent Table
        /// </summary>
        /// <param name="bid"></param>
        /// <param name="date"></param>
        /// <param name="topic"></param>
        /// <param name="trainer"></param>
        /// <param name="theoryHours"></param>
        /// <param name="practicalHours"></param>
        public void InsertEvent(NewEvent objEvent)
        {
            objDataContext.NewEvents.InsertOnSubmit(objEvent);
            objDataContext.SubmitChanges();
        }
        /// <summary>
        /// Fetching FromDate from batch table    
        /// </summary>
        /// <param name="batchName"></param>
        /// <returns></returns>
        public DateTime FromDateCalc(string batchName)
        {
            var qry = objDataContext.Batches.Single(p => p.BatchName == batchName);
            return Convert.ToDateTime(qry.FromDate);
        }
        /// <summary>
        /// Fetching ToDate from batch table
        /// </summary>
        /// <param name="batchName"></param>
        /// <returns></returns>
        public DateTime ToDateCalc(string batchName)
        {
            var qry = objDataContext.Batches.Single(p => p.BatchName == batchName);
            return Convert.ToDateTime(qry.ToDate);
        }
        /// <summary>
        ///Fetching Batch Id from batch table 
        /// </summary>
        /// <param name="batchName"></param>
        /// <returns></returns>
        public int BatchId(string batchName)
        {
            var batchDetails = objDataContext.Batches.Single(p => p.BatchName == batchName);
            return batchDetails.BatchId;
        }
        /// <summary>
        /// Fetching Batch Name from batch table
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public string BatchName(int bid)
        {
            try
            {
                var batchDetails = objDataContext.Batches.First(p => p.BatchId == bid);
                return batchDetails.BatchName;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Storing Event Details to list
        /// </summary>
        /// <param name="bid"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<NewEvent> GetEventDetails(int bid, DateTime fromDate, DateTime toDate)
        {
            var eventquery = (from q in objDataContext.GetTable<NewEvent>() where (q.BatchId == bid && (q.Date >= fromDate && q.Date <= toDate)) select q);
            return eventquery.ToList<NewEvent>();
        }
        /// <summary>
        /// Storing Duration between FromDate and ToDate into list
        /// </summary>
        /// <param name="bid"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public List<NewEvent> CalcBetweenDates(int bid, DateTime fromDate, DateTime toDate)
        {
            double duration = (toDate - fromDate).TotalDays;
            var eventquery = (from q in objDataContext.GetTable<NewEvent>() where (q.BatchId == bid && (q.Date >= fromDate && q.Date <= toDate)) select q);
            var dates = new List<NewEvent>();
            for (var dt = fromDate; dt <= toDate; dt = dt.AddDays(1))
            {
                if (!eventquery.Any(_ => _.Date == dt))
                {
                    NewEvent ne = new NewEvent();
                    ne.Date = dt;
                    dates.Add(ne);
                }
            } return dates;
        }
        /// <summary>
        /// Calculating Dates between From and To Dates
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public List<string> CalcDates(int bid)
        {
            var qry = objDataContext.Batches.Single(p => p.BatchId == bid);
            var eventquery = (from q in objDataContext.GetTable<NewEvent>() where (q.BatchId == bid && (q.Date >= FromDateCalc(qry.BatchName) && q.Date <= ToDateCalc(qry.BatchName))) select q.Date);
            var dates = new List<string>();
            for (var dt = FromDateCalc(qry.BatchName); dt <= ToDateCalc(qry.BatchName); dt = dt.AddDays(1))
            {
                dates.Add(dt.ToString().Substring(0, 10));
            }
            return dates;
        }
        /// <summary>
        /// To Delete Event from New Event Table 
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEvent(int id)
        {
            try
            {
                NewEvent obj = new NewEvent();
                var qry = objDataContext.NewEvents.First(p => p.EventId == id);
                objDataContext.NewEvents.DeleteOnSubmit(qry);
                objDataContext.SubmitChanges();
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Updating Table  with edited details in database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="topic"></param>
        /// <param name="trainer"></param>
        /// <param name="practicalHours"></param>
        /// <param name="theoryHours"></param>
        public void EventDetailsWithId(int id, string topic, string trainer, int practicalHours, int theoryHours)
        {
            var qry = objDataContext.NewEvents.First(p => p.EventId == id);
            qry.Topic = topic;
            qry.Trainer = trainer;
            qry.PracticalHours = practicalHours;
            qry.TheoryHours = theoryHours;
            objDataContext.SubmitChanges();
        }
        /// <summary>
        /// To Delete Event from New Event Table 
        /// </summary>
        /// <param name="date"></param>
        public void EventDeleteWithDate(DateTime date)
        {
            NewEvent obj = new NewEvent();
            var qry = objDataContext.NewEvents.Single(p => p.Date == Convert.ToDateTime(date));
            objDataContext.NewEvents.DeleteOnSubmit(qry);
            objDataContext.SubmitChanges();
        }
        /// <summary>
        /// To Edit Event and update it in  New Event Table 
        /// </summary>
        /// <param name="date"></param>
        /// <param name="practicalHours"></param>
        /// <param name="theoryHours"></param>
        /// <param name="trainer"></param>
        /// <param name="topic"></param>
        public void EventEditWithDate(DateTime date, int practicalHours, int theoryHours, string trainer, string topic)
        {
            NewEvent obj = new NewEvent();
            var qry = objDataContext.NewEvents.First(p => p.Date == Convert.ToDateTime(date));
            var bid = qry.BatchId;
            objDataContext.NewEvents.DeleteOnSubmit(qry);
            obj.Date = Convert.ToDateTime(date);
            obj.PracticalHours = Convert.ToInt16(practicalHours);
            obj.TheoryHours = Convert.ToInt16(theoryHours);
            obj.Trainer = trainer;
            obj.Topic = topic;
            obj.BatchId = bid;
            objDataContext.NewEvents.InsertOnSubmit(obj);
            objDataContext.SubmitChanges();
        }
    }
}
