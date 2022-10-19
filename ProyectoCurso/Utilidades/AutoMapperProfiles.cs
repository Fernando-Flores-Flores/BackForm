using AutoMapper;
using ProyectoCurso.Controllers.Entidades;
using ProyectoCurso.Dtos;
using ProyectoCurso.Dtos.DtoResponse;

namespace ProyectoCurso.Utilidades
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            //usando autoapper
            CreateMap<AutorCreacionDTO, Autor>();
            CreateMap<Autor, AutorResponseDTO>();

            CreateMap<PersonaCreacionDto, Personas>();
            CreateMap<Personas, PersonaResponseDto>();

            CreateMap<LibroCreacionDTO, Libro>();
            CreateMap<Libro, LibroResponseDTO>();
        
        }

    }
}
