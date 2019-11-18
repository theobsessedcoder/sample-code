using System.Collections.Generic;

namespace Library.Internal.Domain.Users.Models
{
    /// <summary>
    /// A page of users
    /// </summary>
    public class UsersPage
    {
        /// <summary>
        /// The users in the current page of data
        /// </summary>
        public IEnumerable<User> Users { get; set; }

        /// <summary>
        /// The token indicating the beginning location of the next page of user data
        /// </summary>
        public string PagingToken { get; set; }
    }
}
