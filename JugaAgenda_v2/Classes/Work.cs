

namespace JugaAgenda_v2
{
    class Work
    {
        public enum Status
        {
            todo_no_components,
            todo_yes_components,
            doing,
            done
        }

        private string name;
        private decimal duration;
        private string clientName;
        private string phoneNumber;
        private string orderNumber;
        private Status status;

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
            this.status = Status.todo_no_components;
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
        public Status getStatus()
        {
            return status;
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
        public void setStatus(Status status)
        {
            this.status = status;
        }
        #endregion

    }
}
