using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Product
    {
        private int _ProductID;
        public int ProductID
        { 
            get {
                return _ProductID;
            }
            set
            {
                
                if (!Int32.TryParse(value.ToString(), out int numero) && value.ToString().ToCharArray().Length == 5) 
                {
                    throw new InvalidOperationException("The ID must be integer number of 5 digits");
                }                

                char[] arr = value.ToString().ToCharArray();

                int sum = Int32.Parse(arr[0].ToString()) + Int32.Parse(arr[1].ToString()) + Int32.Parse(arr[2].ToString()) + Int32.Parse(arr[3].ToString());

                int final = Int32.Parse(arr[4].ToString());

                while (sum > 9)
                {
                    char[] newArr = sum.ToString().ToCharArray();
                    sum = Int32.Parse(newArr[0].ToString()) + Int32.Parse(newArr[1].ToString());
                }

                if (sum != final)
                    throw new InvalidOperationException("Your ID doesn't match our criteria. The fifth element must be the result of the digit sum of the first 4 digits.");
                else
                    this._ProductID =  value;
            }
        }
        public string ProductName { get; set; }
        public Type Type { get; set; }
        public float ProductPrice { get; set; }
    }
}
