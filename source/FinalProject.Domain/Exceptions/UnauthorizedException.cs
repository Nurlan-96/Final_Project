using Domain.Exceptions;

namespace FinalProject.Domain.Exceptions
{

    public class UnauthorizedException : Exception, INonSensitiveException
    {
        public UnauthorizedException(string msg = "You do not have permission to do this.") : base(msg)
        {
            
        }
    }
}