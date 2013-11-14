namespace WalletHelper.Entity
{
    /// <summary>
    /// This class is for the probable tags that the user will use
    /// </summary>
    public class Hashtag
    {
        /// <summary>
        /// Unique ObjectId that identifies the record
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Content of the user specified tag
        /// </summary>
        public string Tag { get; set; }
        /// <summary>
        /// ObjectId of the user
        /// </summary>
        public string UserId { get; set; }
    }
}
