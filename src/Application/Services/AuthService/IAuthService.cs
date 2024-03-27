using Core.Application.Services;
using Core.Security.JWT;
using Domain.Models;

namespace Application.Services.AuthService;

public interface IAuthService : IServiceBase
{
    public Task<AccessToken> CreateAccessToken(User user);
    public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);
    public Task<RefreshToken?> GetRefreshTokenByToken(string token);
    public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);
    public Task DeleteOldRefreshTokens(int userId);
    public Task RevokeDescendantRefreshTokens(RefreshToken refreshToken, string ipAddress, string reason);
    public Task RevokeRefreshToken(RefreshToken token, string ipAddress, string? reason = null, string? replacedByToken = null);
    public Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress);
}
