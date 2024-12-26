namespace Inheritance{
    internal class Cylinder : AreaCalculator{
        protected double height;
        protected double volume;
        public void SetHeight(double h){
            height = h;
        }

        public double GetHeight(){
            return height;
        }

        public double CalculateVolume(){
            return volume = area * height;
        }

        public double GetVolume(){
            return volume;
        }
    }
}