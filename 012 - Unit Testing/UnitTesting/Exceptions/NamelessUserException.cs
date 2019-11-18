using System;

namespace UserServiceExample.Exceptions
{
    /// <summary>
    /// Indicates that a user is missing a first or last name
    /// </summary>
    public class NamelessUserException : Exception
    {
        public NamelessUserException() : base() { }
        public NamelessUserException(string message) : base(message) { }
    }
}
