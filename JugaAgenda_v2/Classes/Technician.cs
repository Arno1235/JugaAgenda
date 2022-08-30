﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JugaAgenda_v2.Classes
{
    public class Technician
    {
        private String name;
        private Decimal hours;

        public Technician(String input, Boolean title = false)
        {
            if (title)
            {
                this.name = input.Remove(input.Length - input.Split(' ').Last().Length - 1);
                this.hours = Decimal.Parse(input.Split(' ').Last().Split('u')[0].Replace('.', ','), new NumberFormatInfo() { NumberDecimalSeparator = "," });
            } else
                this.name = input;
        }
        public Technician(String name, Decimal hours)
        {
            this.name = name;
            this.hours = hours;
        }

        #region getters
        public String getName()
        {
            return this.name;
        }
        public Decimal getHours()
        {
            return this.hours;
        }
        #endregion

        #region setters
        public void setName(String name)
        {
            this.name = name;
        }
        public void setHours(Decimal hours)
        {
            this.hours = hours;
        }
        #endregion

        public override bool Equals(Object obj)
        {
            if (this.GetType() != obj.GetType()) return false;

            Technician other = (Technician)obj;
            return this.getName().Equals(other.getName()) && this.getHours().Equals(other.getHours());
        }

        public override string ToString()
        {
            if (this.getHours() == null || this.getHours() == 0) return this.getName();
            return this.getName() + " " + this.getHours().ToString() + "u";
        }
    }
}
