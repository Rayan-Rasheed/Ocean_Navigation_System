using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanNavigation.BL
{
    class Ship
    {
        public string shipSerialNumber;
        
        public Angle latitude ;
        public Angle longitude;
        
        public Ship(string shipSerialNumber,int degreeLatitude, float minuteLatitude, char directionLatitude,int degreeLongitude,float minuteLongitude,char directionLongitude)
        {
            this.shipSerialNumber = shipSerialNumber;
            latitude = new Angle(degreeLatitude,minuteLatitude,directionLatitude);
            longitude = new Angle(degreeLongitude,minuteLongitude,directionLongitude);
           

        }
        public void printShipPosition()
        {
            Console.WriteLine("Ship is at "+ latitude.displyAngle()+" and "+ longitude.displyAngle());
           

        }
        public string getSerialNumber()
        {
            string s=shipSerialNumber;
            return s;
        }
        public void changeShipPosition(int degreeLatitude, float minuteLatitude, char directionLatitude, int degreeLongitude, float minuteLongitude, char directionLongitude)
        {
            latitude.changeAngle(degreeLatitude, minuteLatitude, directionLatitude);
            longitude.changeAngle( degreeLongitude, minuteLongitude, directionLongitude);
        }


    }
}
