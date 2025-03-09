/* Name: Aaron Cohen
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
           
            //Printing the opening greeting and the menu
            Console.WriteLine("Welcome to the Bakery point of sale system!\n" +
                "-----------------------------------------------------------\n" +
                "Menu:\n");
            //Each menu item is associated with a number
            Console.WriteLine("Donuts(1)----------------------$1 each or $6 / dozen\n" +
                              "Sheet Cakes(2)-----------------$8 each\n" +
                              "Funnel Cakes(3)----------------$3.50 each\n" +
                              "Cupcakes(4)--------------------$1.25 each or $4 for 6\n" + 
                              "5 to exit to bill\n");

            var item = 0;
            var numItems = 0;
            var quantity = 0;
            double total = 0.00d;
            double tip = 0.00d;
            //Cart array that corresponds to each food item
            int[] cart = { 0, 0, 0, 0, 0};

            //Getting user input for item and quantity
            Console.WriteLine("Enter an item number: ");
            if (!int.TryParse(Console.ReadLine(), out item))
            {
                Console.WriteLine("Input must be a number\n");              
            }
            Console.WriteLine("\nEnter desired quantity: ");
            if (!int.TryParse(Console.ReadLine(), out quantity))
            {
                Console.WriteLine("Input must be a number\n");
            }

            //While loop that will add to the cart until the user enters 5
            while (item != 5)
            {
                switch (item)
                {
                    //For each case add the quantity to the corresponding cart number
                    case 1:
                        cart[1] += quantity;
                        numItems += quantity;
                        break;
                    case 2:
                        cart[2] += quantity;
                        numItems += quantity;
                        break;
                    case 3:
                        cart[3] += quantity;
                        numItems += quantity;
                        break;
                    case 4:
                        cart[4] += quantity;
                        numItems += quantity;
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Invalid option!\n");
                        break;
                }
                //Once things are added to the cart the subtotal is calculated and displayed
                total = p.CalculateTotal(cart);
                Console.WriteLine("Number of Items: " + numItems + " Current Subtotal: $" + total + "\n");
                Console.WriteLine("Enter another food item or enter 5 to exit\n");
                
                //Getting the next input from user
                if (!int.TryParse(Console.ReadLine(), out item))
                {
                    Console.WriteLine("Input must be a number\n");
                    continue;
                }
                if(item == 5)
                {
                    break;
                }
                Console.WriteLine("\nEnter desired quantity: ");
                if (!int.TryParse(Console.ReadLine(), out quantity))
                {
                    Console.WriteLine("Input must be a number\n");
                    continue;
                }
            }
            
            total = p.CalculateTotal(cart);

            //Displaying the subtotal plus the tip
            Console.WriteLine("Current total with sales tax: $" + (total + (total * 0.07)) + "\n");
            //Displaying tip options to user
            Console.WriteLine("What tip would you like leave?\n5%   10%   15%\n");

            while (true)
            {
                //Getting tip input 
                if (!double.TryParse(Console.ReadLine(), out tip))
                {
                    Console.WriteLine("Input must be a number\n");
                    continue;
                }
                //Error checking
                if(tip == 5 || tip == 10 || tip == 15)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid tip amount! Try again.\n");
                }
            }
            tip = tip * 0.01;
            //Printing the final items in the cart
            Console.WriteLine("Final Cart:\nDonuts: " + cart[1] + "\nSheet Cakes: " + cart[2] + "\nFunnel Cakes: " + cart[3] +
                "\nCupcakes: " + cart[4] + "\n");
            Console.WriteLine("Tax: $" + (total * 0.07) + "\tTip: $" + ((total + (total * 0.07)) * tip) + "\n");
            total = total + (total * 0.07);
            total = total + (total * tip);
            //Printing the total
            Console.WriteLine("Total: $" + total);

            Console.ReadLine();
        }

        //Method to calculate the total cost of cart 
        public double CalculateTotal(int[] cart)
        {
            double total = 0.0;
            //Runoff to calculate possibility of buying 2 dozen + 1 donuts
            int runOff = 0;
            int newNumber = 0;

            //Calculating costs of each cart item

            //If there are 12 or more donuts calculate the run off
            if(cart[1] >= 12)
            {
                runOff = (cart[1] % 12);
                newNumber = cart[1] - runOff;
                total += runOff * 1;
                total += (newNumber / 12) * 6;
            }
            else
            {
                total += cart[1] * 1;
            }
            total += cart[2] * 8;
            total += cart[3] * 3.50;

            //If there are 6 or more cupcakes calculate run off
            if(cart[4] >= 6)
            {
                runOff = (cart[4] % 6);
                newNumber = cart[4] - runOff;
                total += runOff * 1.25;
                total += (newNumber / 6) * 4;
            }
            else
            {
                total += cart[4] * 1.25;
            }
            return total;
        }
    }
}
