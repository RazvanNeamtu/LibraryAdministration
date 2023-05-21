namespace LibraryAdministration.API.ViewModels
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public List<Author> Authors { get; set; }
    }
}
