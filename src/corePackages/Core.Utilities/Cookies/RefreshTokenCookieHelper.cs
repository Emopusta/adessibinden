using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Cookies
{
    public static class RefreshTokenCookieHelper
    {

        public static void SetRefreshTokenToCookie(HttpResponse response, RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
            response.Cookies.Append(key: "refreshToken", refreshToken.Token, cookieOptions);
        }

        public static string GetRefreshTokenFromCookies(HttpRequest request) =>
        request.Cookies["refreshToken"] ?? throw new ArgumentException("Refresh token is not found in request cookies.");

    }


}
