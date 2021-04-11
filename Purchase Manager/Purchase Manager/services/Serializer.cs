using Purchase_Manager.BL;
using Purchase_Manager.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Purchase_Manager.services
{
    public class Serializer
    {
        public Serializer() { }
        public void SerializeDefault()
        {
            Profile profile = new Profile();
            ProfileBL profileBL = new ProfileBL(profile);
            profileBL.CreateDefaultProfile("Test");

            var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var filename = Path.Combine(path, "Test_user.xml");

            /*XDocument document = new XDocument(
                new XElement("Profile",
                    new XElement("User",
                        new XAttribute("Name", "Test"),
                        new XAttribute("Registration Date", DateTime.Now)),
                    new XElement("Categories",
                        new XAttribute("Name" ,profile.Categories)
                )));*/

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Profile));

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, profile);
            }
        }
    }
}
