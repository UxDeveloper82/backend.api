using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class Repairs
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public int Price { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Days { get; set; }

        public string Area { get; set; }

        public string imageUrl { get; set; }

    }
}
