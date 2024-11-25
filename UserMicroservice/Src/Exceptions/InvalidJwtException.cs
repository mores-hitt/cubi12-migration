namespace user_microservice.Src.Exceptions
{
    public class InvalidJwtException : Exception
    {
        public InvalidJwtException() { }

        public InvalidJwtException(string? message)
            : base(message) { }

        public InvalidJwtException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}