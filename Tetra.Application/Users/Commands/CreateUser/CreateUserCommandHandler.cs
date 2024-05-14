using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Tetra.Application.Interfaces;
using Tetra.Domain;

namespace Tetra.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler(IUsersDbContext usersDbContext, IPasswordHasher passwordHasher, IMapper mapper)
        : IRequestHandler<CreateUserCommand, CreateUserVm>
    {
        private readonly IUsersDbContext _usersDbContext = usersDbContext;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IMapper _mapper = mapper;

        public async Task<CreateUserVm> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //TODO написать кастомные ошибки
            if (
                await _usersDbContext.Users
                    .Where(x => x.Email == request.Email)
                    .AnyAsync(cancellationToken)
            )
            {
                throw new Exception("Почта уже зарегистрирована.");
            }

            var user = _mapper.Map<UserDomain>(request);
            user.Id = Guid.NewGuid();

            var passHash = (await _passwordHasher.Hash(request.Password)).ToString();
            user.UserData = new UserDataDomain { PasswordHash = passHash };

            await _usersDbContext.Users.AddAsync(user);
            await _usersDbContext.SaveChangesAsync(cancellationToken);

            //TODO Token
            var userVm = new CreateUserVm
            {
                Name = user.Name,
                SurName = user.SurName,
                Patronymic = user.Patronymic,
                Email = user.Email,
                Token = "key",
            };
            
            return userVm;
        }
    }
}
