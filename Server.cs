using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Catalog_of_printers
{
    class Server
    {
        public static List<Laser_printer> Laser_Printers { get; set; }
        public static List<Inkjet_printer> Inkjet_printers { get; set; }

        public static List<Laser_printer> DeserializeLaser()
        {
            if (File.Exists("laser_printer.xml"))
            {
                using (FileStream fs = new FileStream("laser_printer.xml", FileMode.Open))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Laser_printer>));
                    Laser_Printers = (List<Laser_printer>)xml.Deserialize(fs);
                }
                return Laser_Printers;
            }
            return new List<Laser_printer>();
        }

        public static List<Inkjet_printer> DeserializeInkjet()
        {
            if (File.Exists("inkjet_printer.xml"))
            {
                using (FileStream fs = new FileStream("inkjet_printer.xml", FileMode.Open))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(List<Inkjet_printer>));
                    Inkjet_printers = (List<Inkjet_printer>)xml.Deserialize(fs);
                }
                return Inkjet_printers;
            }
            return new List<Inkjet_printer>();
        }
        public static void SerializeLaser()
        {
            using (FileStream fs = new FileStream("laser_printer.xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Laser_printer>));
                xml.Serialize(fs, Laser_Printers);
            }
        }

        public static void SerializeInkjet()
        {
            using (FileStream fs = new FileStream("inkjet_printer.xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(List<Inkjet_printer>));
                xml.Serialize(fs, Inkjet_printers);
            }
        }
        public static void DeleteLaser(Printer printer)
        {
            List<Laser_printer> laser_printer = Laser_Printers.Where(a => a.Printer.Equals(printer)).ToList();
            for (int i = 0; i < laser_printer.Count; i++)
            {
                Laser_Printers.Remove(laser_printer[i]);
            }
        }

        public static void DeleteInkjet(Printer printer)
        {
            List<Inkjet_printer> inkjet_printers = Inkjet_printers.Where(a => a.Printer.Equals(printer)).ToList();
            for (int i = 0; i < inkjet_printers.Count; i++)
            {
                Inkjet_printers.Remove(inkjet_printers[i]);
            }
        }
    }
}
