using System.Globalization;

namespace BookStoreCatalog
{
    /// <summary>
    /// Represents a book price.
    /// </summary>
    public class BookPrice
    {
        private decimal amount;
        private string currency;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookPrice"/> class.
        /// </summary>
        public BookPrice()
            : this(0.0m, "USD")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BookPrice"/> class with specified <paramref name="amount"/> and <paramref name="currency"/>.
        /// </summary>
        /// <param name="amount">An amount of money of a book.</param>
        /// <param name="currency">A price currency.</param>
        public BookPrice(decimal amount, string currency)
        {
            ThrowExceptionIfAmountIsNotValid(amount, nameof(amount));
            ThrowExceptionIfCurrencyIsNotValid(currency, nameof(currency));
            this.amount = amount;
            this.currency = currency;
        }

        /// <summary>
        /// Gets or sets an amount of money that a book costs.
        /// </summary>
        public decimal Amount
        {
            get => this.amount;
            set
            {
                ThrowExceptionIfAmountIsNotValid(value, nameof(value));
                this.amount = value;
            }
        }

        /// <summary>
        /// Gets or sets a book price currency.
        /// </summary>
        public string Currency
        {
            get => this.currency;
            set
            {
                ThrowExceptionIfCurrencyIsNotValid(value, nameof(value));
                this.currency = value;
            }
        }

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public new string ToString() => string.Format(CultureInfo.InvariantCulture, "{0:N2} {1}", this.amount, this.currency);

        private static void ThrowExceptionIfAmountIsNotValid(decimal amount, string value) => _ = amount < 0 ? throw new ArgumentException("Amount cant be less then 0.", value) : amount;

        private static void ThrowExceptionIfCurrencyIsNotValid(string currency, string value)
        {
            _ = currency ?? throw new ArgumentNullException(value, $"Can't be empty or null.");

            if (currency.Length != 3 || currency.Any(c => !char.IsLetter(c)))
            {
                throw new ArgumentException("Invalid currency.", value);
            }
        }
    }
}
