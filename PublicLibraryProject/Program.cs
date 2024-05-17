using Microsoft.EntityFrameworkCore.Diagnostics;
using PublicLibraryApp.Data;
using PublicLibraryApp.Entities;
using PublicLibraryApp.Repositories;
using PublicLibraryApp.Repositories.Extensions;
using System.Text;
//Console.OutputEncoding = Encoding.UTF8;
//Console.InputEncoding = Encoding.Unicode;

var bookRepository = new SqlRepository<Book>(new PublicLibraryAppDbContext());
var movieRepository = new SqlRepository<Movie>(new PublicLibraryAppDbContext());
var boardGameRepository = new SqlRepository<BoardGame>(new PublicLibraryAppDbContext());
AddBooks(bookRepository);
AddMovies(movieRepository);
AddBoardGames(boardGameRepository);
const string consoleWriteMainMenu = "1 - Wyświetl  |  2 - Dodaj  |  3 - Usuń  |  q - Wyjdź)";
const string separateLine = "---------------------------------------------------------------------";
static void AddBooks(IRepository<Book> bookRepository)
{
    var books = new[]
    {
    new Book { Title = "Potęga podświadomości", Author = "Joseph Murphy", PublicationYear = "1985" },
    new Book { Title = "Opus magnum C++", Author = "Jerzy Grębosz", PublicationYear = "2015" },
    new Book { Title = "Filozofia dla zabieganych", Author = "Johny Johnson", PublicationYear = "2021" }
    };

    bookRepository.AddBatch(books);
    bookRepository.Save();
}

static void AddMovies(IRepository<Movie> movieRepository)
{
    var movies = new[]
    {
    new Movie { Title = "Forest Gump", Director = "Martin Scorsese", ReleaseYear = "1990" },
    new Movie { Title = "Matrix", Director = "Steven Spielberg", ReleaseYear = "2000" }
    };

    movieRepository.AddBatch(movies);
    movieRepository.Save();
}

static void AddBoardGames(IRepository<BoardGame> boardGameRepository)
{
    var boardGames = new[]
    {
        new BoardGame { Name = "Monopoly", Type = "Economic", ReleaseYear = "1985" },
        new BoardGame { Name = "5 seconds", Type = "Sociable", ReleaseYear = "2020" }
    };

    boardGameRepository.AddBatch(boardGames);
    boardGameRepository.Save();
}


