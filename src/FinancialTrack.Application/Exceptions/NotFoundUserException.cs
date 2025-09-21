using System.Runtime.Serialization;

namespace FinancialTrack.Application.Exceptions;

public class NotFoundUserException:Exception
{
    public NotFoundUserException():base("Email or password is incorrect")
    {
            
    }

}