//Gradin ID: R5665 - CIS 199-01 - Program 4 - April 20, 2020
//This program displays the specifications of a package using different methods, arrays and classes.
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program4
{
    class Program
    {
        static void Main(string[] args)
        {
            //arrays that contain the information of each package 
            GroundPackage p1 = new GroundPackage(40018, 40023, 10, 30, 21, 39);
            GroundPackage p2 = new GroundPackage(40025, 40027, 22, 52, 14, 52);
            GroundPackage p3 = new GroundPackage(40041, 40056, 34, 42, 22, 13);
            GroundPackage p4 = new GroundPackage(40059, 40201, 21, 54, 25, 14);
            GroundPackage p5 = new GroundPackage(40118, 40202, 14, 64, 63, 53);
            GroundPackage p6 = new GroundPackage(40177, 40203, 42, 25, 54, 28);
            GroundPackage[] packages = { p1, p2, p3, p4, p5, p6 };
            DisplayPackages(packages); //displays the information
            //changes one aspect of each package
            p1.Length = 12;
            p2.Width = 30;
            p3.Height = 20;
            p4.Weight = 30;
            p5.Length = 50;
            p6.Width = 10;
            DisplayPackages(packages); //displays the new change 

            
        }
        public static void DisplayPackages(GroundPackage[] packages)
        {
            //for loop that will display the message using the array and the calculations of the packages
            for (int i = 0; i < packages.Length; i++)
            {
                WriteLine("Package " + (i + 1)); //package number
                WriteLine(packages[i]); //displays the specific information of each package using the arrays
                WriteLine($"{"Shipping Cost"}: ${packages[i].CalcCost()}"); //shipping cost
                WriteLine();
            }
        }

    }
    public class GroundPackage
    {
        //backing fields
        private int _originZip, _desZip;
        private double _length, _width, _height, _weight;
        //validation constants 
        public const int min_zip = 00000;
        public const int max_zip = 99999;

        public GroundPackage(int oZip, int desZip, double len, double wid, double hei, double wei)
        {
            //data constructors
            OriginZip = oZip; 
            DestZip = desZip;
            Length = len;
            Width = wid;
            Height = hei;
            Weight = wei;

        }
        public int OriginZip
        {
            //this property makes sure the origin zipcode is valid 
            get { return _originZip; }
            set
            {
                if (value >= min_zip && value <= max_zip)
                    _originZip = value;
                else // if the zipcode is not valid, display 40202
                    _originZip = 40202;
            }
        }
        public int DestZip
        {
            //this property makes sure the destination zipcode is valid 
            get { return _desZip; }
            set
            {
                if (value >= min_zip && value <= max_zip)
                    _desZip = value;
                else // if the zipcode is not valid, display 60606
                    _desZip = 60606;
            }
        }
        public double Length
        {
            //this property ensures the length is greater than 0
            get { return _length; }
            set
            {
                if (value > 0)
                    _length = value;
                else //if the length is not greater than 0, display 12.0
                    _length = 12.0;
            }
        }
        public double Width
        {
            //this property ensures the width is greater than 0
            get { return _width; }
            set
            {
                if (value > 0)
                    _width = value;
                else//if the width is not greater than 0, display 12.0
                    _width = 12.0;
            }
        }
        public double Height
        {
            //this property ensures the height is greater than 0
            get { return _height; }
            set
            {
                if (value > 0)
                    _height = value;
                else //if the height is not greater than 0, display 12.0
                    _height = 12.0;
            }
        }
        public double Weight
        {
            //this property ensures the weight is greater than 0
            get { return _weight; }
            set
            {
                if (value > 0)
                    _weight = value;
                else //if the weight is not greater than 0, display 12.0
                    _weight = 12.0;
            }
        }
        public int ZoneDistance
        {
            //this property claculates the positive difference between the first digit of the origin zipcode and the first digit of the destination zipcode
            get
            {
                int Ofirst = OriginZip / 10000;
                int Dfirst = DestZip / 10000;
                return Math.Abs(Ofirst - Dfirst); //displays the result in a positive value
            }
        }
        public double CalcCost()
        {
            //this method calculates the cost of the package using constants 
            const double size_cost_factor = .20;
            const double weight_cost_factor = .35;
            double cost = size_cost_factor * (Length + Width + Height) + weight_cost_factor * (ZoneDistance + 1) * (Weight);
            return cost; //displays the total cost
        }
        public override string ToString()
        {
            //this method gathers all the information and displays it as a string 
            return $"{"Origin ZipCode"}: {OriginZip}" + Environment.NewLine + $"{"Destination ZipCode"}: {DestZip}" + Environment.NewLine + $"{"Length"}: {Length}" + Environment.NewLine + $"{"Height"}: {Height}" + Environment.NewLine + $"{"Width"}: {Width}" + Environment.NewLine + $"{"Weight"}: {Weight}";

        }
    }
}
