﻿namespace MoodleBackEnd.Models.Requests
{
    public class SignupRequest
    {
        public string Name { get; set; }       
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}