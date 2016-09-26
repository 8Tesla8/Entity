using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEntety
{
    class ProgramSimpleOperations
    {
        private static ModelDB context;

        static void Main(string[] args)
        {
            // привязка к DataGrid идет через Source у DataBase ++++++

            using (context = new ModelDB())
            {
                //context.PersonalInfos.Load(); //загрузка в память 

                ShowPersons();
                //AddPerson();
                //EditPerson();
                DeletePerson();

                ShowPersons();
            }
            Console.WriteLine("End of Program - Press Enter");
            Console.ReadKey();
        }

        static void ShowPersons()
        {
            Console.WriteLine();

            var list = context.PersonalInfos.ToList();
            foreach (var item in list)
            {
                Console.WriteLine("{0}. {1}, {2}, {3}",
                    item.Id, item.Name, item.Surname, item.Age);
            }
        }

        static void AddSomeDate()
        {
            if (context == null)
            {
                Console.Write("no data base");
                return;
            }

            context.PersonalInfos.Add(new PersonalInfo()
            {
                Id = 1,
                Name = "Yuri",
                Surname = "K",
                Age = 18
            });
            context.PersonalInfos.Add(new PersonalInfo()
            {
                Id = 2,
                Name = "Yuri2",
                Surname = "K2",
                Age = 19
            });
            int сhanges = context.SaveChanges();

            Console.WriteLine("Save {0} changes in data base", сhanges);

        }

        static void AddPerson()
        {
            Console.WriteLine();

            if (context == null)
            {
                Console.Write("no data base");
                return;
            }

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            context.PersonalInfos.Add( new PersonalInfo
            {
                Name  = name,
                Surname = surname,
                Age = age
            });
            int сhanges = context.SaveChanges();
            Console.WriteLine("Save {0} changes in data base", сhanges);
        }

        static void EditPerson()
        {
            Console.WriteLine();

            Console.Write("Enter id person for edit: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var editPerson = context.PersonalInfos.Find(id);

            if (editPerson == null)
            {
                Console.WriteLine("In date base no person with id = {0}", id);
                return;
            }
            // заполнение данными
            Console.Write("Enter name: ");
            editPerson.Name = Console.ReadLine();

            Console.Write("Enter surname: ");
            editPerson.Surname = Console.ReadLine();

            Console.Write("Enter Age: ");
            editPerson.Age = Convert.ToInt32(Console.ReadLine());

            //1 способ редактирования данных
            context.PersonalInfos.AddOrUpdate(editPerson);
            int сhanges1 = context.SaveChanges();
            Console.WriteLine("Save {0} changes in data base", сhanges1);

            //2 способ редактирования данных
            //context.Entry(editPerson).State = EntityState.Modified; //изменен
            //int сhanges2 = context.SaveChanges();
            //Console.WriteLine("Save {0} changes in data base", сhanges2);
        }

        static void DeletePerson()
        {
            Console.WriteLine();

            Console.Write("Enter id person for delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var deletePerson = context.PersonalInfos.Find(id);

            if (deletePerson == null)
            {
                Console.WriteLine("In date base no person with id = {0}", id);
                return;
            }

            //1 способ редактирования данных
            context.PersonalInfos.Remove(deletePerson);
            int сhanges1 = context.SaveChanges();
            Console.WriteLine("Save {0} changes in data base", сhanges1);

            //2 способ редактирования данных
            //context.Entry(deletePerson).State = EntityState.Deleted; //изменен
            //int сhanges2 = context.SaveChanges();
            //Console.WriteLine("Save {0} changes in data base", сhanges2);
        }
    }
}
