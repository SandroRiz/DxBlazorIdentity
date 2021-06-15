using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DxBlazorIdentity.Data
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTimeOffset? LockoutDate { get; set; }


    }
}
