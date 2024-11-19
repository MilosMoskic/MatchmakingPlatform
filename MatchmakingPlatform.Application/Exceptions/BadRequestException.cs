using System.Net;

namespace MatchmakingPlatform.Application.Exceptions
{
    public class BadRequestException : BaseCustomException
    {
        public BadRequestException(string errorMessage) : base(errorMessage, HttpStatusCode.BadRequest) { }
    }
}
