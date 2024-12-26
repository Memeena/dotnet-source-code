using System.Net.Mail;

namespace Inheritance{
    internal class AreaCalculator:Circle{
        protected double area;
        public void calculateArea(){
            area = Math.PI * radius *radius;
        }

        public double getArea(){
            return area;
        }

    }
}