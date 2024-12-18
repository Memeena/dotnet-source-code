namespace LibraryManagement{
    internal class Library{
        private string _libraryName;
        private int _bookEntered;
        private int bookCounts = 0;

        public Library(string name,int maxBooks){
            _libraryName = name;
            _bookEntered = maxBooks;

            Console.WriteLine($"Library name {_libraryName} is created" );
        }

        public string LibraryName {
            get { return _libraryName; }
            set { _libraryName = value; }   
        }

        public void AddBooks(string bookTitle){
            if(_bookEntered > 0){
                bookCounts++;
                Console.WriteLine($"Book '{bookTitle}' is added to the library!");
                _bookEntered--;
            }else{
                Console.WriteLine("Library is full!Cannot add more books!");
            }
        }    
        
        public void DisplayBooks(){
            Console.WriteLine($"Books available in the {_libraryName} are {bookCounts}");
        }

        ~Library(){
            Console.WriteLine($"Library {_libraryName} object is destroyed!");
        }

        }
}   