using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Topical_Humlinski.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Release { get; set; }
        public string Price { get; set; }
        public string Platform { get; set; }
        public string Publisher { get; set; }


    }
}