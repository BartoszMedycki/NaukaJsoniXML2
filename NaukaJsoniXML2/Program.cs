using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace NaukaJsoniXML2
{
    class Program
    {
        static void Main(string[] args)
        {
            human czlowiek = new human("Bartosz", "Medycki", 22);
            string path = @"C:\Users\barme\OneDrive\Pulpit\OperacjeNaPLikach\nauka2XML.xml";
            
            // json :D
            //string czlowiekSerialize  = JsonConvert.SerializeObject(czlowiek);
            //File.WriteAllText(path, czlowiekSerialize);

            //string czlowiekDeserialize = File.ReadAllText(path);
            //human czlowiekDeserialized = JsonConvert.DeserializeObject<human>(czlowiekDeserialize);
            //Console.WriteLine(czlowiekDeserialized);
            //Console.ReadLine();
            // XML
            StreamWriter sw = new StreamWriter(path);
            XmlSerializer serializer = new XmlSerializer(typeof(human));
            serializer.Serialize(sw, czlowiek);
            sw.Close();
            StreamReader streamReader = new StreamReader(path);
            human q = (human)serializer.Deserialize(streamReader);
            Console.WriteLine(q);
           

        }
    }
}
public class human
{
    public human()
    {

    }
    public int Age { get; set; }
    public String name { get; set; }
    public string surename { get; set; }
    public human(string name, string sureneme, int age)
    {
        this.Age = age;
        this.name = name;
        this.surename = sureneme;
       

    }
    public override string ToString()
    {
        return"imie : "+ name + "\n nazwisko : " + surename + "\n wiek :" + Age;
    }

}