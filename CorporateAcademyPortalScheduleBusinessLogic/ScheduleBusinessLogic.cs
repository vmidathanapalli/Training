using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CorporateAcademyPortalScheduleBusinessObject;
using CorporateAcademyPortalScheduleData;

namespace CorporateAcademyPortalScheduleBusinessLogic
{
    public class BatchScheduleBusiness
    {
        /// <summary>
        /// Call Method for Inserting Event in DAtaAccess Layer
        /// </summary>
        /// <param name="bid"></param>
        /// <param name="date"></param>
        /// <param name="topic"></param>
        /// <param name="trainer"></param>
        /// <param name="theoryHours"></param>
        /// <param name="practicalHours"></param>
        public void InsertEvent(CorporateAcademyPortalScheduleBusinessObject.NewEvent objEvent)
        {
            CorporateAcademyPortalScheduleData.NewEvent ne = new CorporateAcademyPortalScheduleData.NewEvent();
            ne.BatchId = objEvent.BatchId;
            ne.Date = objEvent.Date;
            ne.Topic = objEvent.Topic;
            ne.Trainer = objEvent.Trainer;
            ne.TheoryHours = objEvent.TheoryHours;
            ne.PracticalHours = objEvent.PracticalHours;
            new ScheduleDataAccess().InsertEvent(ne);
        }
        /// <summary>
        /// Call Method for FromDateCalc
        /// </summary>
        /// <param name="batchName"></param>
        /// <returns></returns>
        public DateTime FromDateCalc(string batchName)
        {
            return new ScheduleDataAccess().FromDateCalc(batchName);
        }
        /// <summary>
        /// Call Method for ToDateCalc
        /// </summary>
        /// <param name="batchName"></param>
        /// <returns></returns>
        public DateTime ToDateCalc(string batchName)
        {
            return new ScheduleDataAccess().ToDateCalc(batchName);
        }
        /// <summary>
        /// Call Method for fetching BatchID
        /// </summary>
        /// <param name="batchName"></param>
        /// <returns></returns>
        public int BatchId(string batchName)
        {
            return new ScheduleDataAccess().BatchId(batchName);
        }
        /// <summary>
        /// Call Method of GetEventDetails
        /// </summary>
        /// <param name="batchName"></param>
        /// <returns></returns>
        public List<CorporateAcademyPortalScheduleBusinessObject.NewEvent> GetEventDetails(string batchName)
        {
            var result = new ScheduleDataAccess().GetEventDetails(new ScheduleDataAccess().BatchId(batchName), new ScheduleDataAccess().FromDateCalc(batchName), new ScheduleDataAccess().ToDateCalc(batchName));
            List<CorporateAcademyPortalScheduleBusinessObject.NewEvent> list = new List<CorporateAcademyPortalScheduleBusinessObject.NewEvent>();
            foreach (CorporateAcademyPortalScheduleData.NewEvent point in result)
            {
                CorporateAcademyPortalScheduleBusinessObject.NewEvent objNewEvent = new CorporateAcademyPortalScheduleBusinessObject.NewEvent();
                objNewEvent.BatchId = Convert.ToInt32(point.BatchId);
                objNewEvent.Date = Convert.ToDateTime(point.Date);
                objNewEvent.EventId = point.EventId;
                objNewEvent.PracticalHours = Convert.ToInt32(point.PracticalHours);
                objNewEvent.TheoryHours = Convert.ToInt32(point.TheoryHours);
                objNewEvent.Topic = point.Topic;
                objNewEvent.Trainer = point.Trainer;
                list.Add(objNewEvent);
            }
            return list;
        }
        /// <summary>
        ///Call Method of Calculating Between dates
        /// </summary>
        /// <param name="batchName"></param>
        /// <returns></returns>
        public List<CorporateAcademyPortalScheduleBusinessObject.NewEvent> CalcBetweenDates(string batchName)
        {
            var result = new ScheduleDataAccess().CalcBetweenDates(new ScheduleDataAccess().BatchId(batchName), new ScheduleDataAccess().FromDateCalc(batchName), new ScheduleDataAccess().ToDateCalc(batchName));
            CorporateAcademyPortalScheduleBusinessObject.NewEvent objNewEvent = new CorporateAcademyPortalScheduleBusinessObject.NewEvent();
            List<CorporateAcademyPortalScheduleBusinessObject.NewEvent> list = new List<CorporateAcademyPortalScheduleBusinessObject.NewEvent>();
            foreach (CorporateAcademyPortalScheduleData.NewEvent point in result)
            {
                objNewEvent.BatchId = Convert.ToInt32(point.BatchId);
                objNewEvent.Date = Convert.ToDateTime(point.Date);
                objNewEvent.EventId = point.EventId;
                objNewEvent.PracticalHours = Convert.ToInt32(point.PracticalHours);
                objNewEvent.TheoryHours = Convert.ToInt32(point.TheoryHours);
                objNewEvent.Topic = point.Topic;
                objNewEvent.Trainer = point.Trainer;
                list.Add(objNewEvent);
            }
            return list;
        }
        /// <summary>
        ///Call Method of Calculating Between dates
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public List<string> CalcDates(int batchId)
        {
            return new ScheduleDataAccess().CalcDates(batchId);
        }
        /// <summary>
        /// Call Method of Delete Event
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEvent(int id)
        {
            try
            {
                new ScheduleDataAccess().DeleteEvent(id);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        ///Call Method for fetching BatchName 
        /// </summary>
        /// <param name="bid"></param>
        /// <returns></returns>
        public string BatchName(int bid)
        {
            try
            {
                return new ScheduleDataAccess().BatchName(bid);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// Calling EventDetails method
        /// </summary>
        /// <param name="Eventid"></param>
        /// <param name="topic"></param>
        /// <param name="trainer"></param>
        /// <param name="practicalHours"></param>
        /// <param name="theoryHours"></param>
        public void EventDetailsWithId(int Eventid, string topic, string trainer, int practicalHours, int theoryHours)
        {
            new ScheduleDataAccess().EventDetailsWithId(Eventid, topic, trainer, practicalHours, theoryHours);
        }
        /// <summary>
        /// Calling EventDetails method
        /// </summary>
        /// <param name="date"></param>
        public void EventDeleteWithDate(DateTime date)
        {
            new ScheduleDataAccess().EventDeleteWithDate(date);
        }
        /// <summary>
        /// Calling EventDetails method for editing
        /// </summary>
        /// <param name="date"></param>
        /// <param name="practicalHours"></param>
        /// <param name="theoryHours"></param>
        /// <param name="trainer"></param>
        /// <param name="topic"></param>
        public void EventEditWithDate(DateTime date, int practicalHours, int theoryHours, string trainer, string topic)
        {
            new ScheduleDataAccess().EventEditWithDate(date, practicalHours, theoryHours, trainer, topic);
        }
    }
}
