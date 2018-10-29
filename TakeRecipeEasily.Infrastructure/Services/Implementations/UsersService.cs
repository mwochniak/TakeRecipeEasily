﻿using TakeRecipeEasily.Core.Domain;
using TakeRecipeEasily.Core.Repositories;
using TakeRecipeEasily.Infrastructure.Contracts.Extensions;
using TakeRecipeEasily.Infrastructure.Contracts.QueryModels;
using TakeRecipeEasily.Infrastructure.Exceptions.ErrorMessages;
using TakeRecipeEasily.Infrastructure.Validation;
using System;
using System.Threading.Tasks;

namespace TakeRecipeEasily.Infrastructure.Services.Implementations
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task CreateUserAsync(Guid id, string email, string firstName, string lastName, string hashedPassword)
        {
            await _usersRepository.IsEmailInUse(email).ThrowIfTrueAsync(ErrorType.Conflict, UsersErrorCodes.EmailIsInUse);

            var user = User.Create(id, email, firstName, lastName, hashedPassword);
            await _usersRepository.AddAsync(user);
        }

        public async Task<UserRetrieveModel> GetUserAsync(Guid id)
            => await _usersRepository
                .GetUserAsync(id)
                .ThrowIfNullAsync(ErrorType.NotFound, UsersErrorCodes.UserDoesNotExists)
                .AsModel();

        public async Task<UserRetrieveModel> GetUserAsync(string email)
            => await _usersRepository
                .GetUserAsync(email)
                .ThrowIfNullAsync(ErrorType.NotFound, UsersErrorCodes.UserDoesNotExists)
                .AsModel();
    }
}