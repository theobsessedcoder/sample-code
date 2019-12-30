using System;

namespace SampleApi.SampleExceptions
{
    public class UnexpectedException : Exception
    {
        public UnexpectedException() : base() { }
        public UnexpectedException(string message) : base(message) { }
    }
}
