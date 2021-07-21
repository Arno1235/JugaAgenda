using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JugaAgenda_v2
{
    class Work
    {
        private string name;
        private decimal duration;
        private string clientName;
        private string phoneNumber;
        private string orderNumber;

        public Work()
        {

        }
        public Work(string name, decimal duration, string clientName, string phoneNumber, string orderNumber)
        {
            this.name = name;
            this.duration = duration;
            this.clientName = clientName;
            this.phoneNumber = phoneNumber;
            this.orderNumber = orderNumber;
        }

        #region getters
        public string getName()
        {
            return name;
        }
        public decimal getDuration()
        {
            return duration;
        }
        public string getClientName()
        {
            return clientName;
        }
        public string getPhoneNumber()
        {
            return phoneNumber;
        }
        public string getOrderNumber()
        {
            return orderNumber;
        }
        #endregion

        #region setters
        public void setName(string name)
        {
            this.name = name;
        }
        public void setDuration(decimal duration)
        {
            this.duration = duration;
        }
        public void setClientName(string clientName)
        {
            this.clientName = clientName;
        }
        public void setPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }
        public void setOrderNumber(string orderNumber)
        {
            this.orderNumber = orderNumber;
        }
        #endregion

    }
}
