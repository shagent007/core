using Journal.Controllers;
using System;
using System.Collections.Generic;

namespace Journal
{
    public class Journal
    {
        private ChildrenController controller = new ChildrenController();
        private List<string> commands = new List<string>() 
        {
            "find",
            "add",
            "exit"
        };

        public void Start()
        {
            string _command;
            do
            {
                _command = Ask.ItemInStringList("Введите команду (find/add/exit): ", commands);
                switch (_command)
                {
                    case "find":
                        controller.Find();
                        break;
                    case "add":
                        controller.Add();
                        break;
                }
            } while (_command != "exit");
        }
    }
}
