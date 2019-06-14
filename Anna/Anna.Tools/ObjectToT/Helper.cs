using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Xml;
using OfficeOpenXml;

namespace Anna.Tools.ObjectToT
{
    public class Helper
    {
        public void SaveToXml<T>(ObjectSource<T> data, string root, string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (XmlTextWriter w = new XmlTextWriter(fs, Encoding.UTF8))
                {
                    w.WriteStartDocument();
                    w.WriteStartElement(root);

                    string node = data.Items[0].GetType().Name.ToLower();
                    var fields = data.Fields.OrderBy(o => o.Rank);
                    foreach (var item in data.Items)
                    {
                        w.WriteStartElement(node);

                        foreach (var field in fields)
                        {
                            PropertyInfo p = item.GetType().GetProperty(field.Name);
                            object v = p.GetValue(item);
                            w.WriteElementString(field.Node, v.ToString());
                        }

                        w.WriteEndElement();
                    }

                    w.WriteEndElement();
                }
            }
        }

        public void SaveToExcel<T>(ObjectSource<T> data, string worksheetName, string path)
        {
            FileInfo f = new System.IO.FileInfo(path);
            if (f.Exists)
                f.Delete();

            using (ExcelPackage ep = new ExcelPackage(f))
            {
                ExcelWorksheet ws = ep.Workbook.Worksheets.Add(worksheetName);
                var fields = data.Fields.OrderBy(o => o.Rank).ToArray();

                for(int x = 0; x < fields.Length; x++)
                    ws.Cells[1, x+1].Value = fields[x].Header;

                var items = data.Items.ToArray();

                for (int y = 0; y < items.Length; y++)
                {
                    var item = items[y];
                    for (int x = 0; x < fields.Length; x++)
                    {
                        var field = fields[x];
                        PropertyInfo p = item.GetType().GetProperty(field.Name);
                        object v = p.GetValue(item);
                        ws.Cells[y + 2, x + 1].Value = v;
                    }
                }

                ep.Save();
            }
        }
    }
}
