
using DxBlazorIdentity.Data;
using DxBlazorIdentity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxBlazorIdentity.Services
{
    public class PersonService 
    {
       

        public List<Person> List()
        {
            return GetFakeList();
        }


        public Person Get(string ids)
        {
            List<Person> list = GetFakeList();
            int id = 0;
            if (Int32.TryParse(ids, out id))
                return list.Find(x => x.Id == id);
            else
                return new Person();
        }

        private List<Person> GetFakeList()
        {
            return new List<Person> {
                new Person { Id = 1, Name = "Foo", LockoutDate = DateTime.Now.Date, Age=33, IsAdult=true, Weight=54.6M },
                new Person { Id = 2, Name = "Bar", LockoutDate = DateTime.Now.Date.AddDays(1) },
                new Person { Id = 3, Name = "Baz", LockoutDate = null },
            };
        }

    }
}
