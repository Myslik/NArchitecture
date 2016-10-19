﻿using System;
using System.Threading.Tasks;
using Xunit;

namespace NArchitecture.Tests
{
    public class AuthorizationTests
    {
        [Fact(DisplayName = "AuthorizationService returns true if handler succeeds")]
        public async Task SucceededRequirementTest()
        {
            var user = UserFactory.CreateUser(i =>
            {
                i.AddDateOfBirthClaim(new DateTime(1986, 3, 10));
            });

            var authorizationService = ServiceFactory.CreateAuthorizationService(c =>
            {
                c.Options.AddPolicy("Over21", p => p.AddRequirements(new MinimumAgeRequirement(21)));
                c.AddAuthorizationHandler<MinimumAgeHandler>();
            });

            Assert.True(await authorizationService.Authorize(user, null, "Over21"));
        }

        [Fact(DisplayName = "AuthorizationService returns false if handler does not succeeds")]
        public async Task FailedRequirementTest()
        {
            var user = UserFactory.CreateUser(i =>
            {
                i.AddDateOfBirthClaim(new DateTime(1986, 3, 10));
            });

            var authorizationService = ServiceFactory.CreateAuthorizationService(c =>
            {
                c.Options.AddPolicy("Over40", new AuthorizationPolicy(new IAuthorizationRequirement[] { new MinimumAgeRequirement(40) }));
                c.AddAuthorizationHandler<MinimumAgeHandler>();
            });

            Assert.False(await authorizationService.Authorize(user, null, "Over40"));
        }

        [Fact(DisplayName = "AuthorizationService returns false if there are no requirements")]
        public async Task NoRequirementTest()
        {
            var user = UserFactory.CreateUser(i =>
            {
                i.AddDateOfBirthClaim(new DateTime(1986, 3, 10));
            });

            var authorizationService = ServiceFactory.CreateAuthorizationService(c => { });
            var requirements = new IAuthorizationRequirement[0];

            Assert.False(await authorizationService.Authorize(user, null, requirements));
        }
    }
}
