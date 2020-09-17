using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Record.Main_Record();
        }
    }

    class Record
    {
        //
        public static List<double> points = new List<double>();
        public static List<double> distance = new List<double>();


        //
        public static string Name;

        //
        public static int NumberPointsFirst = 0;
        public static double SecondDistance = 0;

        //Получаем имя и количевство точек нашей фигуры.
        public static void Main_Record()
        {
            if(display.CheckPoints == true)
            {
                Console.Write("\n Введите имя вашей фигры := ");
                Name = Console.ReadLine();
            }

            Console.Write("\n Введите количевство точек := ");

            //Проверка данных
            while (!int.TryParse(Console.ReadLine(), out NumberPointsFirst))
            {
                Console.Write("\n Ошибка ввода!\n\n Введите количевство точек (Число) := ");
            }
            
            //
            while(NumberPointsFirst < 1)
            {
                while (!int.TryParse(Console.ReadLine(), out NumberPointsFirst))
                {
                    Console.Write("\n Ошибка ввода!\n\n Количевство точек не может быть равным нулю := ");
                }

                if (NumberPointsFirst >= 1)
                {
                    break;
                }
            }
            Record_Distance();
        }

        //Ввод данных в лист.
        public static void Record_Distance(int inumA = 1, int inumB = 2, double Coordinates = 0, double Container = 0)
        {
            for (int i = 0; i < NumberPointsFirst; i++)
            {
                Console.Write("\n Введите координаты точки " + (inumA++) + " := ");

                while (!double.TryParse(Console.ReadLine(), out Coordinates))
                {
                    Console.Write("\n Ошибка ввода!\n\n Введите число : = ");
                }
                points.Add(Coordinates);
            }
            
            if(NumberPointsFirst == 1)
            {
                display.MainProgram();
            }
            else if(NumberPointsFirst == 2)
            {
                Console.Write("\n Введите дистанцию от точки " + 1 + " до точки " + 2 + " := ");

                while (!double.TryParse(Console.ReadLine(), out SecondDistance))
                {
                    Console.Write("\n Ошибка ввода!\n\n Введите число : = ");
                }
                distance.Add(SecondDistance);
                display.MainProgram();
            }
            else
            {
                inumA = 1;

                for (int i = 0; i < NumberPointsFirst; i++)
                {
                    Container++;

                    if (Container == NumberPointsFirst)
                    {
                        inumB = 1;
                    }

                    Console.Write("\n Введите дистанцию от точки " + inumA++ + " до точки " + inumB++ + " := ");

                    while (!double.TryParse(Console.ReadLine(), out SecondDistance))
                    {
                        Console.Write("\n Ошибка ввода!\n\n Введите число : = ");
                    }
                    distance.Add(SecondDistance);
                }
                display.MainProgram();
            }
        }
        public static void Record_File(bool SaveFlag = true, int SaveChoice = 0)
        {
            if (Options_Figure.containerLastValue == 0 && display.MainType != "Треугольника" && display.MainType != "Прямоугольника" && display.MainType != "Квадрата" && display.MainType != "Круга")
            {
                Console.Write("\n Вы не получили обьем " + display.MainType + " хотите получить обьем? \n\n 1: Да. \n\n 2: Нет. \n\n Ваш выбор:= ");
                while (!int.TryParse(Console.ReadLine(), out SaveChoice))
                {
                    Console.Write("\n Ошибка ввода!\n\n Введите число := ");

                }
                while (SaveFlag)
                {
                    switch (SaveChoice)
                    {
                        case 1:
                            {
                                Options_Figure.Volume();
                                break;
                            }
                        case 2:
                            {
                                break;
                            }
                    }
                    SaveFlag = false;
                }
                SaveFlag = true;
                SaveChoice = 0;
            }
            Console.Write("\n\n Вы хотите сохранить вашу фигуру? \n\n 1: Сохранить. \n\n 2: Не сохранять. \n\n 3: Выход.\n\n Ваш выбор:= ");

            while (!int.TryParse(Console.ReadLine(), out SaveChoice))
            {
                Console.Write("\n Ошибка ввода!\n\n Введите число := ");
            }
            while (SaveFlag)
            #region
            {
                switch (SaveChoice)
                {
                    case 1:
                        {
                            using (StreamWriter StreamWriter_ = new StreamWriter(@"C:\Users\German\Desktop\Project_2\Value.txt", true))
                            {
                                StreamWriter_.WriteLine(" N := " + Name);
                                if (display.MainType == "Цилиндра")
                                {
                                    
                                    StreamWriter_.WriteLine("\n R := " + display.MainRadius);
                                    Console.Write("\n R := " + display.MainRadius);
                                    StreamWriter_.WriteLine("\n h := " + display.MainHeight);
                                    Console.Write("\n h := " + display.MainHeight);
                                    StreamWriter_.WriteLine(" V := " + Options_Figure.containerLastValue);
                                }
                                else if (display.MainType == "Круга")
                                {
                                    StreamWriter_.WriteLine("\n R := " + display.MainRadius);
                                    Console.Write("\n R := " + display.MainRadius);
                                }
                                if(SecondDistance == 0)
                                {
                                    StreamWriter_.WriteLine(" Dis := None");
                                    StreamWriter_.Write(" Pos := ");
                                    foreach (int i in points)
                                    {
                                        StreamWriter_.Write(i + " ");
                                    }
                                }
                                else
                                {
                                    StreamWriter_.Write(" Dis := ");
                                    foreach (int i in distance)
                                    {
                                        StreamWriter_.Write(i + " ");
                                    }
                                    StreamWriter_.Write(" Pos := " );
                                    foreach (int i in points)
                                    {
                                        StreamWriter_.Write(i + " ");
                                    }
                                }
                                
                                StreamWriter_.WriteLine(" S := " + Options_Figure.containerLast);
                            }

                            SaveChoice = 0;

                            Console.Write("\n\n Вы хотите продолжить? \n\n 1: Да \n\n 2: Нет \n\n Ваш выбор:= ");

                            while (!int.TryParse(Console.ReadLine(), out SaveChoice))
                            {
                                Console.Write("\n Ошибка ввода!\n\n Введите число := ");
                            }

                            while (SaveFlag)
                            {
                                switch(SaveChoice)
                                {
                                    case 1:
                                        {
                                            Main_Record();
                                            break;
                                        }
                                    case 2:
                                        {
                                            break;
                                        }
                                }
                                SaveFlag = false;
                            }
                            break;
                        }
                    case 2:
                        {
                            Main_Record();
                            break;
                        }
                    case 3:
                        {
                            break;
                        }
                }
                distance.Clear();
                points.Clear();
                SaveFlag = false;
            }
            #endregion
        }
    }

    class display
    {
        //
        public static string MainType;

        //
        public static double MainHeight;
        public static double MainRadius;

        //
        public static bool CheckPoints = true;
        
        public static void MainProgram(bool flag = true, int choice = 0)
        {
            if (Record.NumberPointsFirst == 1)
            #region
            {
                Console.Write("\n\n 1: Ваша фигура (Цилиндр) \n\n 2: Ваша фигура (Круг) \n\n 3: Выход.\n\n Ваш выбор:= ");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("\n Ошибка ввода!\n\n Введите число := ");
                }

                while (flag)
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                MainType = "Цилиндра";

                                flag = true;

                                choice = 0;

                                Console.Write("\n Введите высоту : = ");

                                while (!double.TryParse(Console.ReadLine(), out MainHeight))
                                {
                                    Console.Write("\n Ошибка ввода!\n\n Введите высоту := ");
                                }

                                Console.Write("\n Введите радиус : = ");

                                while (!double.TryParse(Console.ReadLine(), out MainRadius))
                                {
                                    Console.Write("\n Ошибка ввода!\n\n Введите высоту := ");
                                }

                                Console.Write("\n Параметры:\n\n 1: Периметр\n\n 2: Обьем.\n\n 3: Выход.\n\n Ваш выбор:= ");

                                while (!int.TryParse(Console.ReadLine(), out choice))
                                {
                                    Console.Write("\n Ошибка ввода!\n\n Введите число := ");
                                }

                                while (flag)
                                {
                                    switch (choice)
                                    {
                                        case 1:
                                            {
                                                Options_Figure.Perimeter();
                                                break;
                                            }
                                        case 2:
                                            {
                                                Options_Figure.Volume();
                                                break;
                                            }
                                        case 3:
                                            {
                                                break;
                                            }
                                    }
                                    flag = false;
                                }
                                break;
                            }
                        case 2:
                            {
                                MainType = "Круга";

                                flag = true;

                                choice = 0;

                                Console.Write("\n Введите радиус : = ");

                                while (!double.TryParse(Console.ReadLine(), out MainRadius))
                                {
                                    Console.Write("\n Ошибка ввода!\n\n Введите высоту := ");
                                }

                                Console.Write("\n Параметры:\n\n 1: Периметр\n\n 2: Выход.\n\n Ваш выбор:= ");

                                while (!int.TryParse(Console.ReadLine(), out choice))
                                {
                                    Console.Write("\n Ошибка ввода!\n\n Введите число := ");
                                }

                                while (flag)
                                {
                                    switch (choice)
                                    {
                                        case 1:
                                            {
                                                Options_Figure.Perimeter();
                                                break;
                                            }
                                        case 2:
                                            {
                                                break;
                                            }
                                    }
                                    flag = false;
                                }
                                break;
                            }
                        case 3:
                            {
                                break;
                            }
                        default:
                            {
                                Console.Write("\n Ошибка ввода!\n\n Сделайте ваш выбор : = ");
                                MainProgram();
                                break;
                            }
                    }
                    flag = false;
                }
            }
            #endregion
            else if (Record.NumberPointsFirst == 2)
            {
                Console.Write("\n Ваша фигура отрезок.\n\n Длинна отрезка равна : = " + Record.distance.ElementAtOrDefault(0));
            }
            else if (Record.NumberPointsFirst == 3)
            #region
            {
                MainType = "Треугольника";

                flag = true;

                choice = 0;

                Console.Write("\n Параметры:\n\n 1: Периметр\n\n 2: Выход.\n\n Ваш выбор:= ");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("\n Ошибка ввода!\n\n Введите число := ");
                }

                while (flag)
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Options_Figure.Perimeter();
                                break;
                            }
                        case 2:
                            {
                                break;
                            }
                    }
                    flag = false;
                }
            }
            #endregion
            else if (Record.NumberPointsFirst == 4)
            #region
            {
                for (int i = 0; i < Record.NumberPointsFirst; i++)
                {
                    int count = Record.distance.Count;
                    if (count == count++)
                    {
                        Console.Write("\n Ваша фигура квадрат.");

                        MainType = "Квадрата";

                        flag = true;

                        choice = 0;

                        Console.Write("\n Параметры:\n\n 1: Периметр\n\n 2: Выход.\n\n Ваш выбор:= ");

                        while (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.Write("\n Ошибка ввода!\n\n Введите число := ");
                        }

                        while (flag)
                        {
                            switch (choice)
                            {
                                case 1:
                                    {
                                        Options_Figure.Perimeter();
                                        break;
                                    }
                                case 2:
                                    {
                                        break;
                                    }
                            }
                            flag = false;
                        }
                        break;
                    }
                    else if (count != count++)
                    {
                        Console.Write("\n Ваша фигура прямоугольник.");

                        MainType = "Прямоугольника";

                        flag = true;

                        choice = 0;

                        Console.Write("\n Параметры:\n\n 1: Периметр\n\n 2: Выход.\n\n Ваш выбор:= ");

                        while (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.Write("\n Ошибка ввода!\n\n Введите число := ");
                        }

                        while (flag)
                        {
                            switch (choice)
                            {
                                case 1:
                                    {
                                        Options_Figure.Perimeter();
                                        break;
                                    }
                                case 2:
                                    {
                                        break;
                                    }
                            }
                            flag = false;
                        }
                        break;
                    }
                    else
                    {
                        Console.Write("\n Ваша фигура четырехугольник.");
                    }
                }
            }
            #endregion
            else if (Record.NumberPointsFirst == 5)
            #region
            {
                MainType = "Пирамида";

                flag = true;

                choice = 0;

                Console.Write("\n Параметры:\n\n 1: Периметр\n\n 2: Выход.\n\n Ваш выбор:= ");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("\n Ошибка ввода!\n\n Введите число := ");
                }

                while (flag)
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Options_Figure.Perimeter();
                                break;
                            }
                        case 2:
                            {
                                break;
                            }
                    }
                    flag = false;
                }
            }
            #endregion
            else if (Record.NumberPointsFirst == 6)
            {
                MainType = "Треугольная_Призма";
            }

            else if (Record.NumberPointsFirst == 7)
            {
                MainType = "Семиугольника";
            }

            else if (Record.NumberPointsFirst == 8)
            #region
            {
                MainType = "Куба";

                flag = true;

                choice = 0;

                Console.Write("\n Параметры:\n\n 1: Периметр\n\n 2: Выход.\n\n Ваш выбор:= ");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("\n Ошибка ввода!\n\n Введите число := ");
                }

                while (flag)
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                Options_Figure.Perimeter();
                                break;
                            }
                        case 2:
                            {
                                break;
                            }
                    }
                    flag = false;
                }
            }
            #endregion
            else
            {
                Console.Write("\n Вы ввели слишком много точек!");
                CheckPoints = false;
                Record.Main_Record();
            }
            Record.Record_File();
        }
    }

    class Options_Figure
    {
        public static double containerFirst;
        public static double containerLast;
        public static double containerLastValue;
        
        public static void Perimeter()
        {
            display.CheckPoints = true;

            if (display.MainType == "Круга")
            {
                containerLast = display.MainRadius * 3.1415;
            }
            else if (display.MainType == "Цилиндра")
            {
                containerLast = 3.141 * (Math.Pow((display.MainRadius * display.MainRadius), 2) / 4);
                containerFirst = 3.141 * display.MainRadius * display.MainRadius * display.MainHeight;
                containerLast = (2 * containerLast) + containerFirst;
            }
            else if (display.MainType == "Треугольника")
            {
                    containerLast = Record.distance.ElementAtOrDefault(0) + Record.distance.ElementAtOrDefault(1) + Record.distance.ElementAtOrDefault(2);
            }
            else if (display.MainType == "Куб")
            {
                containerLast = Math.Pow(Record.distance.ElementAtOrDefault(0), 3);
            }
            else if (display.MainType == "Прямоугольника")
            {
                containerLast = Record.distance.ElementAtOrDefault(0) * Record.distance.ElementAtOrDefault(1);
            }
            else if (display.MainType == "Квадрата")
            {
                containerLast = Record.distance.ElementAtOrDefault(0) + Record.distance.ElementAtOrDefault(1) + Record.distance.ElementAtOrDefault(2) + Record.distance.ElementAtOrDefault(3);
            }
            else if (display.MainType == "Пирамида")
            {
                containerFirst = Math.Pow(Record.distance.ElementAtOrDefault(0), 4) + 2 * Record.distance.ElementAtOrDefault(1);
                containerLast = containerFirst * Math.Sqrt((Math.Pow(Record.distance.ElementAtOrDefault(4), 2)) - (Math.Pow(Record.distance.ElementAtOrDefault(0), 2) / 4));
                Console.Write("\n Периметр пирамиды равен := " + containerLast);
            }
            if (display.MainType != "Пирамида")
            {
                Console.WriteLine("\n Периметр " + display.MainType + " равен := " + containerLast);
            }
        }
        public static void Volume()
        {
            if (display.MainType == "Цилиндра")
            {
                containerLastValue = 3.141 * Math.Pow(display.MainRadius * display.MainRadius,2) / (4 * display.MainHeight);
                Console.WriteLine("\n Обьем " + display.MainType + " равен := " + containerLastValue);
            }
            else if(display.MainType == "Пирамида")
            {
                containerLastValue = 1 / 3 * display.MainHeight * Math.Pow(Record.distance.ElementAtOrDefault(0),2);
                Console.WriteLine("\n Обьем " + display.MainType + " равен := " + containerLastValue);
            }
        }
    }
}
