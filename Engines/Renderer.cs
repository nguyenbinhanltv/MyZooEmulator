using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZooEmulator.Engines
{
    class Renderer
    {
        //private static readonly Renderer instance = new Renderer();
        private static int _top;
        private static int _left;
        private Renderer() { }

        public static string Message { get; set; }

        //public static Renderer GetInstance()
        //{
        //    return instance;
        //}
        
        public static void PrintHeader()
        {
            Console.Clear();        
            Console.WriteLine("-------------------------");
            Console.WriteLine("     Sở thú diệu kì      ");
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            
            PrintPrevMessage();
        }
        
        public static void PrintMessage(string message)
        {
            Message = message;
            
            _left = Console.CursorLeft;
            _top = Console.CursorTop;
            
            Console.SetCursorPosition(0, 6);
            Console.WriteLine("");
            
            Console.SetCursorPosition(0, 6);
            Console.WriteLine($"Thông báo:  {message} !!!");
            
            Console.SetCursorPosition(_left, _top);
        }

        public static void PrintWeather(string message)
        {
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("");
            
            Console.SetCursorPosition(0, 4);
            Console.WriteLine($"Thời tiết:  {message} !!!");
            
            Console.SetCursorPosition(_left, _top);
        }
        
        public static void PrintPrevMessage()
        {
            PrintMessage(Message);
        }
        
        public static int DisplayMenu(string name, IEnumerable<string> items)
        {
            // Print menu
            Console.WriteLine(name);
            Console.WriteLine();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            try
            {
                var result = Console.ReadLine();
                var value = Convert.ToInt32(result);
                if (value < 1 || value > items.Count() + 1)
                {
                    throw new IndexOutOfRangeException();
                }
                return value;
            }
            catch (IndexOutOfRangeException)
            {
                PrintMessage($"Value not in range [1-{items.Count()}]");
            }
            catch (Exception)
            {
                PrintMessage("Wrong input");
            }
            return 0;
        }
    }
}
