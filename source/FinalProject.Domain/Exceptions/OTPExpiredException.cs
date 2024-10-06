using Domain.Exceptions;

namespace FinalProject.Domain.Exceptions
{

    public class OTPExpiredException : Exception, INonSensitiveException
    {
        public OTPExpiredException(string msg = "The code has expired.") : base(msg)
        {
            
        }
    }
}