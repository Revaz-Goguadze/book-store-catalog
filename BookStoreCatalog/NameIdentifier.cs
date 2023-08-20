namespace BookStoreCatalog
{
    /// <summary>
    /// Represents an International Standard Name Identifier (ISNI).
    /// </summary>
    public class NameIdentifier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameIdentifier"/> class with the specified 16-digit ISNI <paramref name="isniCode"/>.
        /// </summary>
        /// <param name="isniCode">A 16-digit ISNI code.</param>
        /// <exception cref="ArgumentNullException">a code argument is null.</exception>
        /// <exception cref="ArgumentException">a code argument is invalid.</exception>
        public NameIdentifier(string isniCode)
        {
            _ = isniCode ?? throw new ArgumentNullException(nameof(isniCode), "a code argument is null.");
            this.Code = ValidateCode(isniCode) ? isniCode : throw new ArgumentException("A code argument is invalid.", nameof(isniCode));
        }

        /// <summary>
        /// Gets a 16-digit ISNI code.
        /// </summary>
        public string Code { get; init; }

        /// <summary>
        /// Gets a <see cref="Uri"/> to the contributor's page at the isni.org website.
        /// </summary>
        /// <returns>A <see cref="Uri"/> to the contributor's page at the isni.org website.</returns>
        public Uri GetUri() => new Uri($"http://www.isni.org/isni/{this.Code}");

        /// <summary>
        /// Returns the string that represents a current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public new string ToString() => this.Code;

        private static bool ValidateCode(string isniCode) => !string.IsNullOrWhiteSpace(isniCode) && (isniCode.Length == 16 && isniCode.All(term => char.IsLetterOrDigit(term) || term == 'X'));
    }
}
