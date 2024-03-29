﻿using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Network;

public static class IpAddressHelper
{
    public static string GetIpAddress(HttpContext httpContext) 
    {
        string ipAddress = httpContext.Request.Headers.ContainsKey("X-Forwarded-For")
            ? httpContext.Request.Headers["X-Forwarded-For"].ToString()
            : httpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString() 
                ?? throw new InvalidOperationException("IP address cannot be retrieved from request.");
        return ipAddress;
    }
}
