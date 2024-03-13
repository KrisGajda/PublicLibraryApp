using PublicLibraryApp.Entities;
using PublicLibraryApp.Repositories;
using PublicLibraryApp.Data;

var bookRepository = new SqlRepository<Book>(new PublicLibraryAppDbContext());
var movieRepository = new SqlRepository<Movie>(new PublicLibraryAppDbContext());
var boardGameRepository = new SqlRepository<BoardGame>(new PublicLibraryAppDbContext());

AddBooks(bookRepository);
AddMovies(movieRepository);
AddBoardGames(boardGameRepository);
WriteAllToConsole(bookRepository);
WriteAllToConsole(movieRepository);
WriteAllToConsole(boardGameRepository);

static void AddBooks(IRepository<Book> bookRepository)
{
    bookRepository.Add(new Book {Title = "Potęga podświadomości", Author = "Joseph Murphy", PublicationYear = 1985, ReleaseType = "Paper" });
    bookRepository.Add(new Book {Title = "Opus magnum C++", Author = "Jerzy Grębosz", PublicationYear = 2015, ReleaseType = "E-book" });
    bookRepository.Add(new Book {Title = "Filozofia dla zabieganych", Author = "Johny Johnson", PublicationYear = 2021, ReleaseType = "Audiobook" });
    bookRepository.Save();
}

static void AddMovies(IWriteRepository<Movie> movieRepository)
{
    movieRepository.Add(new Movie { Title = "Forest Gump", Director = "Martin Scorsese", ReleaseYear = 1990 });
    movieRepository.Add(new Movie { Title = "Matrix", Director = "Steven Spielberg", ReleaseYear = 2000 });
    movieRepository.Save();
}

static void AddBoardGames(IWriteRepository<BoardGame> boardGamesRepository)
{
    boardGamesRepository.Add(new BoardGame { Name = "Monopoly", ReleaseYear = 1985 });
    boardGamesRepository.Add(new BoardGame { Name = "5 seconds", ReleaseYear = 2020 });
    boardGamesRepository.Save();
}

static void WriteAllToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}