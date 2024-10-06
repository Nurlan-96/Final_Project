using Domain.Exceptions;

namespace FinalProject.Domain.Exceptions
{

    public class UserAlreadyExistsException : Exception, INonSensitiveException
    {
        public UserAlreadyExistsException(string msg = "User already exists.") : base(msg)
        {
            
        }
    }
}