using System;

namespace Library.Internal.Domain.Users.Models
{
    public class User
    {
        /// <summary>
        /// The id of the user
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// The user's first name
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// The user's last name
        /// </summary>
        public string LastName { get; }

        public User(
            Guid id,
            string firstName,
            string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
