using System;

namespace Nasa.MarsRover.Exception.Command
{
    [Serializable]
    public class InvalidCommandException : System.Exception
    {
        public InvalidCommandException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
