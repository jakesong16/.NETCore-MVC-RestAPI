using System.Collections.Generic;
using Commander.Models;
using System.Linq;
using System;


namespace Commander.Data {
    public class SqlCommanderRepo : ICommanderRepo {
        //instance of DB context class
        private readonly CommanderContext _context;
        //Constructor injection: our dependency injection system will populate this 'context' variable with db data
        public SqlCommanderRepo(CommanderContext context) {
            _context = context;
        }
        //adds a command obj to our _context db, saving is needed afterwards
        public void CreateCommand(Command cmd)
        {
            if (cmd == null) {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }
        ////DELETE endpoint (no need DTO). Remove selected command model
        public void DeleteCommand(Command cmd)
        {
            if (cmd == null) {
                throw new ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<Command> GetAllCommands() {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id) {
            return _context.Commands.FirstOrDefault(p => p.Id == id); //FirstOrDefault = LINQ command. Returns first id that matches
        }
        //every time you make change via dbcontext, the data won't be changed in db unless you use SaveChanges()
        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //PUT Endpoint. Nothing!
        }
    }
}