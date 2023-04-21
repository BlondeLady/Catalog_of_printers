using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Catalog_of_printers
{
    [Serializable]
     
    class Printer
    {
        int id;
        string model;
        string manufacturer; //виробник
        string appointment;// призначення
        string print_size;
        double price;
        public Printer() { }

        public Printer(int id, string model, string manufacturer, string appointment, string print_size, double price)
        {
            this.Id = id;
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Appointment = appointment;
            this.Print_size = print_size;
            this.Price = price;
        }

        public int Id { get => id; set => id = value; }
        public string Model { get => model; set => model = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Appointment { get => appointment; set => appointment = value; }
        public string Print_size { get => print_size; set => print_size = value; }
        public double Price { get => price; set => price = value; }

        public override bool Equals(object obj)
        {
            return obj is Printer printer &&
                   id == printer.id &&
                   model == printer.model &&
                   manufacturer == printer.manufacturer &&
                   appointment == printer.appointment &&
                   print_size == printer.print_size &&
                   price == printer.price;
        }

        public override int GetHashCode()
        {
            int hashCode = -1219549542;
            hashCode = hashCode * -1521134295 + id.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(model);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(manufacturer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(appointment);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(print_size);
            hashCode = hashCode * -1521134295 + EqualityComparer<double>.Default.GetHashCode(price);
            return hashCode;
        }
        public virtual string Cost_calculation()
        {
            string price_message = "до сплати: " + Price;
            return price_message;
        }




    }
}
