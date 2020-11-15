using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace ToDoWebApp.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        // to use sessionstorage from the page
        private ISessionStorageService _sessionStorageService { get; set; } 
        public CustomAuthenticationStateProvider(ISessionStorageService sessionStorageService)
        {
            _sessionStorageService = sessionStorageService;
        }


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // bring email address from session storage.
            var emailAddress = await _sessionStorageService.GetItemAsync<string>("emailAddress");

            ClaimsIdentity identity;
            if (emailAddress != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, emailAddress) //insert email address and create new identity
                }, "apiauth_type") ;
            }
            else
            {
                identity = new ClaimsIdentity();
            }


            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }


        public void MarkUserAsAuthenticated(string emailAddress)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, emailAddress),
            }, "apiauth_type");
            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }



}
