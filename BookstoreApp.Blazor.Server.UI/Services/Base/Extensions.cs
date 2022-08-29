namespace BookstoreApp.Blazor.Server.UI.Services.Base
{
    public static class Extensions
    {
        public static AuthorUpdateDto toAuthorUpdateDto(this AuthorDetailsDto author)
        {
            return new AuthorUpdateDto { FirstName = author.FirstName, LastName = author.LastName, Bio = author.Bio};
        }
        public static BookUpdateDto toBookUpdateDto(this BookDetailsDto book)
        {
            return new BookUpdateDto { 
                Title = book.Title, 
                Image = book.Image,
                Id = book.Id,
                Isbn = book.Isbn,
                Price = book.Price,
                Summary = book.Summary,
                Year = book.Year,
                
            };
        }
    }
}
