using AutoMapper;
using Commander.DTOs;
using Commander.Models; 

namespace Commander.Profiles {
    //map our Command model to our Dtos
    //inherit base class Profile from AutoMapper namespace
    public class CommandsProfile : Profile {
        public CommandsProfile() {
            //Source -> Target using the automapper namespace
            //automapper: maps from Command to ReadDto (GET)
            CreateMap<Command, CommandReadDTO>();
            //mapping the created dto to an actual command obj (POST)
            CreateMap<CommandCreateDTO, Command>();
            //mapping for PUT
            CreateMap<CommandUpdateDTO, Command>();
            //mapping for PATCH
            CreateMap<Command, CommandUpdateDTO>();
        }
    }
}