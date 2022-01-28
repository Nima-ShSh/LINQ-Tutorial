using System;
using System.Linq;
using System.Collections.Generic;

namespace LinkQ_tutorial
{

//-------------this is for  "Using Custom Types"   section
//Build a collection of customers who are millionaires
public class Customer
{
    public string Name { get; set; }
    public double Balance { get; set; }
    public string Bank { get; set; }
}


public class MillyReport
        {
             //bank name + number of mil peeps in the bank
            // include bank, number of millionaire customers
            public string BankName
            {
                get; set;
            }
            public int MillionaireNum
            {
                get; set;
            }
        }

//------------------


    class Program
    {
        static void Main(string[] args)
        {
            
        //Chapter 16 - Wrangling Data with LINQ
        //https://github.com/NewForce-at-Mountwest/bangazon-inc/tree/master/book-1-orientation


        //------------------Restriction/Filtering Operations----------------------


            // Find the words in the collection that start with the letter 'L'
        List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

        IEnumerable<string> LFruits = from fruit in fruits 
        where fruit.StartsWith("L")
        select fruit;

        foreach ( string fruit in LFruits) {
            Console.WriteLine(fruit);
        }


        // Which of the following numbers are multiples of 4 or 6

        List<int> numbers = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        IEnumerable<int> fourSixMultiples = numbers.Where(num => num % 4 == 0 || num % 6 == 0);
        //results shown in debugger


        //-----------Ordering Operations-----------

        // Order these student names alphabetically, in descending order (Z to A)
        List<string> names = new List<string>()
        {
            "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
            "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
            "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
            "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
            "Francisco", "Tre"
        };

        List<string> descend = names.OrderByDescending(singleName => singleName).ToList();
        //to list goes after the link method - once data is returned then do the convert to list stuff


        // Build a collection of these numbers sorted in ascending order
        List<int> numbersTwo = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };

        List<int> ascend = numbersTwo.OrderBy(singleNum => singleNum).ToList();
        //OrderBy() casts tounumerable then we need to convert again to int using ToList()



        //------------------Aggregate Operations----------------

        // Output how many numbers are in this list
        List<int> numbersThree = new List<int>()
        {
            15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
        };
        Console.WriteLine(numbersThree.Count());


        // How much money have we made?
        List<double> purchases = new List<double>()
        {
            2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
        };
        Console.WriteLine(purchases.Sum());


        // What is our most expensive product?
        List<double> prices = new List<double>()
        {
            879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
        };
        Console.WriteLine(prices.Max());


        //----------------Partitioning Operations-----------------------
        List<int> wheresSquaredo = new List<int>()
        {
            66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
        };
        /*
            Store each number in the following List until a perfect square
            is detected.

            Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 

            Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
        */

        List<int> notSquared = new List<int>();

        foreach (int singleObject in wheresSquaredo) {

            bool perfectSquare = singleObject % Math.Sqrt(singleObject) == 0;

           if (perfectSquare) {
            break;
           }
            notSquared.Add(singleObject);
            Console.WriteLine(singleObject);
        }
        //Expected output is in the debugger, it is storing it in the notSquared list too


        //-----------------Using Custom Types   section---------------------
        //The getters and setters blue print are on the very top of the file
        //We are in the main right now, copy/pasta-ed the contents of the main from exercise here

        List<Customer> customers = new List<Customer>() {
                    new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                    new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                    new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                    new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                    new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                    new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                    new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                    new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                    new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                    new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
                };



    //do group by
    //custom class has the both the variables instead of using only one, what we needed

    List<MillyReport> reports = (from customer in customers
                                       group customer by customer.Bank into balanceGroup
                                       select new MillyReport() {
                                       BankName = (balanceGroup.Key),
                                       MillionaireNum = balanceGroup.Where(millies => millies.Balance > 999999.00).Count()
                                       }).OrderByDescending(mr => mr.MillionaireNum).ToList();

                                        foreach (MillyReport report in reports)
                                      {
                                          Console.WriteLine($"{report.BankName} {report.MillionaireNum}");
                                      }
    }

    //Use the two custom classes to get the info
    //Use Limit an array to the items that meet a criteria section from the Chapter 16 assignment page
    //output the number of customers per bank
// LINQ
// IEnumerable<int> onlyEvens = sampleNumbers.Where(number => number % 2 == 0);


//Copied over from the exercises of the same chapter for reference---
//    List<SalesReportEntry> salesReport = (from kid in kids
//              //dealing with kids list
//                 group kid by kid.Neighborhood into neighborhoodGroup
//             //now dealing with neighborhoodGroup list
//                 select new SalesReportEntry {
//                     ReportNeighborhood = neighborhoodGroup.Key, 
//                     ReportTotalSales = neighborhoodGroup.Sum(kidObj => kidObj.Sales)
//                 }).OrderByDescending(sr => sr.ReportTotalSales).ToList();

        }  //end main
    }