Console.WriteLine("- - - - - - - - - - - Witaj w Bibliteque App - - - - - - - - - - - -");
Console.WriteLine("--------------------------------------------------------------------");
Console.WriteLine("Wybierz akcję dla zasobów:");
Console.WriteLine(consoleWriteMainMenu);
Console.WriteLine("--------------------------------------------------------------------");
while (true)
{
    var input = Console.ReadLine();
    if (input == "q" || input == "Q")
    {
        break;
    }
    try
    {
        switch (input)
        {
            case "1":
                Console.WriteLine("Pokaż: 0 - wszystko | 1 - książki | 2 - filmy | 3 - gry planszowe | 4 - wróć ");
                var chooseToDisplay = Console.ReadLine();
                switch (chooseToDisplay)
                {
                    case "0":
                        Console.WriteLine("Books:");
                        WriteRepoToConsole(bookRepository);
                        Console.WriteLine("Movies:");
                        WriteRepoToConsole(movieRepository);
                        Console.WriteLine("Board games:");
                        WriteRepoToConsole(boardGameRepository);
                        Console.WriteLine(separateLine);
                        Console.WriteLine(consoleWriteMainMenu);
                        break;
                    case "1":
                        WriteRepoToConsole(bookRepository);
                        Console.WriteLine(separateLine);
                        Console.WriteLine(consoleWriteMainMenu);
                        break;
                    case "2":
                        WriteRepoToConsole(movieRepository);
                        Console.WriteLine(separateLine);
                        Console.WriteLine(consoleWriteMainMenu);
                        break;
                    case "3":
                        WriteRepoToConsole(boardGameRepository);
                        Console.WriteLine(separateLine);
                        Console.WriteLine(consoleWriteMainMenu);
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór!");
                        Console.WriteLine(separateLine);
                        Console.WriteLine(consoleWriteMainMenu);
                        continue;
                }
                break;
            case "2":
                Console.WriteLine("Co dodajesz? 1 - książkę | 2 - film | 3 - grę planszową?");
                var chooseToAdd = Console.ReadLine();
                switch (chooseToAdd)
                {
                    case "1":
                        Console.WriteLine("Podaj tytuł: ");
                        var addBookTitle = Console.ReadLine();
                        Console.WriteLine("Podaj autora: ");
                        var addAuthor = Console.ReadLine();
                        Console.WriteLine("Podaj rok wydania (YYYY): ");
                        var addPublicationYear = Console.ReadLine();
                        Console.WriteLine($"Potwierdź dane:  {addBookTitle} / {addAuthor} / {addPublicationYear} ? T - tak / N - nie");
                        var confirmBookData = Console.ReadLine();
                        if (confirmBookData == "t" || confirmBookData == "T")
                        {
                            Book newBook = new Book { Title = addBookTitle, Author = addAuthor, PublicationYear = addPublicationYear };
                            bookRepository.Add(newBook);
                            bookRepository.ItemAdded += BookRepositoryOnItemAdded;
                            bookRepository.Save();
                            Console.WriteLine("Zapisano");
                            // Tutaj event o dodaniu książki do repo
                            // Wyjście do menu głównego?
                        }
                        else
                        {
                            Console.WriteLine("Pozycja nie została dodana.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Podaj tytuł: ");
                        var addMovieTitle = Console.ReadLine();
                        Console.WriteLine("Podaj reżysera: ");
                        var addDirector = Console.ReadLine();
                        Console.WriteLine("Podaj rok wydania (YYYY): ");
                        var addReleaseYear = Console.ReadLine();
                        Console.WriteLine($"Potwierdź dane:  {addMovieTitle} / {addDirector} / {addReleaseYear} ? T - tak / N - nie");
                        var confirmMovieData = Console.ReadLine();
                        if (confirmMovieData == "t" || confirmMovieData == "T")
                        {
                            Movie newMovie = new Movie { Title = addMovieTitle, Director = addDirector, ReleaseYear = addReleaseYear };
                            movieRepository.Add(newMovie);
                            movieRepository.Save();
                            Console.WriteLine("Zapisano");
                            // Tutaj event o dodaniu książki do repo
                            // Wyjście do menu głównego?
                        }
                        else
                        {
                            Console.WriteLine("Pozycja nie została dodana.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Podaj tytuł: ");
                        var addBGameName = Console.ReadLine();
                        Console.WriteLine("Podaj rok wydania (YYYY): ");
                        var addBGameReleaseYear = Console.ReadLine();
                        Console.WriteLine($"Potwierdź dane:  {addBGameName} / {addBGameReleaseYear} ? T - tak / N - nie");
                        var confirmBGameData = Console.ReadLine();
                        if (confirmBGameData == "t" || confirmBGameData == "T")
                        {
                            BoardGame newBoardGame = new BoardGame { Name = addBGameName, ReleaseYear = addBGameReleaseYear };
                            boardGameRepository.Add(newBoardGame);
                            boardGameRepository.Save();
                            Console.WriteLine("Zapisano");
                            // Tutaj event o dodaniu książki do repo
                            // Wyjście do menu głównego?
                        }
                        else
                        {
                            Console.WriteLine("Pozycja nie została dodana.");
                        }
                        break;
                }
                break;
            case "3":
                Console.WriteLine("Co chcesz usunąć? 1 - książkę | 2 - film | 3 - grę planszową?");
                var chooseToDelete = Console.ReadLine();
                switch (chooseToDelete)
                {
                    case "1":
                        Console.WriteLine("Podaj Id książki do usunięcia: ");
                        var bookIdToDelete = Console.ReadLine();
                        if (int.TryParse(bookIdToDelete, out int bookIdToInt))
                        {
                            var bookItem = bookRepository.GetById(bookIdToInt);
                            Console.Write("Czy na pewno usunąć pozycję: ");
                            WriteItemToConsole(bookRepository, bookIdToInt);
                            Console.WriteLine("Wybierz: T - tak / N - nie");
                            var confirmDeleting = Console.ReadLine();
                            if (confirmDeleting == "t" || confirmDeleting == "T")
                            {
                                bookRepository.Remove(bookItem);
                                bookRepository.Save();
                                Console.WriteLine("Usunięto wybraną pozycję.");
                            }
                            else
                            {
                                Console.WriteLine("Nie usunięto wybranej pozycji.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Niepoprana wartość. Nic nie usunięto.");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Podaj Id filmu do usunięcia: ");
                        var movieIdToDelete = Console.ReadLine();
                        if (int.TryParse(movieIdToDelete, out int movieIdToInt))
                        {
                            var movieItem = movieRepository.GetById(movieIdToInt);
                            Console.Write("Czy na pewno usunąć pozycję: ");
                            WriteItemToConsole(movieRepository, movieIdToInt);
                            Console.WriteLine("Wybierz: T - tak / N - nie");
                            var confirmDeleting = Console.ReadLine();
                            if (confirmDeleting == "t" || confirmDeleting == "T")
                            {
                                movieRepository.Remove(movieItem);
                                movieRepository.Save();
                                Console.WriteLine("Usunięto wybraną pozycję.");
                            }
                            else
                            {
                                Console.WriteLine("Nie usunięto wybranej pozycji.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Niepoprana wartość. Nic nie usunięto.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Podaj Id filmu do usunięcia: ");
                        var boardGameIdToDelete = Console.ReadLine();

                        if (int.TryParse(boardGameIdToDelete, out int boardGameIdToInt))
                        {
                            var boardGameItem = boardGameRepository.GetById(boardGameIdToInt);
                            Console.Write("Czy na pewno usunąć pozycję: ");
                            WriteItemToConsole(boardGameRepository, boardGameIdToInt);
                            Console.WriteLine("Wybierz: T - tak / N - nie");
                            var confirmDeleting = Console.ReadLine();
                            if (confirmDeleting == "t" || confirmDeleting == "T")
                            {
                                boardGameRepository.Remove(boardGameItem);
                                boardGameRepository.Save();
                                Console.WriteLine("Usunięto wybraną pozycję.");
                            }
                            else
                            {
                                Console.WriteLine("Nie usunięto wybranej pozycji.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Niepoprana wartość. Nic nie usunięto.");
                        }
                        break;
                }
                break;
            default:
                break;
        }
    }
    catch (Exception)
    {
        Console.WriteLine($"Exception catched: x");
    }
}

void BookRepositoryOnItemAdded(object? sender, Book e)
{
    //implementacja dodania nowego wpisu do pliku repozytorium Book
    throw new NotImplementedException();
}

static void WriteRepoToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}

static void WriteItemToConsole(IReadRepository<IEntity> repository, int id)
{
    var itemId = id;
    var chosenItem = repository.GetById(itemId);
    Console.WriteLine(chosenItem);
}