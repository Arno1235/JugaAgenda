﻿using System;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Threading;

namespace JugaAgenda_v2
{
    class GoogleCalendar
    {
        private string[] Scopes = { CalendarService.Scope.CalendarReadonly };
        private string ApplicationName = "JugaAgenda";
        private string jsonPath = "Google Auth Files/client_secret_517386861162-oml2v6ifqe37dbsh4ls2u023pp89c9de.apps.googleusercontent.com.json";
        private string calendarWorkID = "pvdr3fefd859hoau6aop4jn9p8@group.calendar.google.com";
        private string calendarLeaveID = "f0msdqpsli7f1emtmfboq8b8n4@group.calendar.google.com";
        private string calendarTechnicianID = "5q2ig7mop16pnodn500q0jm0uo@group.calendar.google.com";
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
                    GoogleClientSecrets.Load(stream).Secrets,
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

        #region getters
        public Events getWorkEvents()
        {
            EventsResource.ListRequest request = service.Events.List(calendarWorkID);
            request.TimeMin = DateTime.Now.AddMonths(-1);
            request.TimeMax = DateTime.Now.AddMonths(perspectiveMonths);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            return request.Execute();
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
            request.TimeMin = DateTime.Now.AddMonths(-1);
            request.TimeMax = DateTime.Now.AddMonths(perspectiveMonths);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            return request.Execute();
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
