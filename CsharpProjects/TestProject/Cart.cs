namespace CartDetails{
    internal class Cart{
        string _cartOwner;
        int _maxItems, _itemCount;

        public Cart(string cartOwner, int maxItems){
            _cartOwner = cartOwner;
            _maxItems = maxItems;

            Console.WriteLine($"New cart {_cartOwner} with {_maxItems} is created!");
        }

        public string CartOwner { get { return _cartOwner; }
        set {
            _cartOwner = value;
        }}

        public void AddItems(string itemName){
            if(_itemCount != _maxItems){
                Console.WriteLine($"The item {itemName} is added tp the cart!");
                _itemCount++;
            }else{
                Console.WriteLine($"No more items can be added as the cart is full!");
            }
        }

        public void DisplayItems(){
            Console.WriteLine($"{_itemCount} items added to the cart in the name of {_cartOwner}");
        
        }
~Cart(){
            Console.WriteLine("The shopping cart object is destroyed!");
}

    }
}   
