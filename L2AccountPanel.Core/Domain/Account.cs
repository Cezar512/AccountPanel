using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace L2AccountPanel.Core.Domain
{
    public class Account
    {
        private static readonly Regex EmailRegex = new Regex(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$");
        private static readonly Regex UsernameRegex = new Regex(@"^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");


        public Guid Id {get; protected set;}
        public string Email {get; protected set;}
        public string Password {get; protected set;}
        public string Username {get; protected set;}
        public string Salt {get; protected set;}    
        public string Role {get; protected set;}    
        public DateTime CreatedAt {get; protected set;}
        public DateTime UpdatedAt {get; protected set;}



        public Account(Guid userId, string email, string password, string username, 
            string salt, string role)
        {
            Id = userId;
            SetEmail(email);
            SetUsername(username);
            SetPassword(password,salt);
            SetRole(role);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if(string.IsNullOrEmpty(username))
            {
                throw new Exception("Username is invalid.");
            }
            if(!UsernameRegex.IsMatch(username))
            {
                throw new Exception("Username is invalid.");
            }
            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            string emailLowerCase = email.ToLowerInvariant();
            if(string.IsNullOrEmpty(email))
            {
                throw new Exception("Email is invalid.");
            }
            if(!EmailRegex.IsMatch(email))
            {
                throw new Exception("Email is invalid.");
            }
            Email = emailLowerCase;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            if(string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can not be empty.");
            }
            if(string.IsNullOrWhiteSpace(salt))
            {
                throw new Exception("Salt can not be empty.");
            }
            if(password.Length < 4)
            {
                throw new Exception("Password must contain at least 4 characters.");
            }
            if (password.Length>100)
            {
                throw new Exception("Password can not contain more than 100 characters.");
            }
            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRole(string role)
        {
            if(!Domain.Role.IsValid(role))
            {
                throw new Exception("Role is incorect.");
            }
            Role = role;
        } 
    }
}