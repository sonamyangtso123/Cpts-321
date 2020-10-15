using System;
using System.Collections.Generic;
using System.Linq;
using CptS321;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using CptS321;

namespace CptS321
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            ExpressionTree tree = new ExpressionTree();
            string expression = "A1+12+B1";
            
            bool exitApp = false;
            do
            {
                Console.WriteLine("Menu (current expression =" + expression +")");
                MenuOption();
                string userInput = Console.ReadLine();
                Console.WriteLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Enter new epression: ");
                        expression = Console.ReadLine();
                        break;

                    case "2":
                        Console.WriteLine("Enter variable name:");
                        string variable = Console.ReadLine();
                        Console.WriteLine("Enter variable value:");
                        string value = Console.ReadLine();
                        double val = double.Parse(value);


                        if (tree.variables.ContainsKey(variable))
                        {
                            tree.variables[variable] = val;
                        }
                        else
                        {
                            tree.variables.Add(variable, val);
                        }
                        break;

                    case "3":
                        tree = new ExpressionTree(expression);
                        
                      
                        Console.WriteLine(tree.Evaluate());
                        break;

                    case "4":
                        exitApp = true;
                        break;


                    default:
                        Console.WriteLine("Invalid option. Try again");
                        break;
                }


            } while (exitApp = true);
        }
        private static void MenuOption()
        {
            Console.WriteLine("1 = Enter a new expression");
            Console.WriteLine("2 = Set aa variable value");
            Console.WriteLine("3 = Evaluate tree");
            Console.WriteLine("4 = Quit");
        }
    }
}
