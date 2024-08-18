using Microsoft.AspNetCore.Mvc;
using Commander.Models;
using Commander.Data;
using System.Collections.Generic;
using AutoMapper;
using Commander.DTOs;
using Azure;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.Controllers { 

        
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase {

        //declaring interface repo
        //readonly = allows variable to be calculated at runtime | const = must have value at compile time
        //_ (underscore) indicates private (naming convention
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;
        //Constructor: dependency is injected into 'repository' variable
        //Also: injects an instance of AutoMapper object
        public CommandsController(ICommanderRepo repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }

        //private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        //above -> We don't need this anymore since we have the constructor (DI)
        
        //GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDTO>> GetAllCommands() {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDTO>>(commandItems));
        }

        //GET api/commands/{id}
        [HttpGet("{id}", Name ="GetCommandById")]
        public ActionResult <CommandReadDTO> GetCommandById(int id) {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem != null) {
                return Ok(_mapper.Map<CommandReadDTO>(commandItem));
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDTO> CreateCommand(CommandCreateDTO c) {
            var commandModel = _mapper.Map<Command>(c); //mapping from commandCreateDto to Command obj; returns mapped Command obj
            _repository.CreateCommand(commandModel); //create the model in db context
            _repository.SaveChanges(); //save changes so that the object is created in actual db

            //return a read dto instead
            var commandReadDTO = _mapper.Map<CommandReadDTO>(commandModel);

            //should also be sending back URI + HTTP 201 (REST principle)
            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDTO.Id}, commandReadDTO);
            //return Ok(commandReadDto);  --> returns 200
        }

        //PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDTO c) {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) {
                return NotFound();
            }

            _mapper.Map(c, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
        
        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDTO> patchDoc) {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);
            if (!TryValidateModel(commandToPatch)) {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id) {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if (commandModelFromRepo == null) {
                return NotFound();
            }
            _repository.DeleteCommand(commandModelFromRepo);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}