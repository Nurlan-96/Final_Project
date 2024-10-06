namespace FinalProject.Domain.Exceptions
{
    public class PasswordMismatchException : Exception
    {
        public PasswordMismatchException() : base("Connection string could not be found.")
        {
            
        }
    }
}
