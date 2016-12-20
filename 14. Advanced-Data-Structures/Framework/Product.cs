using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class Product : IComparable
    {
        public const int NameMinLength = 2;
        public const decimal PriceMinValue = 0.1m;

        public const string InvalidNameMessage = "Product name must have minimum 2 symbols!";
        public const string InvalidPriceMessage = "Product price must be equal or greather than 0.1";

        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price; 
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value.Length < NameMinLength)
                {
                    throw new ArgumentException(InvalidNameMessage);
                }
                this.name = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < PriceMinValue)
                {
                    throw new ArgumentException(InvalidPriceMessage);
                }

                this.price = value;
            }
        }

        public int CompareTo(object obj)
        {
            var otherProduct = (Product)obj;

            if (this.Price != otherProduct.Price)
            {
                return this.Price.CompareTo(otherProduct.Price);
            }

            if (this.Name != otherProduct.Name)
            {
                return this.Name.CompareTo(otherProduct.Name);
            }

            return 0;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Price: {this.Price}";
        }
    }
}
