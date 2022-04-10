using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanNavigation.BL;

namespace OceanNavigation
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ship> shipList = new List<Ship>();
            int option = 0;
            while (option < 5)
            {
                Console.Clear();
                header();
                option = chooseOption();
                if (option == 1)
                {
                    Console.Clear();
                    header();
                    shipList.Add(addShip());
                    
                }
                else if (option == 2)
                {
                    Console.Clear();
                    header();
                    ViewShipPosition(shipList);
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    Console.Clear();
                    header();
                    string serial=ViewShipNumber(shipList);
                    Console.WriteLine("Ship Serial Number is: "+serial);
                    Console.ReadKey();

                }
                else if (option == 4)
                {
                    Console.Clear();
                    header();
                    Console.Write("Enter Ship Serial Number:");
                    string shipNumber = Console.ReadLine();
                    changeShipPosition(shipNumber,shipList);
                    
                }
            }
            Console.ReadKey();
            

        }
        static void header()
        {
            Console.WriteLine("************************************************************************");
            Console.WriteLine("************************Ocean Navigation System*************************");
            Console.WriteLine("************************************************************************");

        }
        static int chooseOption()
        {
            Console.WriteLine("1.Add Ship");
            Console.WriteLine("2.View Ship Position");
            Console.WriteLine("3.View Ship Serial Number");
            Console.WriteLine("4.Change Ship Position");
            Console.WriteLine("Exit");
            Console.Write("Choose a option...");

            int option = int.Parse(Console.ReadLine());
            return option;


        }
        static Ship addShip()
        {
            Console.Write("Enter Ship Serial Number: ");
            string shipNumber = Console.ReadLine();
            Console.WriteLine("Enter Ship Latitude: \n");
            //latitude
            Console.Write("Enter Latitude's Degree : ");
            int degreeLatitude = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Minute : ");
            float minuteLatitude = float.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction: ");
            char directionLatitude = char.Parse(Console.ReadLine());
            //longitude
            Console.WriteLine("Enter Ship Longitude: \n");
            
            Console.Write("Enter Longitude's Degree : ");
            int degreeLongitude = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Minute : ");
            float minuteLongitude = float.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Direction : ");
            char directionLongitude = char.Parse(Console.ReadLine());
            Ship newship = new Ship(shipNumber,degreeLatitude,minuteLatitude,directionLatitude,degreeLongitude,minuteLongitude,directionLongitude);
            return newship;


        }
        static void ViewShipPosition(List<Ship> shipList)
        {
            bool flag= false;
            Console.Write("Enter Ship Serial Number: ");
            string shipNumber = Console.ReadLine();
            foreach(Ship var in shipList)
            {
                if (var.shipSerialNumber == shipNumber)
                {
                    flag = true;
                    var.printShipPosition();
                }
            }
            if (flag == false)
            {
                Console.WriteLine("No ship Found against this serial Number.");
            }
        }
        static string ViewShipNumber(List<Ship> shipList)
        {
            string shipNumber="Not found";
            Console.Write("Enter the Ship Latitude(Space_Seperated): ");
            string latitude = Console.ReadLine();
            Console.Write("Enter the Ship Longitude(Space_Seperated): ");
            string longitude = Console.ReadLine();
            int degreeLatitude = int.Parse(parseData(latitude,1));
            float minuteLatitude = float.Parse(parseData(latitude,2));
            char directionLatitude = char.Parse(parseData(latitude,3));
            int degreeLongitude = int.Parse(parseData(longitude, 1));
            float minuteLongitude = float.Parse(parseData(longitude, 2));
            char directionLongitude = char.Parse(parseData(longitude, 3));
            for(int i = 0; i < shipList.Count; i++)
            {
                if(shipList[i].latitude.degree==degreeLatitude && shipList[i].latitude.minute==minuteLatitude && shipList[i].latitude.direction == directionLatitude)
                {
                    if(shipList[i].longitude.degree == degreeLongitude && shipList[i].longitude.minute == minuteLongitude && shipList[i].longitude.direction == directionLongitude)
                    {
                        shipNumber = shipList[i].getSerialNumber();
                    }
                }
            }
            return shipNumber;



        }
        static string parseData(string data,int n)
        {
            string str="";
            int spaceCount = 1;
            for(int i = 0; i < data.Length; i++)
            {
                
                if(data[i]==' ')
                {
                    spaceCount++;
                    
                    
                }
                
                if(spaceCount==n && data[i] != ' ')
                {
                    str = str + data[i];
                }
                

            }
            return str;
        }
        static void changeShipPosition(string shipNumber,List<Ship> shipLists)
        {
            for(int i = 0; i < shipLists.Count; i++)
            {
                if (shipLists[i].shipSerialNumber == shipNumber)
                {
                    changeAngles(shipLists[i]);
                }
            }
        }
        static void changeAngles(Ship ship)
        {
            Console.WriteLine("Enter Ship Latitude: \n");
            //latitude
            Console.Write("Enter Latitude's Degree : ");
            int degreeLatitude = int.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Minute : ");
            float minuteLatitude = float.Parse(Console.ReadLine());
            Console.Write("Enter Latitude's Direction: ");
            char directionLatitude = char.Parse(Console.ReadLine());
            //longitude
            Console.WriteLine("Enter Ship Longitude: \n");

            Console.Write("Enter Longitude's Degree : ");
            int degreeLongitude = int.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Minute : ");
            float minuteLongitude = float.Parse(Console.ReadLine());
            Console.Write("Enter Longitude's Direction : ");
            char directionLongitude = char.Parse(Console.ReadLine());
            ship.changeShipPosition(degreeLatitude, minuteLatitude, directionLatitude, degreeLongitude, minuteLongitude, directionLongitude);
        }

    }
}
