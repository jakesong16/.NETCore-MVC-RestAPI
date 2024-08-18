using System.Collections.Generic;
using Commander.Models;

//'Data' is our repository
namespace Commander.Data {
    public interface ICommanderRepo {
        //every time you make change via dbcontext, the data won't be changed in db unless you use SaveChanges()
        bool SaveChanges();
        //Give list of all command objects/resources
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void UpdateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}