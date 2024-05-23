using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        LookCommand _lookCommand = new LookCommand();
        MoveCommand _moveCommand = new MoveCommand();
        PickupCommand _pickupCommand = new PickupCommand();
        DropCommand _dropCommand = new DropCommand();

        public CommandProcessor()
        {
        }  

        public string ExecuteCommand(Player p, string command)
        {
            // Trim trailing spaces from the command
            command = command.TrimEnd();
            // Split the command into an array of words contained within the command
            string[] convertedCommand = command.Split(' ');

            if (_lookCommand.AreYou(convertedCommand[0]))
            {
                return _lookCommand.Execute(p, convertedCommand);
            }
            else if (_moveCommand.AreYou(convertedCommand[0]))
            {
                return _moveCommand.Execute(p, convertedCommand);
            }
            else if (_pickupCommand.AreYou(convertedCommand[0]))
            {
                return _pickupCommand.Execute(p, convertedCommand);
            }
            else if (_dropCommand.AreYou(convertedCommand[0]))
            {
                return _dropCommand.Execute(p, convertedCommand);
            }
            else
            {
                return "I don't know how to " + convertedCommand[0];
            }
        }
    }
}
