// // using CSharpFundamentals.Math;
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using CSharpFundamentals.Math;
// using LibraryManagement;
using System.Data;
using System.Globalization;
using System.Xml.Serialization;
using CartDetails;
// namespace CSharpFundamentals
// {
// //     public enum ShippingMethod{
// //         RegularAirMail = 1,
// //         RegisteredAirMail =2,
// //         Express = 3,

// //     }
// //        public class Person
// //     {
// //         public string firstName = "";
// //         public string lastName = "";
// //         public void Introduce()
// //         {
// //             Console.WriteLine("My name is " + firstName + " " + lastName);
// //         }
// //     }
//        class Program {
//         public static void Main(string[] args){
// //             Person meena = new Person();
//             Calculator calculator= new Calculator();    
// //             meena.firstName = "Meena";
// //             meena.lastName = "Krishna"; 
// //             meena.Introduce();
//             var result = calculator.Add(1, 2);
//             Console.WriteLine(result);
// //             string name = string.Format("{0} {1}", meena.firstName, meena.lastName);
// //             Console.WriteLine("name:" + name);
// //             var numbers = new int[3] {1,2,3};
// //             string list = string.Join(" ", numbers);
// //             Console.WriteLine("list:" + list);
// //             var methodId = 2;
// //             Console.WriteLine((ShippingMethod)methodId);
// //             Console.WriteLine((int)ShippingMethod.RegularAirMail);
// //             var methodName = "Express";
// //             var shippingMethod = (ShippingMethod)Enum.Parse(typeof(ShippingMethod), methodName);
// //             Console.WriteLine(shippingMethod);
// //             var array1 = new int[3] { 1, 2, 3 };
// //             var array2 = array1;
// //             array2[0] = 0;
// //             Console.WriteLine(array2);

//         }
//     }
// // class Program{
//         // public static void Main(string[] args)
//         // {
//             //Arrays length,IndexOf,Clear,Sort,Reverse
//             // var random = new Random();
//             // const int passowrdLength = 10;
//             //     var buffer = new char[passowrdLength];

//             //Random class

//             // for(int i = 0; i < passowrdLength;i++){
//             //     buffer[i] = (char)('a'+random.Next(0,26));
//             // }

//             // var password = new string(buffer);
//             // Console.WriteLine(password);  

//             //List

//             // var numbers = new List<int>() { 1, 2, 3, 4 };
//             // numbers.Add(50);

//             // foreach (int i in numbers)
//             // {
//             //     Console.WriteLine(i);
//             // }
//             // Console.WriteLine(numbers.IndexOf(50));


//             // var characters = new List<char>() { 'a', 'b' };

//             // characters.AddRange(new char[] { 'c', 'd','b' });

//             // foreach (var item in characters)
//             // {
//             //     Console.WriteLine(item);
//             // }

//             // Console.WriteLine(characters.IndexOf('b'));
//             // Console.WriteLine(characters.Remove('b'));
//             // Console.WriteLine(characters.IndexOf('b'));

//             //             Exercise 1- When you post a message on Facebook, depending on the number of people who like your post, Facebook displays different information.

//             // If no one likes your post, it doesn't display anything.
//             // If only one person likes your post, it displays: [Friend's Name] likes your post.
//             // If two people like your post, it displays: [Friend 1] and [Friend 2] like your post.
//             // If more than two people like your post, it displays: [Friend 1], [Friend 2] and [Number of Other People] others like your post.
//             // Write a program and continuously ask the user to enter different names, until the user presses Enter (without supplying a name). Depending on the number of names provided, display a message based on the above pattern.
//             /*
//                         List<string> names = new List<string>();
//             while(true){

//                         Console.WriteLine("Type your name:");
//                        var name= Console.ReadLine();

//                        if(String.IsNullOrEmpty(name)){
//                         break;
//                        }else{
//                         // var names = new List<string>() { };
//                         names.Add(name);
//                         Console.WriteLine("Count:" + names.Count);
//                         foreach(string s in names){
//                             Console.WriteLine(s);   
//                         }

//                         if(names.Count == 1){
//                             Console.WriteLine("{0} likes your post",names[0]);
//                         }else if(names.Count == 2){
//                             Console.WriteLine("{0} and {1} likes your post",names[0],names[1]);
//                         }else{
//                             Console.WriteLine("{0},{1} and {2} others like your post",names[0],names[1],names.Count-2);
//                         }
//                        }
//                     }

//                        */

//             /*
//             Exercise 2- Write a program and ask the user to enter their name. Use an array to reverse the name and then store the result in a new string. Display the reversed name on the console.*/
//             /*

