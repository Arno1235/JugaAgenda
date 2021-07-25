using System;
using System.Collections.Generic;

namespace JugaAgenda_v2.Classes
{
    class Day
    {
        private DateTime date;
        private List<Work> workList;
        private List<Technician> technicianList;

        public Day(DateTime date)
        {
            this.date = date;
            this.workList = new List<Work>();
            this.technicianList = new List<Technician>();
        }

        #region getters
        public DateTime getDate()
        {
            return date;
        }
        public List<Work> getWorkList()
        {
            return workList;
        }
        public List<Technician> getTechnicianList()
        {
            return technicianList;
        }
        #endregion

        #region setters
        public void addWorkList(Work work)
        {
            workList.Add(work);
        }
        public void addTechnicianList(Technician technician)
        {
            technicianList.Add(technician);
        }
        #endregion
    }
}
