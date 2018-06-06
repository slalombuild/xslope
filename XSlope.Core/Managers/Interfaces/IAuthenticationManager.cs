using System;
using XSlope.Core.Handlers.Interfaces;

namespace XSlope.Core.Managers.Interfaces
{
    public interface IAuthenticationManager
    {
        string Username { get; set; }
        string Token { get; set; }
        bool IsAuthenticated { get; }
        IAuthenticationHandler AuthenticationHandler { get; set; }
    }
}
