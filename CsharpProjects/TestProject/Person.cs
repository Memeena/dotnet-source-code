namespace Properties{
    internal class Person{
        private string _name;

        public string Name { 
            set {
                if(!string.IsNullOrEmpty(value)){

                _name = value;
                }  else{
                    Console.WriteLine("Name cannot be empty");
                }
            }
            get { return _name;}
        }

        public void DisplayInfo(){
            Console.WriteLine($"Name:{Name}");
        }
    }
}