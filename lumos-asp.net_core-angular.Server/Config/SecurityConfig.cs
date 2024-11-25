using lumos_asp.net_core_angular.Server.Models.Auth;
using lumos_asp.net_core_angular.Server.Repositories.Auth;
using Microsoft.IdentityModel.Tokens;

namespace lumos_asp.net_core_angular.Server.Config
{
    public class SecurityConfig
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        public SecurityConfig(IRoleRepository roleRepository,
                              IUserRepository userRepository) 
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }

        public async Task InitializeAsync()
        {
            await CreateAdmin();
        }

        public async Task CreateAdmin()
        {
            // Busca o papel de administrador
            var roleAdmin = await _roleRepository.FindByRoleAsync(Role.Values.ADMIN);

            if (roleAdmin == null)
            {
                Console.WriteLine("Role de administrador não encontrado. Verifique o banco de dados.");
                return;
            }

            // Verifica se o usuário administrador já existe
            User? userAdmin = null;
            try
            {
                userAdmin = await _userRepository.FindByUsernameOrEmailAsync("admin");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            if (userAdmin != null)
            {
                Console.WriteLine("Admin já existe.");
                return;
            }

            // Cria o usuário administrador
            var user = new User
            {
                Username = "admin",
                Email = "admin@hotmail.com",
                Password = BCrypt.Net.BCrypt.HashPassword("4dejulho_"), // Senha hash
                DateOfBirth = DateTime.UtcNow,
                Roles = [roleAdmin]
            };

            // Salva o usuário no banco
            await _userRepository.AddAsync(user);

            Console.WriteLine("Admin criado com sucesso.");
        }

    }
}
