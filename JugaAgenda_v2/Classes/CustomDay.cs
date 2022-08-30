using System;
using System.Collections.Generic;

namespace JugaAgenda_v2.Classes
{
    public class CustomDay
    {
        private DateTime date;
        private List<Work> workList;
        private List<Technician> technicianList;

        public CustomDay(DateTime date)
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

        public void removeWorkList(Work work)
        {
            workList.Remove(work);
        }

        public void addTechnicianList(Technician technician)
        {
            technicianList.Add(technician);
        }

        #endregion

        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType().Equals(obj.GetType())) return false;

            CustomDay other = (CustomDay)obj;

            return
                this.getDate().Year.Equals(other.getDate().Year) &&
                this.getDate().Month.Equals(other.getDate().Month) &&
                this.getDate().Day.Equals(other.getDate().Day);
        }
    }
}
