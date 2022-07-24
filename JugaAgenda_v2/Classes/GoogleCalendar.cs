using System;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;
using System.Collections.Generic;
using JugaAgenda_v2.Classes;

namespace JugaAgenda_v2
{
    public class GoogleCalendar
    {
        // https://console.cloud.google.com/

        //private string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        private string[] Scopes = { CalendarService.Scope.Calendar };
        private string ApplicationName = "JugaAgenda";
        //private string jsonPath = "Google Auth Files/client_secret_517386861162-oml2v6ifqe37dbsh4ls2u023pp89c9de.apps.googleusercontent.com.json";
        private string jsonPath = "Google Auth Files/client_secret_273543429520-3pro0k2q9j6ds6bdlle2eibj2tiraada.apps.googleusercontent.com.json";

        //private string calendarWorkID = "pvdr3fefd859hoau6aop4jn9p8@group.calendar.google.com";
        //private string calendarLeaveID = "f0msdqpsli7f1emtmfboq8b8n4@group.calendar.google.com";
        //private string calendarTechnicianID = "5q2ig7mop16pnodn500q0jm0uo@group.calendar.google.com";

        private string calendarWorkID = "juga.be_lt432eq2jhcnic90u877av3tjs@group.calendar.google.com";
        private string calendarLeaveID = "juga.be_h8t5taanp7k8q7aoj32pkrmbb4@group.calendar.google.com";
        private string calendarTechnicianID = "c_j3nsdhak5j40u1qtu5s5valkjk@group.calendar.google.com";

        private string workSyncToken = null;
        private int syncTokenErrorCode = -2146233088;

        private CalendarService service;

        private int perspectiveMonths;

        public GoogleCalendar()
        {
            UserCredential credential;
            perspectiveMonths = 3;

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
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Google Calendar API service.
            service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
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
            } catch
            {
                return false;
            }
        }

        #region getters
        public IList<Event> getWorkEvents() // TODO: add multiple pages
        {
            EventsResource.ListRequest request = service.Events.List(calendarWorkID);
            request.TimeMin = DateTime.Now.AddMonths(-1);
            request.TimeMax = DateTime.Now.AddMonths(perspectiveMonths);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            // request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime; // Doesn't work with synctoken

            Events events = request.Execute();
            workSyncToken = events.NextSyncToken;

            return (List<Event>) events.Items;
        }

        public IList<Event> sync()
        {

            if (workSyncToken == null) return getWorkEvents();

            EventsResource.ListRequest request = service.Events.List(calendarWorkID);
            request.SyncToken = workSyncToken;

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
                    workSyncToken = events.NextSyncToken;
                }
                catch (Exception e)
                {
                    if (e.HResult == syncTokenErrorCode)
                    {
                        return getWorkEvents();
                    }
                }

                IList<Event> items = events.Items;

                if (items.Count < 1) return null;

                // Can be more efficient
                if (eventsList == null) eventsList = new List<Event>();
                foreach (Event item in items) eventsList.Add(item);

            } while (pageToken != null);

            return eventsList;

        }

        public Events getLeaveEvents()
        {
            EventsResource.ListRequest request = service.Events.List(calendarLeaveID);
            request.TimeMin = DateTime.Now.AddMonths(-1);
            request.TimeMax = DateTime.Now.AddMonths(perspectiveMonths);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            return request.Execute();
        }
        public Events getTechnicianEvents()
        {
            EventsResource.ListRequest request = service.Events.List(calendarTechnicianID);
            // Read technician times from 1/02/2021 to 8/02/2021
            request.TimeMin = new DateTime(2021, 2, 1);
            request.TimeMax = new DateTime(2021, 2, 8);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            return request.Execute();
        }
            #endregion

        #region setters

        public bool addWorkEvent(Event new_event)
        {
            try
            {
                service.Events.Insert(new_event, calendarWorkID).Execute();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editWorkEvent(Event new_event)
        {
            try
            {
                service.Events.Update(new_event, calendarWorkID, new_event.Id).Execute();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editTechnicianEvent(Event new_event)
        {
            try
            {
                service.Events.Update(new_event, calendarTechnicianID, new_event.Id).Execute();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool editLeaveEvent(Event new_event)
        {
            try
            {
                service.Events.Update(new_event, calendarLeaveID, new_event.Id).Execute();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool deleteWorkEvent(String eventID)
        {
            try
            {
                service.Events.Delete(calendarWorkID, eventID).Execute();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void setPerspectiveMonths(int perspectiveMonths)
        {
            this.perspectiveMonths = perspectiveMonths;
        }
    #endregion

    }

}
