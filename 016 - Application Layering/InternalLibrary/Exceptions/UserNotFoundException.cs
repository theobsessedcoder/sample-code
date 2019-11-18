using System;

namespace Users.InternalLibrary.Exceptions
{
    /// <summary>
    /// Thrown when a user was expected but could not be found
    /// </summary>
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base() { }
        public UserNotFoundException(string message) : base(message) { }
    }
}
