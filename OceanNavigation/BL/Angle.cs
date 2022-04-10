using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OceanNavigation.BL
{
    class Angle
    {
        public int degree;
        public float minute;
        public char direction;
        public Angle()
        {

        }
        public Angle(int degree,float minute,char direction)
        {
            this.degree = degree;
            this.minute = minute;
            this.direction = direction;
        }
        public void changeAngle(int degree,float minute,char direction)
        {
            this.degree = degree;
            this.minute = minute;
            this.direction = direction;
        }
        public string displyAngle()
        {
            string shipDirection= degree + "°" + minute + "' " + direction;
            return shipDirection;

        }
        
    }
}
