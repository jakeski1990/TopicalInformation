using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Topical_Humlinski.Models;
using System.Xml.Serialization;

namespace Topical_Humlinski.DAL
{
    public class GameXmlDataServices : IGameDataService, IDisposable
    {
        public List<Game> Read()
        {
            // a Games model is defined to pass a type to the XmlSerializer object 
            Games gamesObject;

            // initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamReader sReader = new StreamReader(xmlFilePath);

            // initialize an XML seriailizer object
            XmlSerializer deserializer = new XmlSerializer(typeof(Games));

            using (sReader)
            {
                // deserialize the XML data set into a generic object
                object xmlObject = deserializer.Deserialize(sReader);

                // cast the generic object to the list class
                gamesObject = (Games)xmlObject;
            }

            return gamesObject.games;
        }

        public void Write(List<Game> games)
        {
            // initialize a FileStream object for reading
            string xmlFilePath = HttpContext.Current.Application["dataFilePath"].ToString();
            StreamWriter sWriter = new StreamWriter(xmlFilePath, false);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Game>), new XmlRootAttribute("Games"));

            using (sWriter)
            {
                serializer.Serialize(sWriter, games);
            }
        }

        public void Dispose()
        {
            // set resources to be cleaned up
        }


    }
}