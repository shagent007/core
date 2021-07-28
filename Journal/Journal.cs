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
            "getAll",
            "add",
            "exit"
        };

        public void Start()
        {
            string _command;
            do
            {
                _command = Ask.ItemInStringList("Введите команду", commands);
                switch (_command)
                {
                    case "getAll":
                        controller.GetAll();
                        break;
                    case "add":
                        controller.Add();
                        break;
                }
            } while (_command != "exit");
        }
    }
}
