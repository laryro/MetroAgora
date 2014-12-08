using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using LF.Authentication;
using LF.Emails;
using LF.Entities;
using LF.Entities.Enums;
using LF.DBManager;

namespace LF.Services
{
    public class UserService : BaseService, IAuthService
    {
        private readonly BaseRepository<User> userRepository;
        private readonly BaseRepository<Login> loginRepository;

        public UserService(AllServices parent, BaseRepository<User> userRepository, BaseRepository<Login> loginRepository)
            : base(parent)
        {
            this.userRepository = userRepository;
            this.loginRepository = loginRepository;
        }

        public User GetUserByTicket(String key)
        {
            var login = getLoginByTicket(key);

            return login == null ? null : login.User;
        }

        private Login getLoginByTicket(String key)
        {
            return loginRepository.SingleOrDefault(u => u.Ticket == key);
        }

        public User ValidateUserAndSetTicket(String username, String password, String ticket)
        {
            var user = Get(username, password);

            changeTicket(user, ticket);

            return user;
        }

        public void Logout(String ticket)
        {
            var login = getLoginByTicket(ticket);

            if (login != null)
            {
                InTransaction(
                    () => loginRepository.Delete(login)
                );
            }
        }

        private void changeTicket(User user, string ticket)
        {
            if (user == null)
                return;

            InTransaction(() =>
            {
                var logins = loginRepository.SimpleFilter(l => l.Ticket == ticket);

                foreach (var login in logins)
                {
                    loginRepository.Delete(login);
                }

                var newLogin = new Login
                {
                    Ticket = ticket,
                    User = user,
                };

                loginRepository.SaveOrUpdate(newLogin);
            });
        }

        public User Get(String username, String password)
        {
            var user = userRepository.SingleOrDefault(
                u => u.Username == username
                    && u.Password == encrypt(password)
                    && u.Status <= UserStatus.Active);

            return user;
        }

        private String encrypt(String password)
        {
            if (String.IsNullOrEmpty(password))
                return null;

            var md5 = new MD5CryptoServiceProvider();

            var originalBytes = Encoding.Default.GetBytes(password);
            var encodedBytes = md5.ComputeHash(originalBytes);

            var hexCode = BitConverter
                            .ToString(encodedBytes)
                            .Replace("-", "");

            return hexCode;
        }



        internal User CreateUserWithinTransaction(String username, String password, String nome, UserRole role)
        {
            var user = new User
            {
                Username = username,
                Password = encrypt(password),
                Nome = nome,
                Role = role,
                Status = UserStatus.Active,
            };

            userRepository.SaveOrUpdate(user);

            var keywords = new Dictionary<String, String>
            {
                {"PASSWORD", password}
            };

            new Sender()
                .Format(FormatType.NewUser, keywords)
                .To(user.Username)
                .Send();

            return user;
        }

        public void CreateUser(String username, String password, String nome, UserRole role)
        {
            InTransaction(() => CreateUserWithinTransaction(username, password, nome, role));
        }


        public void ChangePassword(User user, String password)
        {
            InTransaction(() =>
            {
                user.Password = encrypt(password);

                userRepository.SaveOrUpdate(user);
            });
        }



        public User GetUserByPasswordRecoverKey(Guid key)
        {
            return userRepository.SingleOrDefault(u => u.PasswordRecover == key);
        }

        public Boolean SendRecoverLink(String username, String path)
        {
            var user = userRepository.SingleOrDefault(u => u.Username == username);

            if (user == null)
                return false;
            
            return InTransaction(() =>
            {
                user.PasswordRecover = Guid.NewGuid();

                var keywords = new Dictionary<String, String>
                {
                    {"PATH", path},
                    {"GUID", user.PasswordRecover.ToString()},
                };

                new Sender()
                    .Format(FormatType.RecoverPassword, keywords)
                    .To(user.Username)
                    .Send();

                userRepository.SaveOrUpdate(user);

                return true;
            });
        }


        public Boolean UserAlreadyExists(String email)
        {
            return userRepository.Count(u => u.Username == email) > 0;
        }


    }
}