using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;

namespace Core.Services.Users
{
    [AutoRegister(AutoRegisterTypes.Scope)]
    public class UpdateUserService : IUpdateUserService
    {
        public void Update(User user, string name, string email, UserTypes type, decimal? annualSalary, IEnumerable<string> tags)
        {
            ValidateInputs(user, name, email, annualSalary, tags);
            user.SetEmail(email);
            user.SetName(name);
            user.SetType(type);
            user.SetMonthlySalary(annualSalary.Value / 12);
            user.SetTags(tags);
        }
        internal void ValidateInputs(User user, string name, string email, decimal? annualSalary, IEnumerable<string> tags)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User object cannot be null.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty or null.", nameof(name));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty or null.", nameof(email));

            if (!annualSalary.HasValue)
                throw new ArgumentException("Annual salary must be provided.", nameof(annualSalary));

            if (annualSalary.Value < 0)
                throw new ArgumentException("Annual salary cannot be negative.", nameof(annualSalary));

            if (tags == null)
                throw new ArgumentNullException(nameof(tags), "Tags collection cannot be null.");
        }
    }
}