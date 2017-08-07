using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace PruebasExtra
{
    class Product
    {
        private PropertyInfo[] _PropertyInfos = null;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Category { get; set; }
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

   
}
