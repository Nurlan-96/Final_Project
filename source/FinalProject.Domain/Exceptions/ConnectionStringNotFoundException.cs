namespace FinalProject.Domain.Exceptions
{
    public class ConnectionStringNotFoundException : Exception
    {
        public ConnectionStringNotFoundException() : base("Connection string could not be found.")
        {
            
        }
    }
}
