using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace JugaAgenda_v2.Classes
{
    class Day
    {
        private DateTime date;
        private ArrayList workList;

        public Day(DateTime date)
        {
            this.date = date;
        }

        #region getters
        public ArrayList getWorkList()
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
