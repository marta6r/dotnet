using System;

namespace CompanyHierarchy
{
    // Базовый класс Организация
    public class Organization
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public Organization(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"Организация: {Name}");
            Console.WriteLine($"Адрес: {Address}");
        }
    }

    // Класс Страховая компания
    public class InsuranceCompany : Organization
    {
        public int NumberOfPolicies { get; set; }

        public InsuranceCompany(string name, string address, int numberOfPolicies)
            : base(name, address)
        {
            NumberOfPolicies = numberOfPolicies;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Количество страховых полисов: {NumberOfPolicies}");
        }
    }

    // Класс Нефтегазовая компания
    public class OilAndGasCompany : Organization
    {
        public double OilProduction { get; set; } // в баррелях в день

        public OilAndGasCompany(string name, string address, double oilProduction)
            : base(name, address)
        {
            OilProduction = oilProduction;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Добыча нефти (баррелей в день): {OilProduction}");
        }
    }

    // Класс Завод
    public class Factory : Organization
    {
        public int NumberOfWorkers { get; set; }

        public Factory(string name, string address, int numberOfWorkers)
            : base(name, address)
        {
            NumberOfWorkers = numberOfWorkers;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Количество работников: {NumberOfWorkers}");
        }
    }

    class Program
    {
        static void Main()
        {
            Organization org = new Organization("Общая организация", "ул. Центральная, 1");
            InsuranceCompany insurance = new InsuranceCompany("Страховая компания \"Защита\"", "ул. Ленина, 10", 1500);
            OilAndGasCompany oilGas = new OilAndGasCompany("Нефтегазовая компания \"НГК\"", "пр. Мира, 25", 10000.5);
            Factory factory = new Factory("Завод \"Металл\"", "ул. Промышленная, 5", 300);

            org.DisplayInfo();
            Console.WriteLine();

            insurance.DisplayInfo();
            Console.WriteLine();

            oilGas.DisplayInfo();
            Console.WriteLine();

            factory.DisplayInfo();

            // Ожидание нажатия клавиши для закрытия консоли
            Console.ReadKey();
        }
    }
}
