using System;
using System.Collections.Generic;

namespace JugaAgenda_v2.Classes
{
    class Day
    {
        private DateTime date;
        private List<Work> workList;

        public Day(DateTime date)
        {
            this.date = date;
            this.workList = new List<Work>();
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
        #endregion

        #region setters
        public void addWorkList(Work work)
        {
            workList.Add(work);
        }
        #endregion
    }
}
