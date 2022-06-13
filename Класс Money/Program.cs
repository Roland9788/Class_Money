using System;

namespace Класс_Money
{

    class Money
    {
        public double Rub;
        public double Cop;

        public Money()
        {
            Rub = 0;
            Cop = 0;
        }
        public Money perevod(Money obj1)
        {
            while (obj1.Cop < 0 && obj1.Rub != 0)
            {
                obj1.Rub--;
                obj1.Cop += 100;
            }
            while (obj1.Rub < 0 && obj1.Cop != 0)
            {
                obj1.Cop -= 100;
                obj1.Rub++;
            }
            return obj1;
        }

        public Money(double Rub, double Cop)
        {
            this.Rub = Rub;
            this.Cop = Cop;
            perevod(this);
        }


        public static Money Add(Money fobj1, Money fobj2)
        {
            Money money = new Money(fobj1.Rub + fobj2.Rub, fobj1.Cop + fobj2.Cop);
            return money;
        }
        public static Money operator +(Money fobj1, Money fobj2)
        {
            return Add(fobj1, fobj2);
        }
        public static Money Sub(Money fobj1, Money fobj2)
        {
            Money money = new Money(fobj1.Rub - fobj2.Rub, fobj1.Cop - fobj2.Cop);
            return money;
        }

        public static Money operator -(Money fobj1, Money fobj2)
        {
            return Sub(fobj1, fobj2);
        }

        public static Money Div(Money fobj1, int fobj2)
        {
            Money money = new Money(fobj1.Rub / fobj2, fobj1.Cop / fobj2);
            return money;
        }
        public static Money operator /(Money fobj1, int fobj2)
        {
            return Div(fobj1, fobj2);
        }


        public static Money Mult(Money fobj1, int fobj2)
        {
            Money money = new Money(fobj1.Rub * fobj2, fobj1.Cop * fobj2);
            return money;
        }
        public static Money operator *(Money fobj1, int fobj2)
        {
            return Mult(fobj1, fobj2);
        }

        public static Money plusplus(Money fobj1)
        {
            Money money = new Money(fobj1.Rub, fobj1.Cop++);
            return money;
        }
        public static Money operator ++(Money fobj1)
        {
            return plusplus(fobj1);
        }

        public static Money minusminus(Money fobj1)
        {
            Money money = new Money(fobj1.Rub, fobj1.Cop--);
            return money;
        }
        public static Money operator --(Money fobj1)
        {
            return minusminus(fobj1);
        }

        public static bool ravni(Money fobj1, Money fobj2)
        {
            if ((fobj1.Rub) == (fobj2.Rub) && (fobj1.Cop == fobj2.Cop))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool neravni(Money fobj1, Money fobj2)
        {
            if ((fobj1.Rub) != (fobj2.Rub) || (fobj1.Cop != fobj2.Cop))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Money fobj1, Money fobj2)
        {
            return ravni(fobj1, fobj2);
        }

        public static bool operator !=(Money fobj1, Money fobj2)
        {
            return neravni(fobj1, fobj2);
        }


        public static bool bolse(Money fobj1, Money fobj2)
        {
            if ((fobj1.Rub) > (fobj2.Rub) || (fobj1.Cop > fobj2.Cop))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(Money fobj1, Money fobj2)
        {
            return bolse(fobj1, fobj2);
        }

        public static bool menche(Money fobj1, Money fobj2)
        {
            if ((fobj1.Rub) < (fobj2.Rub) || (fobj1.Cop < fobj2.Cop))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(Money fobj1, Money fobj2)
        {
            return menche(fobj1, fobj2);
        }

        public void Show()
        {
            Console.WriteLine($"Руб. {Rub}, Cop. {(int)Cop}");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Money money = new Money(50, 1);
            Money money2 = new Money(100, 55);
            bool flag = true;
            do
            {
                try
                {
                    Console.WriteLine("------------Меню------------");
                    Console.WriteLine("1.Ввести денежную сумму (Если не вводить будут использованные значения по умолчанию)");
                    Console.WriteLine("2.Сложить денежные суммы");
                    Console.WriteLine("3.Вычесть денежные суммы");
                    Console.WriteLine("4.Разделить денежную сумму");
                    Console.WriteLine("5.Умножить денежную сумму");
                    Console.WriteLine("6.Увеличить денежную сумму на 1 копейку");
                    Console.WriteLine("7.Уменьшить денежную сумму на 1 копейку");
                    string Answer = Console.ReadLine();
                    if (Answer == "1")
                    {
                        Console.WriteLine("Введите рубли");
                        int Rub = int.Parse(Console.ReadLine());
                        Console.WriteLine("Введите копейки");
                        int Cop = int.Parse(Console.ReadLine());
                        money = new Money(Rub, Cop);
                    }
                    if (Answer == "2")
                    {
                        money = money + money2;
                        Console.WriteLine("Результат: ");
                        money.Show();
                    }
                    if (Answer == "3")
                    {
                        money = money - money2;
                        Console.WriteLine("Результат: ");
                        money.Show();
                    }

                    if (Answer == "4")
                    {
                        Console.WriteLine("Введите число на которое необходимо разделить денежную сумму");
                        int number = int.Parse(Console.ReadLine());
                        money = money / number;
                        Console.WriteLine("Результат: ");
                        money.Show();
                    }

                    if (Answer == "5")
                    {
                        Console.WriteLine("Введите число на которое необходимо умножить денежную сумму");
                        int number = int.Parse(Console.ReadLine());
                        money = money * number;
                        Console.WriteLine("Результат: ");
                        money.Show();
                    }

                    if (Answer == "6")
                    {
                        money = money++;
                        Console.WriteLine("Результат: ");
                        money.Show();
                    }

                    if (Answer == "7")
                    {
                        money = money--;
                        Console.WriteLine("Результат: ");
                        money.Show();
                    }
                    if (money.Cop <= 0 && money.Rub <= 0)
                    {
                        throw new Exception("Вы Банкрот!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"{e.Message}");
                    break;
                }

            } while (true);

        }
    }
}
