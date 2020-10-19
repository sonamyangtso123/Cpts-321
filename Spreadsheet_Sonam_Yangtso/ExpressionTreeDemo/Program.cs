using System;

namespace CptS321
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string expression = "x+y";
            ExpressionTree tree = new ExpressionTree(expression);
            string varName = string.Empty;
            string varVal = string.Empty;
            do
            {
                Console.WriteLine("Menu (current expression =" + tree.Expression + ")");
                MenuOption();
                string userInput = Console.ReadLine();
                Console.WriteLine();
                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Enter new epression: ");
                        tree = new ExpressionTree(Console.ReadLine());
                        break;

                    case "2":
                        Console.WriteLine("Enter variable name:");
                        varName = Console.ReadLine();
                        Console.WriteLine("Enter variable value:");
                        string varValue = Console.ReadLine();
                        tree.SetVariable(varName, Convert.ToDouble(varValue));
                        break;

                    case "3":
                        // tree = new ExpressionTree(expression);
                        Console.WriteLine(tree.Evaluate());
                        break;

                    case "4":
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Try again");
                        break;
                }
            }
            while (true);
        }

        private static void MenuOption()
        {
            Console.WriteLine("1 = Enter a new expression");
            Console.WriteLine("2 = Set a variable value");
            Console.WriteLine("3 = Evaluate tree");
            Console.WriteLine("4 = Quit");
        }
    }
}
