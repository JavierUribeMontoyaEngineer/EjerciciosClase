using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PruebasExtra
{
    class Customer
    {
        private PropertyInfo[] _PropertyInfos = null;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartCompanyDate { get; set; }
        public string State { get; set; }
        public int IdCity { get; set; }
        public int MonthlyDiscount { get; set; }
        public Package Packet { get; set; }

        public override string ToString()
        {
            if (_PropertyInfos == null)
                _PropertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }

    }

    class Package
    {
        private PropertyInfo[] _PropertyInfos = null;

        public int Id { get; set; }
        public int Speed { get; set; }
        public override string ToString()
        {
            if (_PropertyInfos == null)
                _PropertyInfos = this.GetType().GetProperties();

            var sb = new StringBuilder();

            foreach (var info in _PropertyInfos)
            {
                var value = info.GetValue(this, null) ?? "(null)";
                sb.AppendLine(info.Name + ": " + value.ToString());
            }

            return sb.ToString();
        }
    }

    class Ciudad
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
