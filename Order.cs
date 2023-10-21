using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Тортики
{
    internal class Order
    {
        public static int Menu()
        {
            int pos = 1;
            Cake? cake = new Cake();
            while (pos != 0)
            {
                Console.Clear();
                Console.WriteLine("Выберите параметр торта:");
                Console.WriteLine("  Форма");
                Console.WriteLine("  Размер");
                Console.WriteLine("  Основа");
                Console.WriteLine("  Начинка");
                Console.WriteLine("  Количество коржов");
                Console.WriteLine("  Декор");
                Console.WriteLine("  Отправить заказ");
                Console.WriteLine();
                List<string> orders = Orders(cake);
                Console.Write("Заказ: ");
                foreach (var c in orders)
                {
                    if (orders.Last() != c)
                    {
                        if (orders.First() != c)
                        {
                            Console.Write(", ");
                        }
                        Console.Write(c);
                    }
                    else
                    {
                        Console.WriteLine($"\nЦена: {c}");
                    }
                }
                pos = Arrow.Show(1, 7);
                switch (pos)
                {
                    case 1: cake.form = Option(pos, cake.form); break;
                    case 2: cake.size = Option(pos, cake.size); break;
                    case 3: cake.ground = Option(pos, cake.ground); break;
                    case 4: cake.filling = Option(pos, cake.filling); break;
                    case 5: cake.amout = Option(pos, cake.amout); break;
                    case 6: cake.decor = Option(pos, cake.decor); break;
                    case 7: pos = Save(cake); break;
                }
            }
            return pos;
        }

        static Description Option(int pos, Description? cake)
        {
            List<Description> points = new List<Description>();
            switch(pos)
            {
                case 1:
                    Description a = new()
                    {
                        desctiption = "  Круг",
                        price = 300
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Квадрат",
                        price = 400
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Прямоугольник",
                        price = 500
                    };
                    points.Add(a);
                    break;
                case 2:
                    a = new Description()
                    {
                        desctiption = "  Маленький (круг - 20 см, квадрат - 15х15 см, прямоугольник - 30х20 см)",
                        price = 300
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Средний (круг - 24 см, квадрат - 20х20 см, прямоугольник - 35х25 см)",
                        price = 500
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Большой (круг - 28 см, квадрат - 25х25 см, прямоугольник - 40х30 см",
                        price = 700
                    };
                    points.Add(a);
                    break;
                case 3:
                    a = new Description()
                    {
                        desctiption = "  Ванильный бисквит",
                        price = 250
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Шоколадный бисквит",
                        price = 200
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Мраморный бисквит",
                        price = 150
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Медовое печенье",
                        price = 150
                    };
                    points.Add(a);
                    break;
                case 4:
                    a = new Description()
                    {
                        desctiption = "  Малина",
                        price = 400
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Клубника",
                        price = 500
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Вишня",
                        price = 800
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Карамель",
                        price = 300
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Шоколад",
                        price = 300
                    };
                    points.Add(a);
                    break;
                case 5:
                    a = new Description()
                    {
                        desctiption = "  1 уровень",
                        price = 200
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  2 уровня",
                        price = 400
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  3 уровня",
                        price = 600
                    };
                    points.Add(a);
                    break;
                case 6:
                    a = new Description()
                    {
                        desctiption = "  Безе",
                        price = 200
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Маршмеллоу",
                        price = 400
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Шоколадная струшка",
                        price = 300
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Фигурное печенье",
                        price = 300
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Фисташки",
                        price = 400
                    };
                    points.Add(a);
                    a = new Description()
                    {
                        desctiption = "  Фундук",
                        price = 400
                    };
                    points.Add(a);
                    break;
                case 8:
                    return cake;
            }
            Console.Clear();
            Console.WriteLine("Выберите параметр:");
            foreach (var point in points)
            {
                Console.WriteLine($"{point.desctiption} - {point.price}");
            }
            pos = Arrow.Show(1, points.Count);
            if (pos == 0)
            {
                return cake;
            }
            return points[pos-1];
        }

        static List<string> Orders(Cake cake)
        {
            List<string> descriptions = new();
            int prices = 0;
            try
            {
                descriptions.Add($"{cake.form.desctiption} - {cake.form.price}");
                prices += cake.form.price;
            }
            catch (Exception) {}
            try
            {
                descriptions.Add($"{cake.size.desctiption} - {cake.size.price}");
                prices += cake.size.price;
            }
            catch (Exception) {}
            try
            {
                descriptions.Add($"{cake.ground.desctiption} - {cake.ground.price}");
                prices += cake.ground.price;
            }
            catch (Exception) { }
            try
            {
                descriptions.Add($"{cake.filling.desctiption} - {cake.filling.price}");
                prices += cake.filling.price;
            }
            catch (Exception) { }
            try
            {
                descriptions.Add($"{cake.amout.desctiption} - {cake.amout.price}");
                prices += cake.amout.price;
            }
            catch (Exception) { }
            try
            {
                descriptions.Add($"{cake.decor.desctiption} - {cake.decor.price}");
                prices += cake.decor.price;
            }
            catch (Exception) { }
            string prices1 = prices.ToString();
            descriptions.Add(prices1);
            return descriptions;
        }

        private static int Save(Cake cake)
        {
            List<string> orders = Orders(cake);
            string save = $"Заказ от {DateTime.Now}\n\t";
            foreach (var c in orders)
            {
                if (orders.Last() != c)
                {
                    if (orders.First() != c)
                    {
                        save += ", ";
                    }
                    save += c;
                }
                else
                {
                    save += $"\n\tЦена: {c}";
                }
            }
            Console.Clear();
            File.AppendAllText("orders.txt",$"\n{save}");
            Console.WriteLine("Заказ сделан. Сделать ещё один заказ?");
            Console.WriteLine("  Да");
            Console.WriteLine("  Нет");
            int pos = Arrow.Show(1, 2);
            if (pos == 2)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
