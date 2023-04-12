using System;

namespace Pract13_3
{
    public class MeasuringDevice
    {
        private string name;
        private string type;
        private string manufacturer;
        private double price;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type
        {
            get { return type;}
            set { type = value; }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set { manufacturer = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        public MeasuringDevice(string name, string type, string manufacturer, double price)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Поле названия не может быть пустым");
            }
            foreach (var el in name)
            {
                if (char.IsDigit(el))
                {
                    throw new ArgumentException("Название не может содержать цифры");
                }
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException("Поле типа не может быть пустым");
            }
            foreach (var el in type)
            {
                if (char.IsDigit(el))
                {
                    throw new ArgumentException("Тип не может содержать цифры");
                }
            }

            if (string.IsNullOrWhiteSpace(manufacturer))
            {
                throw new ArgumentException("Поле производитель не может быть пустым");
            }

            foreach (var el in manufacturer)
            {
                if (char.IsDigit(el))
                {
                    throw new ArgumentException("Производитель не может содержать цифры");
                }
            }

            if (price < 0)
            {
                throw new ArgumentException("Поле цены не может быть отрицательным");
            }

            this.name = name;
            this.type = type;
            this.manufacturer = manufacturer;
            this.price = price;
        }

        public MeasuringDevice()
        {
            
        }
    }
}