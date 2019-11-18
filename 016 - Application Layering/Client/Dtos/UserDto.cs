using System;

namespace Users.Client.Dtos
{
    public class UserDto
    {
        /// <summary>
        /// The id of the user
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The user's display name
        /// </summary>
        public string DisplayName => $"{FirstName} {LastName}";

        /// <summary>
        /// The user's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The user's last name
        /// </summary>
        public string LastName { get; set; }
    }
}
