using System;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace tunder.Code.Extensions
{
    public static class ControllerBaseExtension
    {
        public static Guid GetUserId(this ControllerBase controller)
        {
            if (!Guid.TryParse(controller.User.FindFirst(ClaimTypes.NameIdentifier).Value, out var currentUserId))
            {
                currentUserId = new Guid();
            }

            return currentUserId;
        }
    }
}