using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Lab2
{
    [Serializable]
    /// <summary>
    /// абстрактный класс транспорт
    /// так как марка, номер, грузоподъемность и скорость есть у всех представителей класса, записываем эти параметры в абстрактный класс
    /// </summary>
    public abstract class Transport
    {

        public string Marka { get; set; }
        public string Number { get; set; }
        public int Gruz { get; set; }
        public string Speed { get; set; }
        /// <summary>
        /// конструктор по умолчанию
        /// </summary>
        public Transport() { }
        /// <summary>
        /// конструктор для Transport
        /// </summary>
        /// <param name="marka">Марка</param>
        /// <param name="number">Номер</param>
        /// <param name="gruz">Грузоподъемность</param>
        /// <param name="speed">Скорость</param>
        public Transport(string marka, string number, string speed, int gruz)
        {
            Marka = marka;
            Number = number;
            Gruz = gruz;
            Speed = speed;
        }
        /// <summary>
        /// абстрактный метод вывода на экран
        /// </summary>
        public abstract void print();

        /// <summary>
        /// абстрактный метод запроса к базе 
        /// </summary>
        /// <param name="ch">число, содержащее значение грузоподъемности, по которой будет производиться поиск</param>
        /// <returns>возвращает строку, в которой храниться результат</returns>
        public abstract string chapp(int ch);
    }
    [Serializable]
    /// <summary>
    /// производный класс: PassengerCar
    /// </summary>
    public class PassengerCar : Transport
    {
        public string LastName { get; set; }
        /// <summary>
        /// конструктор по умолчанию 
        /// </summary>
        public PassengerCar() { }
        /// <summary>
        /// конструктор класса PassenegerCar
        /// </summary>
        /// <param name="marka">Марка</param>
        /// <param name="number">Номер</param>
        /// <param name="gruz">Грузоподъемность</param>
        /// <param name="speed">Скорость</param>
        public PassengerCar(string marka, string number, string speed, int gruz) : base(marka, number, speed, gruz)
        {

        }
        /// <summary>
        /// определение метода вывода для класса PassengerCar
        /// </summary>
        public override void print()
        {
            Console.WriteLine("PassengerCar Марка: " + Marka + ", Номер: " + Number + ", Скорость: " + Speed + ", Грузоподъемность: " + Gruz);
            Trace.WriteLine("Работа метода print для класса  была завершена");
        }
        /// <summary>
        /// определение метода запроса к базе для класса PassengerCar
        /// </summary>
        /// <param name="Gruzik">значение грузоподъемности по которому будет производиться поиск</param>
        /// <returns> возвращает либо пустую строку, либо все поля для найденной пассажирской машины</returns>
        public override string chapp(int Gruzik)
        {
            string input = "";
            if (Gruzik <= Gruz)
                input = input + "PassengerCar Марка: " + Marka + ", Номер: " + Number + ", Скорость: " + Speed + ", Грузоподъемность: " + Gruz;
            return input;
        }


    }
    [Serializable]
    /// <summary>
    /// производный класс: Motorcycle
    /// </summary>
    public class Motorcycle : Transport
    {
        public string Col { get; set; }
        /// <summary>
        /// конструктор по умолчанию 
        /// </summary>
        public Motorcycle() { }
        /// <summary>
        /// конструктор класса Motorcyle
        /// </summary>
        /// <param name="col"> Коляска</param>
        /// <param name="marka">Марка</param>
        /// <param name="number">Номер</param>
        /// <param name="speed">Скорость</param>
        /// <param name="gruz">Грузоподъемность/param>
        public Motorcycle(string marka, string number, string speed, int gruz, string col)
            : base(marka, number, speed, gruz)
        {
            Col = col;
            if (col == "no")
            {
                Gruz = 0;
            }
        }
        /// <summary>
        /// определение метода вывода для класса Motorcycle
        /// </summary>
        public override void print()
        {
            Console.WriteLine("Motorcycle Марка: " + Marka + ", Номер: " + Number + ", Скорость: " + Speed + ", Грузоподъемность: " + Gruz + ",Коляска: " + Col);
        }
        /// <summary>
        /// определение метода запроса к базе для класса Motorcycle
        /// </summary>
        /// <param name="Gruzik">значение  по которому будет производиться поиск</param>
        /// <returns>возвращает либо пустую строку, либо все поля для найденного мотоцикла </returns>
        public override string chapp(int Gruzik)
        {
            string input = "";
            if (Gruzik <= Gruz)
                input = input + "Motorcycle Марка: " + Marka + ", Номер: " + Number + ", Скорость: " + Speed + ", Грузоподъемность: " + Gruz + ",Коляска: " + Col;
            return input;
        }
    }
    [Serializable]
    /// <summary>
    /// производный класс: Truck
    /// </summary>
    public class Truck : Transport
    {
        public string Pricep { get; set; }
        /// <summary>
        /// конструктор класса Truck
        /// </summary>
        public Truck() { }
        /// <param name="pric"> Прицеп</param>
        /// <param name="marka">Марка</param>
        /// <param name="number">Номер</param>
        /// <param name="speed">Скорость</param>
        /// <param name="gruz">Грузоподъемностоь</param>
        public Truck(string marka, string number, string speed, int gruz, string pric)
            : base(marka, number, speed, gruz)
        {
            Pricep = pric;
            if (pric == "yes")
            {
                Gruz = gruz * 2;
            }
        }
        /// <summary>
        /// определение метода вывода для класса Truck
        /// </summary>
        public override void print()
        {
            Console.WriteLine("Truck Марка: " + Marka + ", Номер: " + Number + ", Скорость: " + Speed + ", Грузоподъемность: " + Gruz + ",Прицеп: " + Pricep);
        }
        /// <summary>
        /// определение метода запроса к базе для класса Truck
        /// </summary>
        /// <param name="Gruzik"> значение грузоподъемности по которому будет производиться поиск</param>
        /// <returns>возвращает либо пустую строку, либо все поля для найденного фургона</returns>
        public override string chapp(int Gruzik)
        {
            string input = "";
            if (Gruzik <= Gruz)
                input = input + "Truck Марка: " + Marka + ", Номер: " + Number + ", Скорость: " + Speed + ", Грузоподъемность: " + Gruz + ",Прицеп: " + Pricep;
            return input;
        }
    }

    /// <summary>
    /// основной класс
    /// </summary>
    class Program
    {
        /// <summary>
        /// метод чтения из файла
        /// все данные записываются в двумерный массив
        /// входные данные: поля отделены символом ';', строки - переносом строки, на месте пропусков стоит "-" 
        /// первая строка - число, обозначающее количество строк в будущем массиве
        /// </summary>
        /// <param name="inFile"> путь к файлу </param>
        /// <returns> возвращает массив с данными</returns>
        static string[,] Read(string inFile, int n)
        {
            string[] lines = new string[n];
            string[] line = File.ReadAllLines(inFile);
            for (int i = 1; i <= n; i++)
                lines[i - 1] = line[i];
            string[,] arr = new string[n, 6];
            for (int i = 0; i < n; i++)
            {
                string[] temp = lines[i].Split(';');
                for (int j = 0; j < 6; j++)
                    arr[i, j] = temp[j];
            }
            return arr;
        }
        /// <summary>
        /// метод добавления в список и разделения на классы
        /// </summary>
        /// <param name="trans">список, в который будут помещаться данные</param>
        /// <param name="arrT">массив с данными</param>
        /// <returns> список с данными</returns>
        static List<Transport> Add(List<Transport> trans, string[,] arrT, int n)
        {

            for (int i = 0; i < n; i++)
            {
                if (arrT[i, 4] != "-")
                    trans.Add(new Motorcycle(arrT[i, 0], arrT[i, 1], arrT[i, 2], Int32.Parse(arrT[i, 3]), (arrT[i, 4])));
                else if (arrT[i, 5] != "-")
                    trans.Add(new Truck(arrT[i, 0], arrT[i, 1], arrT[i, 2], Int32.Parse(arrT[i, 3]), arrT[i, 5]));
                else if (arrT[i, 4] == "-" && arrT[i, 5] == "-")
                    trans.Add(new PassengerCar(arrT[i, 0], arrT[i, 1], arrT[i, 2], Int32.Parse(arrT[i, 3])));
            }
            return trans;
        }
        /// <summary>
        /// вход в программу
        /// определяется путь к файлу
        /// запрашивается действие
        /// в зависимости от выбора, запускается метод(или выводится сообщение об ошибке)
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Введите путь исходного файла:");
            string inFile = Console.ReadLine();
            //string inFile = "pp.txt";
            StreamReader ifile = new StreamReader(inFile);
            string strIn = ifile.ReadLine();
            int n = Int32.Parse(strIn);
            ifile.Close();
            string[,] arrDatabase = Read(inFile, n);
            List<Transport> transbd = new List<Transport>();
            transbd = Add(transbd, arrDatabase, n);
            string k = "0";
            while (k != "3")
            {
                Console.WriteLine("Выберите действие:\n" +
                "1)Вывод автомобильной базы данных\n" +
                "2)Поиск по требованию грузоподъемности\n" +
                "3)Выход из программы");
                k = (Console.ReadLine());
                if (k == "1")
                {
                    Console.WriteLine();
                    foreach (Transport T in transbd)
                        T.print();
                    Console.WriteLine();
                }
                else if (k == "2")
                {
                    Console.WriteLine();
                    Console.WriteLine("Введите грузоподъемность:");
                    string str = Console.ReadLine();
                    string input = "";
                    string input1 = "";
                    foreach (Transport P in transbd)
                    {
                        input = input + P.chapp(Int32.Parse(str)) + '\n';
                        input1 = input1 + P.chapp(Int32.Parse(str));

                    }
                    if (input1 == "")
                    {
                        Console.WriteLine("Ничего не найдено");
                        Console.WriteLine();
                    }
                    else Console.WriteLine(input);
                }
                else if (k == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Ошибка\n" +
                        "Выберите действие:\n" +
                        "1)Вывод автомобильной базы данных\n" +
                        "2)Поиск по требованию грузоподъемности\n" +
                        "3)Выход из программы");
                    Console.WriteLine();
                    k = (Console.ReadLine());
                }

            }

        }

    }
}

