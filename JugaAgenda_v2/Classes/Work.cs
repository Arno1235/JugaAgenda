using System;

namespace JugaAgenda_v2
{
    class Work
    {
        public enum Status
        {
            todo_no_components,
            todo_yes_components, // 5 = yellow
            doing, // 9 = blue
            done, // 2 = green
            cancel // 8 = gray
        }

        private string description;
        private decimal duration;
        private string clientName;
        private string phoneNumber;
        private string orderNumber;
        private Status status;

        public Work()
        {

        }
        public Work(decimal duration, string clientName, string phoneNumber, string orderNumber, string description, Status status)
        {
            this.description = description;
            this.duration = duration;
            this.clientName = clientName;
            this.phoneNumber = phoneNumber;
            this.orderNumber = orderNumber;
            this.status = status;
        }

        public Work(string[] title, string description, Status status)
        {
            for (int i = 0; i < title.Length; i++)
            {
                if (i == 0) this.duration = Convert.ToDecimal(title[i].Split('u')[0].Replace('.', ','));
                if (i == 1) this.clientName = title[i];
                if (i == 1) this.phoneNumber = title[i];
                if (i == 1) this.orderNumber = title[i];
            }

            this.description = description;
            this.status = status;
        }

        public Work(string[] title, string description, int colorID)
        {
            for (int i = 0; i < title.Length; i++)
            {
                if (i == 0) this.duration = Convert.ToDecimal(title[i].Split('u')[0].Replace('.', ','));
                if (i == 1) this.clientName = title[i];
                if (i == 2) this.phoneNumber = title[i];
                if (i == 3) this.orderNumber = title[i];
            }

            this.description = description;

            this.status = colorID_to_status(colorID);
        }

        public Work(Google.Apis.Calendar.v3.Data.Event item)
        {
            if (check_title(item.Summary))
            {
                String[] title = item.Summary.Split(' ');
                for (int i = 0; i < title.Length; i++)
                {
                    if (i == 0) this.duration = Convert.ToDecimal(title[i].Split('u')[0].Replace('.', ','));
                    if (i == 1) this.clientName = title[i];
                    if (i == 2) this.phoneNumber = title[i];
                    if (i == 3) this.orderNumber = title[i];
                }
                this.description = item.Description;
                this.status = colorID_to_status((int) Convert.ToInt64(item.ColorId));
            }
        }

        public Status colorID_to_status(int colorID)
        {
            switch (colorID)
            {
                case 5:
                    return Status.todo_yes_components;
                case 9:
                    return Status.doing;
                case 2:
                    return Status.done;
                case 8:
                    return Status.cancel;
                default:
                    return Status.todo_no_components;
            }
        }

        public int status_to_colorID(Status status)
        {
            switch (status)
            {
                case Status.todo_yes_components:
                    return 5;
                case Status.doing:
                    return 9;
                case Status.done:
                    return 2;
                case Status.cancel:
                    return 8;
                default:
                    return 0;
            }
        }

        public bool check_title(String title)
        {
            String[] titleArray = title.Split(' ');
            if (titleArray.Length < 3 || titleArray.Length > 4) return false;
            
            if (!titleArray[0].Substring(titleArray[0].Length-1).Equals("u")) return false;
            foreach (char c in titleArray[0].Split('u')[0]) if (!"0123456789.,".Contains(c.ToString())) return false;

            return true;
        }

        #region getters
        public string getDescription()
        {
            return description;
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

        public int getColorID()
        {
            switch (this.status)
            {
                case Status.todo_yes_components:
                    return 5;
                case Status.doing:
                    return 9;
                case Status.done:
                    return 2;
                case Status.cancel:
                    return 8;
                default:
                    return 0;
            }
        }
        #endregion

        #region setters
        public void setDescription(string description)
        {
            this.description = description;
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
