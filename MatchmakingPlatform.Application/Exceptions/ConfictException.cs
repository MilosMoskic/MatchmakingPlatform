using System.Net;

namespace MatchmakingPlatform.Application.Exceptions
{
    internal class ConfictException : BaseCustomException
    {
        public ConfictException(string errorMessage) : base(errorMessage, HttpStatusCode.Conflict) { }
    }
}
