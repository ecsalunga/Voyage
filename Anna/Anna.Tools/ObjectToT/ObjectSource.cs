using System;
using System.Collections.Generic;
using System.Text;

namespace Anna.Tools.ObjectToT
{
    public class ObjectSource<T>
    {
        public List<Field> Fields { get; set; }
        public List<T> Items { get; set; }

        public ObjectSource(List<Field> fields, List<T> items)
        {
            this.Fields = fields;
            this.Items = items;
        }
    }
}
