
using DxBlazorIdentity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DxBlazorIdentity.Services
{
    public class VideoService 
    {
       

        public List<Video> ListAsync()
        {

            return new List<Video> { new Video { Title="Foo", Description="Foo Lorem Ipsum", VideoDate=DateTime.Now.Date},
            new Video { Title="Bar", Description="Bar Lorem Ipsum", VideoDate=DateTime.Now.AddDays(-1).Date},
            new Video { Title="Baz", Description="Baz Lorem Ipsum", VideoDate=DateTime.Now.AddDays(-2).Date},
            };
        }

    }
}
