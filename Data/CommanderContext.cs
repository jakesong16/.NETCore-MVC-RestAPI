using Microsoft.EntityFrameworkCore;
using Commander.Models;

namespace Commander.Data {
    //an instance of this class is created inside the SqlCommanderRepo class; used to query db
    public class CommanderContext : DbContext {
        //uses a constructor initializer, calls the base class constructor with parameter.
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt) {

        }
        //Creating a command model in our DB: we want to represent our Command object down to our DB as a DbSet called Commands
        //Does the mapping for our Command; if more models, need more properties.
        public DbSet<Command> Commands { get; set; }
    }
}