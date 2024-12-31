namespace HelloWorld.Models{
    public class Computer{

        // private string _motherboard;

        // private string MotherBoard{
        //     get {
        //         return _motherboard;
        //     }
        //     set {
        //         _motherboard = value;
        //     }
        // }

public int ComputerId { get; set; }
        public string MotherBoard { get; set; } = "";
        public int CPUCores{ get; set; }
        public bool HasWifi{ get; set; }
        public bool HasLTE{ get; set; }
        public DateTime ReleaseDate{ get; set; }
        public decimal Price{ get; set; }
        public string VideoCard{ get; set; }="";

        // public Computer(){
        //     VideoCard??="";
        //     MotherBoard??="";
        // }
    }

    
}