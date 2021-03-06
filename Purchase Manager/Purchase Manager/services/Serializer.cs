using Purchase_Manager.BL;
using Purchase_Manager.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
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

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Profile));

            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, profile);
            }
        }

        public void Serialize(Profile profile, string xmlName)
        {
            string path;
            string filename = null;
            try
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                filename = Path.Combine(path, xmlName);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The XML-file doesn't exist!");
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Profile));

            try
            {
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    xmlSerializer.Serialize(fs, profile);
                }
            }
            catch (FormatException)
            {
                throw new FormatException("The XML-file contains invalid data!");
            }
            catch
            {
                throw new Exception();
            }
        }
        public Profile Deserialize(string xmlName)
        {
            string path;
            string filename = null;
            Profile profile = null;

            try
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                filename = Path.Combine(path, xmlName);
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The XML-file doesn't exist!");
            }
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Profile));

            try
            {
                string rawXML = File.ReadAllText(filename);
                string cleanXML = Regex.Replace(rawXML, @"(?<=</Profile>)[\w\W]*</Profile>", "");
                File.WriteAllText(filename, cleanXML);
                string test = File.ReadAllText(filename);
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {                   
                    profile = (Profile)xmlSerializer.Deserialize(fs);
                }
            }
            catch (FormatException)
            {
                throw new FormatException("The XML-file contains invalid data!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return profile;
        }
    }
}
