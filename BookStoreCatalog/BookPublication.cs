using System.Globalization;

namespace BookStoreCatalog
{
    /// <summary>
    /// Represents a book publication.
    /// </summary>
    public class BookPublication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookPublication"/> class with the specified publisher, publication date, kind of book binding and an International Standard Book Number.
        /// </summary>
        /// <param name="authorName">A book author's name.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="published">A book publication date.</param>
        /// <param name="bookBinding">A kind of book binding.</param>
        /// <param name="isbnCode">A 10-digit International Standard Book Number (ISBN) code assigned to a book publication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="publisher"/> or <paramref>
        ///         <name>bookNumber</name>
        ///     </paramref>
        ///     or <paramref name="isbnCode"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="publisher"/> is empty or consists of white-space only characters.</exception>
        public BookPublication(string authorName, string title, string publisher, DateTime published, BookBindingKind bookBinding, string isbnCode)
            : this(new BookAuthor(authorName), title, publisher, published, bookBinding, new BookNumber(isbnCode))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookPublication"/> class with the specified publisher, publication date, kind of book binding and an International Standard Book Number.
        /// </summary>
        /// A book author's name.
        /// <name>isniCode.</name>
        /// A book title.
        /// A book publisher.
        /// A book publication date.
        /// A kind of book binding.
        /// A 10-digit International Standard Book Number (ISBN) code assigned to a book publication.
        /// <exception cref="ArgumentNullException"><paramref name="publisher"/> or <paramref>
        ///         <name>bookNumber</name>
        ///     </paramref>
        ///     or <paramref>
        ///         <name>code</name>
        ///     </paramref>
        ///     is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="publisher"/> is empty or consists of white-space only characters.</exception>
        public BookPublication(string authorName, string isniCode, string title, string publisher, DateTime published, BookBindingKind bookBinding, string isbnCode)
            : this(authorName, title, publisher, published, bookBinding, isbnCode)
        {
            this.Author = new BookAuthor(authorName, isniCode);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookPublication"/> class with the specified publisher, publication date, kind of book binding and an International Standard Book Number.
        /// </summary>
        /// <param name="author">A book author.</param>
        /// <param name="title">A book title.</param>
        /// <param name="publisher">A book publisher.</param>
        /// <param name="published">A book publication date.</param>
        /// <param name="bookBinding">A kind of book binding.</param>
        /// <param name="isbn">An International Standard Book Number assigned to a book publication.</param>
        /// <exception cref="ArgumentNullException"><paramref name="publisher"/> or <paramref name="isbn"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="publisher"/> is empty or consists of white-space only characters.</exception>
        public BookPublication(BookAuthor author, string title, string publisher, DateTime published, BookBindingKind bookBinding, BookNumber isbn)
        {
            this.Author = author ?? throw new ArgumentNullException(nameof(author));
            this.Title = title ?? throw new ArgumentNullException(nameof(title));
            this.Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            this.Published = published;
            this.BookBinding = bookBinding;
            this.Isbn = isbn ?? throw new ArgumentNullException(nameof(isbn));
        }

        /// <summary>
        /// Gets a book author.
        /// </summary>
        public BookAuthor Author { get; init; }

        /// <summary>
        /// Gets a book title.
        /// </summary>
        public string Title { get; init; }

        /// <summary>
        /// Gets a book publisher.
        /// </summary>
        public string Publisher { get; init; }

        /// <summary>
        /// Gets a book publishing date.
        /// </summary>
        public DateTime Published { get; init; }

        /// <summary>
        /// Gets a book binding kind.
        /// </summary>
        public BookBindingKind BookBinding { get; init; }

        /// <summary>
        /// Gets a book International Standard Book Number (ISBN).
        /// </summary>
        public BookNumber Isbn { get; init; }

        /// <summary>
        /// Gets a publication date as a string.
        /// </summary>
        /// <returns>A publication date as a string.</returns>
        public string GetPublicationDateString() =>
            $"{DateTimeFormatInfo.InvariantInfo.GetMonthName(this.Published.Month)}, {this.Published.Year}";

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public new string ToString() => $"{this.Title} by {this.Author.ToString()}";
    }
}
