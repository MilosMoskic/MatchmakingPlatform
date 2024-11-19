using System.Net;

namespace MatchmakingPlatform.Application.Exceptions
{
    public class NotFoundException : BaseCustomException
    {
        public NotFoundException(string errorMessage) : base(errorMessage, HttpStatusCode.NotFound) { }
    }
}
