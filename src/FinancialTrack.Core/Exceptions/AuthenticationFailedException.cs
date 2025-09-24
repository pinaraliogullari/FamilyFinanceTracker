using System.Runtime.Serialization;

namespace FinancialTrack.Application.Exceptions;

public class AuthenticationFailedException:Exception
{
    public AuthenticationFailedException():base("Email or password is incorrect")
    {
            
    }

}