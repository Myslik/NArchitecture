﻿using NArchitecture.Tests.Validation;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Xunit;

namespace NArchitecture.Tests
{
    public class ValidationTests
    {
        [Fact]
        public async Task SimpleValidMessageTest()
        {
            var validationService = ServiceFactory.CreateValidationService();

            await validationService.Validate(new SimpleMessage { RequiredAttribute = "Simple Message" });
        }

        [Fact]
        public async Task SimpleInvalidMessageTest()
        {
            var validationService = ServiceFactory.CreateValidationService();

            await Assert.ThrowsAsync<ValidationException>(() =>
            {
                return validationService.Validate(new SimpleMessage());
            });
        }
    }
}
