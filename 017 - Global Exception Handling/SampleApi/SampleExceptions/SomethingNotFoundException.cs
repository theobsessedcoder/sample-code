using System;

namespace SampleApi.SampleExceptions
{
    public class SomethingNotFoundException : Exception
    {
        public SomethingNotFoundException() : base() { }
        public SomethingNotFoundException(string message) : base(message) { }
    }
}