//                         Console.WriteLine("Enter your name:");
//                         var inputString = Console.ReadLine();

//                             char[] charArray = inputString.ToCharArray();

//                             Array.Reverse(charArray);

//                             Console.WriteLine(string.Join("", charArray));
//             */
//             /*Exercise 3- Write a program and ask the user to enter 5 numbers. If a number has been previously entered, display an error message and ask the user to re-try. Once the user successfully enters 5 unique numbers, sort them and display the result on the console.*/
//             /******************************************************************************
//             Console.WriteLine("Enter 5 numbers!");
//                         int[] input = new int[5];
//                         int inputCount =0;
//             for(int i=0; inputCount <5 ;){
//                 Console.WriteLine("@Enter number:");
//                 int inputNum =int.Parse(Console.ReadLine());

//                             if (Array.IndexOf(input, inputNum) == -1)
//                             {
//                                 input[i] = inputNum;
//                                 inputCount++;
//                                 i++ ;
//                             }else{
//                                 Console.WriteLine("Re-try!");
//                             }
//             }
//             Array.Sort(input);
//             foreach(int i in input){
//                 Console.Write(i + " ");
//             }*/

//             /******************************************************************************
//             Exercise 4- Write a program and ask the user to continuously enter a number or type "Quit" to exit. The list of numbers may include duplicates. Display the unique numbers that the user has entered.*/
//             /*
//             var endOfLoop = false;
//     List<int> numbers = new List<int>();
// while(!endOfLoop){
//     Console.WriteLine("Enter a number:");
//     var input = Console.ReadLine();
//                 if (input == "Quit")
//                 {
//                     endOfLoop = true;
//                 }
//                 else
//                 {
//                     numbers.Add(int.Parse(input));
//                 }
// }
// List<int> uniqueList = numbers.Distinct().ToList();
// foreach(int number in uniqueList){
//     Console.WriteLine(number+" ");
// }*/
//             // Date and Time
//             // var dateTime = new DateTime(2024, 1, 1);
//             // var yesterday = dateTime.AddDays(-1);
//             // Console.WriteLine("{0} {1}", yesterday, dateTime.Hour);
// // DateTime time = DateTime.Now;
// //             Console.WriteLine("" + time.ToString("yyyy-MM-dd h:mm:ss tt"));
// //             Console.WriteLine("" + time.ToShortTimeString());
// //             Console.WriteLine("" + time.ToLongTimeString());
// //             Console.WriteLine("" + time.ToLongDateString());
// //             Console.WriteLine("" + time.ToShortDateString());
// //Debugging techniques provided by visual studio community version - Breakpoints,Stepping,inspecting variables,memory inspection,Call stack inspection,watch expressions
// //Strings - ToLower,ToUpper,Trim,IndexOf,LastIndexOf,Substring(startIndex),Substring(startIndex,length),Replace,string.IsNullOrEmpty,string.IsNullOrWhiteSpace,str.Split
// //Converting string to number -> int.Parse or Convert.ToInt32(str)
// //Converting number to string -> i.ToString()
//         }
    
//     namespace Properties{
//         internal class Program{
//             static void Main(string[] args) {
//             // Person person = new Person();
//             // person.Name = "Meenakshi";
//             // person.DisplayInfo();
//             Console.Write("Enter the library name:");
//             string libraryName = Console.ReadLine();

//             Console.Write("Enter the maximum books the library can hold:");
//             int maxBooks = int.Parse(Console.ReadLine());

//             Library myLibrary = new Library(libraryName,maxBooks);

//             do
//             {
//         Console.Write("\nEnter the book titles:");
//                 string input = Console.ReadLine();
//                 myLibrary.AddBooks(input);
//                 maxBooks--;
//             } while (maxBooks >= 0);

// myLibrary.DisplayBooks();
//             }
//         }
//     }

// namespace Program{
//     internal class Program(){
//         static void Main(string[] args){
//             Console.WriteLine("Enter the owner's name:");
//             string name=Console.ReadLine();

//             Console.WriteLine("Enter the number of maximum number of items the cart can hold:");
//             int maxItems = int.Parse(Console.ReadLine());

//             Cart myCart = new Cart(name,maxItems);

//             do
//             {
//         Console.Write("\nEnter the name of the item:");
//                 string input = Console.ReadLine();
//                 myCart.AddItems(input);
//                 maxItems--;
//             } while (maxItems >= 0);

// myCart.DisplayItems();

//         }   
//     }
// }

