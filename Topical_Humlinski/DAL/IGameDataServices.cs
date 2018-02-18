using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Topical_Humlinski.Models;

namespace Topical_Humlinski.DAL
{
    /// <summary>
    /// data service interface to read and write an entire file based on the Brewery class
    /// </summary>
    public interface IGameDataService
    {
        List<Game> Read();
        void Write(List<Game> Games);
    }
}