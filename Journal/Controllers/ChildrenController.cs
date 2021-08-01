using System;
using System.Collections.Generic;
using System.Linq;

namespace Journal.Controllers
{
    public class ChildrenController
    {
        public List<Children> childrens = new List<Children>();
        public void Add()
        {
            Children _children = new Children();
            _children.Id = Convert.ToString(Guid.NewGuid());
            _children.FirstName = Ask.String("Имя: ","Имя не может быть пустым!");
            _children.LastName = Ask.String("Фамилия: ", "Фамилия не может быть пустым!");
            _children.Patronimyc = Ask.String("Отчество: ", "", false);
            _children.Age = Ask.Int("Введите возраст: ");
            childrens.Add(_children);
        }

       

        public void Find()
        {
            List<string> _searchType = new List<string>()
            {
                "all",
                "many",
                "one",
            };

            List<Children> _childrens;

            string _searchTypeAnswer = Ask.ItemInStringList("Введите тип поиска (all/many/one): ", _searchType);

            if(_searchTypeAnswer == "all")
            {
                _childrens = childrens;
            }
            else
            {
                string _searchText = Ask.String("Введите строку поиска", "");

                _childrens = _searchTypeAnswer == "many"
                    ? findMany(_searchText)
                    : findOne(_searchText);


                if (_childrens.Count == 0)
                {
                    Console.WriteLine($"По запросу { _searchText } не чего не найдено");
                    return;
                }

                Console.WriteLine($"По запросу { _searchText } найдено {_childrens.Count} учеников");
            }
               


            List<string> _actionType = new List<string>()
            {
                "print",
                "update",
                "delete",
            };

            string _actionAnswer = Ask.ItemInStringList("Что вы хотите с ними сделать? (print/update/delete)", _actionType);

            switch (_actionAnswer)
            {
                case "update":
                    foreach (Children children in _childrens)
                    {
                        Update(children.Id);
                    }
                    break;
                case "delete":
                    foreach (Children children in _childrens)
                    {
                        Delete(children.Id);
                    }
                    break;
                default:
                    foreach (Children children in _childrens)
                    {
                        children.PrintInfo();
                    }
                    break;
            };    
        }

        private void Delete(string id)
        {
            Children _children = childrens.SingleOrDefault(r => r.Id == id);
            if (_children == null)
            {
                Console.WriteLine("Ученик не найден");
                return;
            }

            childrens.Remove(_children);
        }

        private void Update(string id)
        {
            Children _children = childrens.SingleOrDefault(r => r.Id == id);
            if (_children == null)
            {
                Console.WriteLine("Ученик не найден");
                return;
            }
            Console.Write ($"Новые данные для ученика: ") ;
            _children.PrintInfo();


            _children.FirstName = Ask.String("Имя: ", "Имя не может быть пустым!");
            _children.LastName = Ask.String("Фамилия: ", "Фамилия не может быть пустым!");
            _children.Patronimyc = Ask.String("Отчество: ", "", false);
            _children.Age = Ask.Int("Введите возраст: ");
        }

        private List<Children> findMany(string searchText)
        {
            bool _isDefined = isExist(searchText);
            if (!_isDefined)
            {
                return new List<Children>();
            }
            int.TryParse(searchText, out int _age);
            return childrens.FindAll(x => 
                (x.Id == searchText) || 
                (x.LastName == searchText) || 
                (x.FirstName == searchText) || 
                (x.Patronimyc == searchText) ||
                (x.FullName == searchText) ||
                (x.Age == _age)
            );
        }

        private bool isExist(string searchText)
        {
            int.TryParse(searchText, out int _age);
            return childrens.Exists(x =>
                (x.Id == searchText) ||
                (x.LastName == searchText) ||
                (x.FirstName == searchText) ||
                (x.Patronimyc == searchText) ||
                (x.FullName == searchText) ||
                (x.Age == _age)
            );
        }

        private List<Children> findOne(string searchText)
        {
            bool _isDefined = isExist(searchText);
            if (!_isDefined)
            {
                return new List<Children>();
            }
            int.TryParse(searchText, out int _age);
            Children _children = childrens.Find(x =>
                (x.Id == searchText) ||
                (x.LastName == searchText) ||
                (x.FirstName == searchText) ||
                (x.Patronimyc == searchText) ||
                (x.FullName == searchText) ||
                (x.Age == _age)
            );

            return new List<Children>()
            {
                _children
            };
        }
    }
}
