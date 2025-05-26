namespace Day33_new2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var context = new AppDbContext())
            {
                // 🔹 Добавление нового туриста
                var tourist = new Tourist { Id_tourist = 6, Surname = "Иванов", Name = "Иван", Middle_name = "Иванович" };
                context.Tourists.Add(tourist);
                context.SaveChanges();

                // 🔹 Изменение данных туриста
                var existingTourist = context.Tourists.FirstOrDefault(t => t.Id_tourist == 1);
                if (existingTourist != null)
                {
                    existingTourist.Name = "Пётр Петров";
                    context.SaveChanges();
                }

                // 🔹 Удаление туриста
                var deleteTourist = context.Tourists.FirstOrDefault(t => t.Id_tourist == 2);
                if (deleteTourist != null)
                {
                    context.Tourists.Remove(deleteTourist);
                    context.SaveChanges();
                }

                // 🔹 Просмотр списка туристов
                var tourists = context.Tourists.ToList();

                // 🔹 Добавление нового тура
                var tour = new Tour { Id_tour = 6, Name = "Экскурсия по Минску", Price = 150.00M, Information = "Новый тур" };
                context.Tours.Add(tour);
                context.SaveChanges();

                // 🔹 Оплата туриста
                var payment = new Payment { Id_payment = 1, Id_travel_package = 1, Payment_data = DateTime.Now, Amount = 200.00M };
                context.Payments.Add(payment);
                context.SaveChanges();

                // 🔹 Просмотр всех туров
                var tours = context.Tours.ToList();

                // 🔹 Добавление туристического пакета
                var travelPackage = new TravelPackage { Id_travel_package = 1, Id_tourist = 1, Id_season = 1};
                context.TravelPackages.Add(travelPackage);
                context.SaveChanges();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

