using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Topical_Humlinski.Models
{
    [XmlRoot("Games")]
    public class Games
    {
        [XmlElement("Game")]
        public List<Game> games;

    }
}