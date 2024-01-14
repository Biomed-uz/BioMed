namespace BioMed.Domain.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string exceptionMessage)
            : base(exceptionMessage)
        {
        }

        public EntityNotFoundException(string exceptionMessage, Exception innerException)
            : base(exceptionMessage, innerException)
        {
        }
    }
}
