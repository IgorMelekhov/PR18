using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PR18
{
    internal class Program
    {
        public static void Error(string message, ConsoleColor cc)
        {
            Console.ForegroundColor = cc;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        class Locality
        {
            public string title;
            public ulong born, died, population;
            public Locality()
            {
                Console.WriteLine("Абстрактный населенный пункт");
            }
            ~Locality()
            {
                Console.WriteLine("Деструктор сработал!");
                Console.ReadKey();
            }
            long Natural_Grows()
            {
                long natural_grows = (long)(born - died);
                if (natural_grows > 0) Console.WriteLine("Естественный прирост населения за этот месяц положительный");
                else Console.WriteLine("Естественный прирост населения за этот месяц отрицательный или нулевой");
                return natural_grows;
            }
            public void GetInfo(string T)
            {
                Console.WriteLine("\nНазвание населенного пункта : {0}" ,title);
                Console.WriteLine("Тип населенного пункта :{0} ",T);
                Console.WriteLine("Население :{0} ", population);
                Console.WriteLine("Ествественный прирост населения за этот месяц равен {0} человек", Natural_Grows());
            }
        }
        class Town : Locality
        {
            public Town()
            {
                Console.WriteLine("1. Параметры населенного пункта");
                Console.Write(" Введите название населенного пункта ");
                string title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка - отсутсвует название");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(2000);
                }
                for (int i = 0; i < title.Length; i++)
                {
                    if (title[i] >= '0' && title[i] <= '9')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("В названии не может быть цифр");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(2000);
                    }
                }
                Console.Write(" Введите нынешнее колличеcтво людей, проживающих в нем ");
                ulong population = (ulong)UInt64.Parse(Console.ReadLine());
                Console.WriteLine(" Вычисление естественного прироста населения ");
                Console.Write(" Сколько детей родилось за этот месяц : ");
                ulong born = (ulong)UInt64.Parse(Console.ReadLine());
                Console.Write(" Сколько людей умерло за этот месяц : ");
                ulong died = (ulong)UInt64.Parse(Console.ReadLine());
                if (died > population)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Не может умереть больше человек, чем сейчас проживает в населеном пункте");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(2000);
                }
            }
            ~Town()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОбЪект город уничтожен");
                Console.ReadKey();
            }
        }
        class Village : Locality
        {
            public Village()
            {
                Console.WriteLine("1. Параметры населенного пункта");
                Console.Write(" Введите название населенного пункта ");
                string title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка - отсутсвует название");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(2000);
                }
                for (int i = 0; i < title.Length; i++)
                {
                    if (title[i] >= '0' && title[i] <= '9')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("В названии не может быть цифр");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Thread.Sleep(2000);
                    }
                }
                Console.Write(" Введите нынешнее колличеcтво людей, проживающих в нем ");
                ulong population = (ulong)UInt64.Parse(Console.ReadLine());
                Console.WriteLine(" Вычисление естественного прироста населения ");
                Console.Write(" Сколько детей родилось за этот месяц : ");
                ulong born = (ulong)UInt64.Parse(Console.ReadLine());
                Console.Write(" Сколько людей умерло за этот месяц : ");
                ulong died = (ulong)UInt64.Parse(Console.ReadLine());
                if (died > population)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Не может умереть больше человек, чем сейчас проживает в населеном пункте");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Thread.Sleep(2000);
                }



            }
            ~Village()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ОбЪект населенный пункт уничтожен");
            }
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Здравствуйте\nПрактическая работа номер 18");
                Console.Write("Введите Y чтобы продолжить или N чтобы выйти ");
                string select_key = Console.ReadLine();
                switch (select_key)
                {
                    case "Y":
                        Town objTown = new Town() ;
                        objTown.GetInfo("Город");
                        Village objVillage = new Village();
                        objVillage.GetInfo("Населенный пункт");
                        break;
                    case "N":
                        Console.WriteLine("До свидания");
                        Thread.Sleep(2000);
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}