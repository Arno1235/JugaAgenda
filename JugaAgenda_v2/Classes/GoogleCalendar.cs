using System;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;

namespace JugaAgenda_v2
{

    public class SyncCalendar
    {

        protected GoogleCalendar googleCalendar;
        protected string calendarID;

        protected string syncToken = null;
        private int syncTokenErrorCode = -2146233088;

        public SyncCalendar(GoogleCalendar googleCalendar, string calendarID)
        {
            this.googleCalendar = googleCalendar;
            this.calendarID = calendarID;
        }

        #region Event functions

        // TODO: perspective months?
        // TODO: return type?
        public virtual IList<Event> getEvents()
        {
            EventsResource.ListRequest request = this.googleCalendar.service.Events.List(this.calendarID);

            request.TimeMin = DateTime.Now.AddMonths(-2);
            request.TimeMax = DateTime.Now.AddMonths(5);
            request.ShowDeleted = false;
            request.SingleEvents = true;

            Events events = request.Execute();
            this.syncToken = events.NextSyncToken;

            return (List<Event>)events.Items;
        }

        // TODO: return type?
        public IList<Event> sync()
        {

            if (this.syncToken == null) return this.getEvents();

            EventsResource.ListRequest request = this.googleCalendar.service.Events.List(this.calendarID);
            request.SyncToken = this.syncToken;

            // Retrieve the events, one page at a time.
            String pageToken = null;
            Events events = null;
            IList<Event> eventsList = null;

            do
            {

                request.PageToken = pageToken;

                try
                {
                    events = request.Execute();
                    this.syncToken = events.NextSyncToken;
                }
                catch (Exception e)
                {
                    if (e.HResult == syncTokenErrorCode)
                    {
                        return this.getEvents();
                    }
                }

                IList<Event> items = events.Items;

                if (items.Count < 1) return eventsList;

                // Can be more efficient
                if (eventsList == null) eventsList = new List<Event>();
                foreach (Event item in items) eventsList.Add(item);

            } while (pageToken != null);

            return eventsList;

        }

        public bool addEvent(Event new_event)
        {
            try
            {
                this.googleCalendar.service.Events.Insert(new_event, this.calendarID).Execute();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editEvent(Event new_event)
        {
            try
            {
                this.googleCalendar.service.Events.Update(new_event, this.calendarID, new_event.Id).Execute();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteEvent(String eventID)
        {
            try
            {
                this.googleCalendar.service.Events.Delete(this.calendarID, eventID).Execute();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

    }

    public class TechnicianWorkWeek : SyncCalendar
    {
        public TechnicianWorkWeek(GoogleCalendar googleCalendar, string calendarID) : base(googleCalendar, calendarID)
        {
        }

        public override IList<Event> getEvents()
        {
            EventsResource.ListRequest request = this.googleCalendar.service.Events.List(this.calendarID);

            // Read technician times from 1/02/2021 to 8/02/2021
            request.TimeMin = new DateTime(2021, 2, 1);
            request.TimeMax = new DateTime(2021, 2, 8);
            request.ShowDeleted = false;
            request.SingleEvents = true;

            Events events = request.Execute();
            this.syncToken = events.NextSyncToken;

            return (List<Event>)events.Items;
        }

    }

    public class GoogleCalendar
    {
        // https://console.cloud.google.com/

        private string[] Scopes = { CalendarService.Scope.Calendar };
        private string ApplicationName = "JugaAgenda";

        // Test calendars
        private string jsonPath = "Google Auth Files/client_secret_517386861162-oml2v6ifqe37dbsh4ls2u023pp89c9de.apps.googleusercontent.com.json";
        private string calendarWorkID = "pvdr3fefd859hoau6aop4jn9p8@group.calendar.google.com";
        private string calendarLeaveID = "f0msdqpsli7f1emtmfboq8b8n4@group.calendar.google.com";
        private string calendarTechnicianID = "5q2ig7mop16pnodn500q0jm0uo@group.calendar.google.com";
        private string calendarExtraID = "a3c33fa741c02ce959e1280adc804b3351c1a5aeac9f63c9df5dca07d6d7598b@group.calendar.google.com";

        // Real calendars
        //private string jsonPath = "Google Auth Files/client_secret_273543429520-3pro0k2q9j6ds6bdlle2eibj2tiraada.apps.googleusercontent.com.json";
        //private string calendarWorkID = "juga.be_lt432eq2jhcnic90u877av3tjs@group.calendar.google.com";
        //private string calendarLeaveID = "juga.be_h8t5taanp7k8q7aoj32pkrmbb4@group.calendar.google.com";
        //private string calendarTechnicianID = "c_bu9tsbi0bsgqdpeb36uoarm2e0@group.calendar.google.com";

        private string publicHolidaysID = "nl.be#holiday@group.v.calendar.google.com";

        public CalendarService service { get; private set; }

        private int perspectiveMonths;

        private String success;

        public SyncCalendar workCalendar { get; private set; }
        public SyncCalendar leaveCalendar { get; private set; }
        public SyncCalendar technicianCalendar { get; private set; }
        public SyncCalendar extraCalendar { get; private set; }
        public SyncCalendar holidaysCalendar { get; private set; }

        public GoogleCalendar()
        {
            try
            {

                UserCredential credential;
                perspectiveMonths = 5;

                using (var stream =
                    new FileStream(jsonPath, FileMode.Open, FileAccess.Read))
                {
                    // The file token.json stores the user's access and refresh tokens, and is created
                    // automatically when the authorization flow completes for the first time.
                    string credPath = "token.json";
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                    //Console.WriteLine("Credential file saved to: " + credPath);
                }

                // Create Google Calendar API service.
                service = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                workCalendar = new SyncCalendar(this, calendarWorkID);
                leaveCalendar = new SyncCalendar(this, calendarLeaveID);
                technicianCalendar = new TechnicianWorkWeek(this, calendarTechnicianID);
                extraCalendar = new SyncCalendar(this, calendarExtraID);
                holidaysCalendar = new SyncCalendar(this, publicHolidaysID);

            }
            catch (Exception ex)
            {
                success = ex.ToString();
            }
        }

        public bool testConnection()
        {

            try
            {
                EventsResource.ListRequest request;

                request = service.Events.List(calendarWorkID);
                request.Execute();

                request = service.Events.List(calendarLeaveID);
                request.Execute();

                request = service.Events.List(calendarTechnicianID);
                request.Execute();

                return true;
            }
            catch
            {
                return false;
            }
        }

        #region getters

        public String getSuccess()
        {
            return success;
        }

        #endregion

        #region setters

        public void setPerspectiveMonths(int perspectiveMonths)
        {
            this.perspectiveMonths = perspectiveMonths;
        }

        #endregion

    }

}