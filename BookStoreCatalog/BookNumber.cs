namespace BookStoreCatalog
{
    /// <summary>
    /// Represents an International Standard Book Number (ISBN).
    /// </summary>
    public class BookNumber
    {
        private readonly string code;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookNumber"/> class with the specified 10-digit ISBN <paramref name="isbnCode"/>.
        /// </summary>
        /// <param name="isbnCode">A 10-digit ISBN code.</param>
        /// <exception cref="ArgumentNullException">a code argument is null.</exception>
        /// <exception cref="ArgumentException">a code argument is invalid or a code has wrong checksum.</exception>
        public BookNumber(string isbnCode)
        {
            _ = isbnCode ?? throw new ArgumentNullException(nameof(isbnCode), "can't be null.");
            this.code = ValidateCode(isbnCode) && ValidateChecksum(isbnCode) ? isbnCode : throw new ArgumentException("A code argument is invalid or a code has wrong checksum.", nameof(isbnCode));
        }

        /// <summary>
        /// Gets a 10-digit ISBN code.
        /// </summary>
        public string Code => this.code;

        /// <summary>
        /// Gets an <see cref="Uri"/> to the publication page on the isbnsearch.org website.
        /// </summary>
        /// <returns>an <see cref="Uri"/> to the publication page on the isbnsearch.org website.</returns>
        public Uri GetSearchUri() => new Uri($"https://isbnsearch.org/isbn/{this.code}");

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public new string ToString() => this.code;

        private static bool ValidateCode(string isbnCode) => !string.IsNullOrWhiteSpace(isbnCode) &&
                                                             isbnCode.Length == 10 && isbnCode.All(term =>
                                                                 char.IsDigit(term) || term == 'X');

        private static bool ValidateChecksum(string isbnCode)
        {
            int checkSum = 0;
            int j = 10;
            foreach (var term in isbnCode)
            {
                checkSum += char.IsDigit(term) ? (term - '0') * j-- : 10;
            }

            return checkSum % 11 == 0;
        }
    }
}
