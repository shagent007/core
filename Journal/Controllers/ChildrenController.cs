using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Journal.Controllers
{
    public class ChildrenController
    {
        public List<Children> childrens = new List<Children>();
        public void Add()
        {
            Children _children = new Children();
            _children.Id = Guid.NewGuid();
            _children.FirstName = Ask.String("Имя: ","Имя не может быть пустым!");
            _children.LastName = Ask.String("Фамилия: ", "Фамилия не может быть пустым!");
            _children.Patronimyc = Ask.String("Отчество: ", "", false);
            _children.Age = Ask.Int("Введите возраст: ");
            childrens.Add(_children);
        }

        public void Update(Guid id)
        {
            bool _found = childrens.Exists(item => item.Id == id);
            if (!_found)
            {
                Console.WriteLine("Ученик не найден");
                return;
            }
            
            Children _children = childrens.Find(item => item.Id == id);
            _children.FirstName = Ask.String("Имя: ", "Имя не может быть пустым!");
            _children.LastName = Ask.String("Фамилия: ", "Фамилия не может быть пустым!");
            _children.Patronimyc = Ask.String("Отчество: ", "", false);
            _children.Age = Ask.Int("Введите возраст: ");
        }

        public void GetAll()
        {
            foreach (Children children in childrens)
            {
                children.PrintInfo();
            }
        }
    }
}
