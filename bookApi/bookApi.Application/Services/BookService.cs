using AutoMapper;
using bookApi.Application.Dtos.Request;
using bookApi.Application.Dtos.Responses;
using bookApi.Application.Exceptions;
using bookApi.Application.Interfaces;
using bookApi.Domian.Common;
using bookApi.Domian.Enums;
using bookApi.Domian.Interfaces;
using bookApi.Domian.Models;

namespace bookApi.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this._bookRepository = bookRepository;
            this._mapper = mapper;
        }


        public async Task<BookResponseDto> Create(CreateBookDto bookDto)
        {
            var newBook = _mapper.Map<Book>(bookDto);

            var createdBook = await _bookRepository.Create(newBook, bookDto.GenreIds);

            return _mapper.Map<BookResponseDto>(createdBook);
        }

        public async Task<GenericListResponse<BookListResponseDto>> GetList(int? userId, int page, int pageSize, string? query)
        {
            var books = await _bookRepository.GetList(userId, page, pageSize, query);

            return _mapper.Map<GenericListResponse<BookListResponseDto>>(books);
        }

        public async Task<BookListResponseDto?> GetOne(int? userId, int bookId)
        {
            var book = await _bookRepository.GetOne(userId, bookId);
            if (book == null)
            {
                throw new NotFoundException("Book not found")
                {
                    ErrorCode = "003"
                };
            }

            return _mapper.Map<BookListResponseDto>(book);
        }

        public async Task<BookResponseDto> Update(int bookId, UpdateBookDto bookDto)
        {
            var currentBook = await _bookRepository.GetOne(null, bookId);

            if (currentBook == null)
            {
                throw new BadRequestException($"No book found with id {bookId}")
                {
                    ErrorCode = "005"
                };

            }
            currentBook.Book.Description = bookDto.Description;
            currentBook.Book.CoverUrl = bookDto.CoverUrl;


            var updatedBook = await _bookRepository.Update(currentBook.Book);

            return _mapper.Map<BookResponseDto>(updatedBook);
        }

        public async Task<BookListResponseDto> ShelveBook(int? userId, int bookId)
        {
            var isShelved = await _bookRepository.GetOne(userId, bookId);

            if (isShelved == null)
            {
                throw new BadRequestException($"Book with id {bookId} does not exist")
                {
                    ErrorCode = "006"
                };
            }
            if (isShelved.UserBook != null)
            {
                throw new BadRequestException("Book is already shelved")
                {
                    ErrorCode = "007"
                };
            }
            var userBook = new UserBook
            {
                UserId = (int)userId!,
                BookId = bookId,
                ReadingStatusId = (int)ReadingStatusEnum.WantToRead //default initial status
            };
            var shelvedBook = await _bookRepository.Shelve(userBook);
            return _mapper.Map<BookListResponseDto>(shelvedBook);


        }

        public async Task<UserBookResponseDto> UpserUserBook(int userId, int bookId, Action<UserBook> updateField)
        {
            var bookResponse = await _bookRepository.GetOne(userId, bookId);

            if (bookResponse == null)
            {
                throw new BadRequestException($"Book of id {bookId} does not exist")
                {
                    ErrorCode = "009"
                };
            }
            if (bookResponse.UserBook == null)
            {
                bookResponse.UserBook = new UserBook
                {
                    UserId = userId,
                    BookId = bookId,
                    ReadingStatusId = (int)ReadingStatusEnum.WantToRead
                };

                await _bookRepository.Shelve(bookResponse.UserBook);

            }
            //Apply the specific updates from the delegate

            updateField(bookResponse.UserBook);

            var updateUserBook = await _bookRepository.UpdateUserBook(bookResponse.UserBook);

            return _mapper.Map<UserBookResponseDto>(updateUserBook);

        }

        public async Task<UserBookResponseDto> updateReadingStatus(int userId, int bookId, UpdateReadingStatusDto updateReadingStatusDto)
        {
            return await UpserUserBook(userId, bookId, userbook =>
            {
                userbook.ReadingStatusId = (int)updateReadingStatusDto.Status;
                if (userbook.UpdatedAt.Kind != DateTimeKind.Utc)
                {
                    userbook.UpdatedAt = userbook.UpdatedAt.ToUniversalTime();
                }
            });
        }

        public async Task<UserBookResponseDto> RateBook(int userId, int bookId, RateBookDto rateBookDto)
        {
            //permite a un usuario calificar un libro y se asegura de que el estado de lectura pase a Read.
            return await UpserUserBook(userId, bookId, userbook =>
            {
                userbook.Rating = rateBookDto.Rating;
                userbook.ReadingStatusId = (int)ReadingStatusEnum.Read;
                if (userbook.UpdatedAt.Kind != DateTimeKind.Utc)
                {
                    userbook.UpdatedAt = userbook.UpdatedAt.ToUniversalTime();
                }
            });
        }
        public Task<bool> Delete(int bookId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> RemoveFromShelf(int userId, int bookId)
        {
            var bookResponse = await _bookRepository.GetOne(userId, bookId);
            if (bookResponse == null)
            {
                throw new BadRequestException($"Book of id {bookId} does not exist")
                {
                    ErrorCode = "008"
                };
            }

            if (bookResponse.UserBook == null)
            {
                throw new BadRequestException($"Bad request")
                {
                    ErrorCode = "005"
                };

            }
            await _bookRepository.RemoveFromShelf(bookResponse.UserBook);
            return true;
        }
        //estanteria de un usuario
        public async Task<GenericListResponse<BookListResponseDto>> GetUserShelf(int userId, int page, int pageSize)
        {
            var books = await _bookRepository.GetUserShelf(userId, page, pageSize);


            return _mapper.Map<GenericListResponse<BookListResponseDto>>(books);
        }

    }
}
