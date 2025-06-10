using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Enums;
using ValueObjects;

namespace MangaLib.ConsoleApp
{
    class Program
    {
        private static List<Manga> mangas = new List<Manga>();
        private static List<Author> authors = new List<Author>();
        private static List<Chapter> chapters = new List<Chapter>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("MangaLib Console App");
                Console.WriteLine("1. Add Manga");
                Console.WriteLine("2. Add Author");
                Console.WriteLine("3. Create Chapter");
                Console.WriteLine("4. List All Manga");
                Console.WriteLine("5. List All Authors");
                Console.WriteLine("6. List Chapters for Manga");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");

                var choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddManga();
                            break;
                        case "2":
                            AddAuthor();
                            break;
                        case "3":
                            CreateChapter();
                            break;
                        case "4":
                            ListAllManga();
                            break;
                        case "5":
                            ListAllAuthors();
                            break;
                        case "6":
                            ListChaptersForManga();
                            break;
                        case "7":
                            return;
                        default:
                            Console.WriteLine("Invalid choice!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void AddManga()
        {
            Console.Write("Enter manga title: ");
            var title = Console.ReadLine();

            Console.Write("Enter description: ");
            var description = Console.ReadLine();

            Console.Write("Enter cover image URL: ");
            var coverUrl = Console.ReadLine();

            Console.Write("Enter release date (yyyy-MM-dd): ");
            var releaseDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter authors (comma separated): ");
            var authorsInput = Console.ReadLine();
            var authorsList = authorsInput.Split(',').Select(a => a.Trim()).ToList();

            Console.Write("Enter tags (comma separated): ");
            var tagsInput = Console.ReadLine();
            var tagsList = tagsInput.Split(',').Select(t => t.Trim()).ToList();

            var manga = new Manga(
                id: mangas.Count + 1,
                title: title,
                description: description,
                coverImageUrl: coverUrl,
                releaseDate: releaseDate);

            manga.SetAuthors(authorsList);
            manga.SetTags(tagsList);

            mangas.Add(manga);
            Console.WriteLine($"Manga created with ID: {manga.Id}");
        }

        static void AddAuthor()
        {
            Console.Write("Enter author name: ");
            var name = Console.ReadLine();

            Console.Write("Enter author's works (comma separated): ");
            var worksInput = Console.ReadLine();
            var worksList = worksInput.Split(',').Select(w => w.Trim()).ToList();

            var author = new Author(
                name: new AuthorName(name));

            authors.Add(author);
            Console.WriteLine($"Author created with ID: {author.Id}");
        }

        static void CreateChapter()
        {
            var manga = SelectManga();

            Console.Write("Enter chapter title: ");
            var title = Console.ReadLine();

            Console.Write("Enter chapter number: ");
            var chapterNumber = int.Parse(Console.ReadLine());

            var chapter = new Chapter(
                mangaId: manga.Id,
                title: title,
                chapterNumber: chapterNumber);

            chapters.Add(chapter);
            Console.WriteLine($"Chapter created with ID: {chapter.Id} for manga '{manga.Title}'");
        }

        static void ListAllManga()
        {
            Console.WriteLine("List of Manga:");
            foreach (var m in mangas)
            {
                Console.WriteLine($"{m.Id} - {m.Title}");
                Console.WriteLine($"  Description: {m.Description}");
                Console.WriteLine($"  Authors: {string.Join(", ", m.GetAuthors().Split('|'))}");
                Console.WriteLine($"  Tags: {string.Join(", ", m.GetTags().Split('|'))}");
                Console.WriteLine($"  Status: {m.GetCurrentStatus()}");
                Console.WriteLine($"  Release Date: {m.ReleaseDate:yyyy-MM-dd}");
                Console.WriteLine();
            }
        }

        static void ListAllAuthors()
        {
            Console.WriteLine("List of Authors:");
            foreach (var a in authors)
            {
                Console.WriteLine($"{a.Id} - {a.Name.Value}");
            }
        }

        static void ListChaptersForManga()
        {
            var manga = SelectManga();
            var mangaChapters = chapters.Where(c => c.MangaId == manga.Id).ToList();

            Console.WriteLine($"Chapters for '{manga.Title}':");
            foreach (var c in mangaChapters)
            {
                Console.WriteLine($"  {c.ChapterNumber}. {c.Title} (ID: {c.Id})");
            }
        }

        static Manga SelectManga()
        {
            ListAllManga();
            Console.Write("Enter manga ID: ");
            var id = int.Parse(Console.ReadLine());
            return mangas.FirstOrDefault(m => m.Id == id)
                ?? throw new Exception("Manga not found");
        }

        static Author SelectAuthor()
        {
            ListAllAuthors();
            Console.Write("Enter author ID: ");
            var id = int.Parse(Console.ReadLine());
            return authors.FirstOrDefault(a => a.Id == id)
                ?? throw new Exception("Author not found");
        }
    }
}