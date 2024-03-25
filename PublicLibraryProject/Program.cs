using PublicLibraryApp.Entities;
using PublicLibraryApp.Repositories;
using PublicLibraryApp.Data;
using PublicLibraryApp.Repositories.Extensions;
using System.IO;

var bookRepository = new SqlRepository<Book>(new PublicLibraryAppDbContext());
var movieRepository = new SqlRepository<Movie>(new PublicLibraryAppDbContext());
var boardGameRepository = new SqlRepository<BoardGame>(new PublicLibraryAppDbContext());
AddBooks(bookRepository);
AddMovies(movieRepository);
AddBoardGames(boardGameRepository);
const string consoleWriteMainMenu = "1 - Wyświetl  |  2 - Dodaj  |  3 - Usuń  |  4 - Edytuj  |  q - Wyjdź)";
const string separateLine = "---------------------------------------------------------------------";
static void AddBooks(IRepository<Book> bookRepository)
{
    var books = new[]
    {
    new Book { Title = "Potęga podświadomości", Author = "Joseph Murphy", PublicationYear = 1985, ReleaseType = "Paper" },
    new Book { Title = "Opus magnum C++", Author = "Jerzy Grębosz", PublicationYear = 2015, ReleaseType = "E-book" },
    new Book { Title = "Filozofia dla zabieganych", Author = "Johny Johnson", PublicationYear = 2021, ReleaseType = "Audiobook" }
    };

    bookRepository.AddBatch(books);
    bookRepository.Save();
}

static void AddMovies(IRepository<Movie> movieRepository)
{
    var movies = new[]
    {
    new Movie { Title = "Forest Gump", Director = "Martin Scorsese", ReleaseYear = 1990 },
    new Movie { Title = "Matrix", Director = "Steven Spielberg", ReleaseYear = 2000 }
    };

    movieRepository.AddBatch(movies);
    movieRepository.Save();
}

static void AddBoardGames(IRepository<BoardGame> boardGameRepository)
{
    var boardGames = new[]
    {
        new BoardGame { Name = "Monopoly", ReleaseYear = 1985 },
        new BoardGame { Name = "5 seconds", ReleaseYear = 2020 }
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
                        WriteToConsole(bookRepository);
                        Console.WriteLine("Movies:");
                        WriteToConsole(movieRepository);
                        Console.WriteLine("Board games:");
                        WriteToConsole(boardGameRepository);
                        Console.WriteLine(separateLine);
                        Console.WriteLine(consoleWriteMainMenu);
                        break;
                    case "1":
                        WriteToConsole(bookRepository);
                        Console.WriteLine(separateLine);
                        Console.WriteLine(consoleWriteMainMenu);
                        break;
                    case "2":
                        WriteToConsole(movieRepository);
                        Console.WriteLine(separateLine);
                        Console.WriteLine(consoleWriteMainMenu);
                        break;
                    case "3":
                        WriteToConsole(boardGameRepository);
                        Console.WriteLine(separateLine);
                        Console.WriteLine(consoleWriteMainMenu);
                        break;
                    case "4":
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
                break;
            case "3":
                break;
            case "4":
                break;
            default:
                break;
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine($"Exception catched: {ex.Message}");
    }
}



// 1. Wyświetl zasoby
//  1. Książki - 0 (wszystkie), numer Id - konkretny wybór
//  2. Filmy
//  3. Gry planszowe
//  5. Wróć do głównego menu
// 2. Dodaj pozycję
//  1. Dodaj książkę - Title, Author, Publication year, Release type
//  2. Dodaj film - Title, Director, Relese year
//  3. Dodaj grę planszową - Name, Release year
//  4. Zapisz i wyjdź
//  5. Wyjdź bez zapisu
// 3. Usuń pozycję
//  1. Usuń książkę - podaj Id
//  2. Usuń film - podaj Id
//  3. Usuń grę planszową - podaj Id
//  4. Zapisz i wyjdź
//  5. Wyjdź bez zapisu
// 4. Edytuj pozycję
//  1. Edytuj książkę - podaj Id
//  2. Edytuj film - podaj Id
//  3. Edytuj grę planszową - podaj Id
//  4. Zapisz i wyjdź
//  5. Wyjdź bez zapisu
// q - wyjdź z programu





WriteToConsole(bookRepository);
WriteToConsole(movieRepository);
WriteToConsole(boardGameRepository);







static void WriteToConsole(IReadRepository<IEntity> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}