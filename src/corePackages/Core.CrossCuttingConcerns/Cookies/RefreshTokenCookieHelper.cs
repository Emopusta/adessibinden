using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Core.CrossCuttingConcerns.Cookies
{
    public static class RefreshTokenCookieHelper
    {
        
        public static void SetRefreshTokenToCookie(HttpContext httpContext, RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { Expires = DateTime.UtcNow.AddDays(7), Secure=true, HttpOnly=true };
            httpContext.Response.Cookies.Append(key: "refreshToken", refreshToken.Token, cookieOptions);
        }

        public static string GetRefreshTokenFromCookies(HttpContext httpContext)
        {
            return httpContext.Request.Cookies["refreshToken"] ?? throw new BusinessException("Refresh token is not found in request cookies.");
        }

        public static void DeleteRefreshTokenFromCookies(HttpContext httpContext)
        {
            httpContext.Response.Cookies.Delete(key: "refreshToken");
        }

    }


}
