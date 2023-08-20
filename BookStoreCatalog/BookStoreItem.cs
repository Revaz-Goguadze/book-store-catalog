using System.Globalization;

namespace BookStoreCatalog
{
    /// <summary>
    /// Represents the an item in a book store.
    /// </summary>
    public class BookStoreItem
    {
        private BookPublication publication;
        private BookPrice price;
        private int amount;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="authorName"/>, <paramref name="isniCode"/>, <paramref name="title"/>, <paramref name="publisher"/>, <paramref name="published"/>, <paramref name="bookBinding"/>, <paramref name="bookBinding"/>, <paramref name="isbn"/>, <paramref name="priceAmount"/>, <paramref name="priceCurrency"/> and <paramref name="amount"/>.
        /// </summary>
        public BookStoreItem(string authorName, string isniCode, string title, string publisher, DateTime published, BookBindingKind bookBinding, string isbn, decimal priceAmount, string priceCurrency, int amount)
            : this(new BookPublication(authorName, isniCode, title, publisher, published, bookBinding, isbn), new BookPrice(priceAmount, priceCurrency), amount)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookStoreItem"/> class with the specified <paramref name="publication"/>, <paramref name="price"/> and <paramref name="amount"/>.
        /// </summary>
        public BookStoreItem(BookPublication publication, BookPrice price, int amount)
        {
            this.price = price ?? throw new ArgumentNullException(nameof(price));
            this.publication = publication ?? throw new ArgumentNullException(nameof(publication));
            this.amount = amount < 0 ? throw new ArgumentOutOfRangeException(nameof(amount), "The amount of books in the store's stock cannot be negative.") : amount;
        }

        /// <summary>
        /// Gets or sets a <see cref="BookPublication"/>.
        /// </summary>
        public BookPublication Publication
        {
            get => this.publication;
            set => this.publication = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets a <see cref="BookPrice"/>.
        /// </summary>
        public BookPrice Price
        {
            get => this.price;
            set => this.price = value ?? throw new ArgumentNullException(nameof(value));
        }

        /// <summary>
        /// Gets or sets an amount of books in the store's stock.
        /// </summary>
        public int Amount
        {
            get => this.amount;
            set => this.amount = value < 0 ? throw new ArgumentOutOfRangeException(nameof(value)) : value;
        }

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public new string ToString()
        {
            string checkedIsni = $"{this.Publication.ToString()}, {this.Price.ToString()}, {this.Amount}";
            return this.Price.ToString().Contains(',') ? checkedIsni.Replace($"{this.Price.ToString()}", $"\"{this.Price.ToString()}\"") : checkedIsni;
        }
    }
}
