using AutoMapper;
using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Application.Exceptions;
using bookApi.Application.Interfaces;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;
using System.Linq.Expressions;

namespace bookApi.Application.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository genreRepository, IMapper mapper)
        {
            this._genreRepository = genreRepository;
            this._mapper = mapper;
        }
        public async Task<GenreResponseDto> Create(CreateGenreDto genreDto)
        {
            var genreExists = await _genreRepository.GetOne(g => g.Name == genreDto.Name);

            if (genreExists != null)
            {
                throw new BadRequestException($"Genre with name '{genreDto.Name}' already exists")
                {
                    ErrorCode = "006"
                };
            }
            var newGenre = new Genre
            {
                Name = genreDto.Name
            };

            var genre = await _genreRepository.Create(newGenre);

            return _mapper.Map<GenreResponseDto>(genre);
        }

        public async Task<IEnumerable<GenreResponseDto>> GetAll()
        {
            var genres = await _genreRepository.GetAll();
            return _mapper.Map<IEnumerable<GenreResponseDto>>(genres);
        }

        public async Task<GenreResponseDto?> GetOne(int genreId)
        {
            var genre = await _genreRepository.GetOne(genreId);

            if (genre == null)
            {
                throw new NotFoundException($"No genre found with id of {genreId}")
                {
                    ErrorCode = "004"
                };
            }
            return _mapper.Map<GenreResponseDto>(genre);
        }

        public async Task<Genre> GetOne(Expression<Func<Genre, bool>> predicate)
        {
            var genre = await _genreRepository.GetOne(predicate);

            if (genre == null)
            {
                throw new NotFoundException()
                {
                    ErrorCode = "004"
                };
            }

            return genre;
        }
    }
}