/**************************************************************
Finding Min and Max number in an integer array */
/*
namespace ArrayCollection{
    internal class MinandMax{
        static void Main(string[] args){
            MinandMax mm = new MinandMax();
            mm.Run();

        }

        public int FindMin(int[] array){
            int min=array[0];

            foreach(int num in array){
                if(num<min){
                    min = num;
                }
            }

            return min;
        }

        public int FindMax(int[] array){
            int max = array[0];
            foreach( int num in array){
                if(num > max){
                    max = num;
                }
            }    

            return max;
        }

        public void Run(){
            Console.WriteLine("Enter the size of the array:");
            int n=int.Parse(Console.ReadLine());
            int[] arr = new int[n];  

            for(int i=0;i<n;i++){
                Console.WriteLine("Enter the elements of the array:"); 
                arr[i] = int.Parse(Console.ReadLine()); 
            }

            int min = FindMin(arr);
            int max = FindMax(arr);
            Console.WriteLine("The minimum number in the array is {0}", min);
            Console.WriteLine("The maximum number in the array is {0}", max);


        }

    }
}
*/

/**************************************************************
Finding Sum and Average of the numbers in an array */

/*
namespace ArrayCollection{
    internal class FindSumAndAverage{
        static void Main(string[] args){

        FindSumAndAverage findSumAndAverage = new FindSumAndAverage();
        findSumAndAverage.Run();
        }

        public int findSum(int[] array){
            int sum = 0;
            foreach(int i in array){
                sum = sum + i;
            }

            return sum;

        }

        public void Run(){
            Console.WriteLine("Enter the size of the array:");
            int length = int.Parse(Console.ReadLine());

            int[] array = new int[length];

            for(int i = 0; i < length;i++){
                Console.WriteLine($"Enter the element[{i + 1}]:");
                array[i] = int.Parse(Console.ReadLine()) ;
            }

            int sum = findSum(array);
            double average = sum / length;
            Console.WriteLine("The sum of the elements of the array is " + sum);
            Console.WriteLine("Average is " + average);


        }
    }
}*/

/**************************************************************
ArrayList and Linked List*/
// namespace ArrayAndList{
//     internal class ArrayAndLinkedList{
//         static void Main(string[] args){
//             List<int> arrayList = new List<int>();
//             LinkedList<int> linkedList = new LinkedList<int>();

//             for(int i = 0; i < 1000000; i++){
//                 arrayList.Add(i+1);
//                 linkedList.AddLast(i+1);
//             }
//             long startTime = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;
//             int elementAL = arrayList[700000];
//             // Console.WriteLine(elementAL);
//             long endTime = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;
//             long durationAL = endTime - startTime;

//             startTime = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;
//             int elementLL = linkedList.ElementAt(700000);
//             endTime = DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;
//             long durationLL = endTime - startTime;

//             Console.WriteLine("Element retrieved from ArrayList:{0}", elementAL);
//             Console.WriteLine("Element retrieved from LinkedList:{0}", elementLL);
//             Console.WriteLine("Time taken by ArrayList:{0}", durationAL);
//             Console.WriteLine("Time taken by LinkedList:{0}", durationLL);


//                     }
//     }
// }

/******************************************************************************
Dictionary*/
// namespace DictionaryUsage{
//     internal class EmployeeRecordManager{

//     static void Main(string[] args){
//         Dictionary<string,string> employeeRecords = new Dictionary<string,string>();

//         Console.WriteLine("Enter the employee Records.. Enter 'exit' to stop.");

//         while (true){
//             Console.WriteLine("Enter the employee number:");
//             string employeeID = Console.ReadLine(); 

//             if(employeeID.ToLower() == "exit"){break;}

//             Console.WriteLine("Enter the employee name:");
//             string employeeName = Console.ReadLine();   

//             employeeRecords[employeeID] = employeeName;


//         }

//         Console.WriteLine("Enter the name of the employee to check in the records:");
//         string employeeNameToCheck = Console.ReadLine();

//         bool employeeExists = false;    

//         foreach(var record in employeeRecords){
//             if(record.Value == employeeNameToCheck){
//                 employeeExists = true;
//                 break;
//             }
//         }
//         if(employeeExists){
//             Console.WriteLine("Employee exists in the record!");
//         }else{
//             Console.WriteLine("Employee does not exists in the record!");
//         }
//     }
//     }
// }

// namespace Inheritance{
//     internal class Program{
//         public static void Main(string[] args){
//             Cylinder cylinder= new Cylinder();

//             Console.WriteLine("Enter the radius of the Circle:");
//             double radius = Convert.ToDouble(Console.ReadLine());

        
//             // cylinder.SetRadius(int.Parse(Console.ReadLine()));
//         }
//     }
// }

