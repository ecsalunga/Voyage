using Microsoft.VisualStudio.TestTools.UnitTesting;
using Anna.Tools.ObjectToT;
using System.Collections.Generic;
using System;

namespace Anna.Test
{
    [TestClass]
    public class ObjectToT_Test
    {
        [TestMethod]
        public void Helper_SaveToXml()
        {
            ObjectSource<Person> data = GetData();
            Helper helper = new Helper();
            helper.SaveToXml<Person>(data, "persons", AppDomain.CurrentDomain.BaseDirectory + "\\persons.xml");
        }

        [TestMethod]
        public void Helper_SaveToExcel()
        {
            ObjectSource<Person> data = GetData();
            Helper helper = new Helper();
            helper.SaveToExcel<Person>(data, "Persons", AppDomain.CurrentDomain.BaseDirectory + "\\persons.xlsx");
        }

        private ObjectSource<Person> GetData()
        {
            // define the fields
            List<Field> fields = new List<Field>();
            fields.Add(new Field() { Name = "Name", Header = "Name", Node = "name", Rank = 1 });
            fields.Add(new Field() { Name = "Email", Header = "Email", Node = "email", Rank = 2 });

            // get the records
            List<Person> items = new List<Person>();
            items.Add(new Person() { Name = "Emmanuel", Email = "emmanuel.salunga@gmail.com" });
            items.Add(new Person() { Name = "Anna Paula", Email = "anna.paula.parallag@gmail.com" });
            return new ObjectSource<Person>(fields, items);
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
