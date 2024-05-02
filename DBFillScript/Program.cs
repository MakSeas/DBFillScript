using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace DBFillScript
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] adress = { "Химиков", "Ленина","Красноармейская", "Пр-т Октябрьский","Ворошилова","Кузнецкий", "Тухачевского", "Гагарина"};
            string[] rank = { "ЗавКафедрой", "Доцент","Специалист по УМР","Ведущий специалист", "Старший преподаватель","Научный сотрудник" };
            string[] fams = {"Гришин", "Безменов", "Елисеев", "Боголюбов", "Украинцев", "Фомин", "Макаров", "Волков", "Семирадов", "Крыскин", "Данилов", "Тушин", "Елисеева", "Тихомирова", "Ивлеева", "Манулова", "Кузнецова", "Камарова", "Добронравова", "Дурнова", "Благова", "Репкина","Толстокорова" };
            string[] Names = { "Данил", "Андрей", "Елисей", "Дмитрий", "Вячеслав", "Максим", "Александр", "Алексей", "Олег", "Денис", "Кирилл", "Анна", "Алена","Наталья", "Вероника", "Мария", "Елизавета", "Арина", "Елена", "Ксения", "Дарья" };
            string[] fathers = { "Андреевич", "Владимирович", "Алексеевич", "Константинович", "Дмитриевич", "Максимович", "Николаевич", "Ашотович", "Денисович", "Александрович", "Константиновна", "Евгениевна", "Василиевна", "Максимовна", "Дмитриевна", "Алексеевна", "Сергеевна", "Владимировна" };

            Random randnum=new Random();

            

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=PC2; Initial Catalog=Kursachik; Integrated Security=True";
                
            SqlCommand FIllTeachersCommand = new SqlCommand();
            FIllTeachersCommand.Connection = connection;

            for(int i = 0; i < 10000; i++)
            {
                string FIO = $"{fams[randnum.Next(fams.Length)]} {Names[randnum.Next(Names.Length)]} {fathers[randnum.Next(fathers.Length)]}";

                FIllTeachersCommand.CommandText = "Insert into dbo.Студенты(ФИО, Адрес, [ID группы] [Номер телефона])" +
                              $"Values('{FIO}', '{adress[randnum.Next(adress.Length)]}',{randnum.Next(1,26)} ,'8{randnum.Next(10)}{randnum.Next(10)}{randnum.Next(10)}{randnum.Next(10)}{randnum.Next(10)}{randnum.Next(10)}{randnum.Next(10)}{randnum.Next(10)}')";

                FIllTeachersCommand.ExecuteNonQuery();
            }
        }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
    }
}
