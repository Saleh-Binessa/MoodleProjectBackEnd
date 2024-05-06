namespace FrontEndMoodle.Models
{

    public class GlobalAppState
    {
        // Property to store the authentication token
        public string AuthToken { get; set; } = string.Empty;

        // Property to store the username
        public string Username { get; set; } = string.Empty;

        // Property to store whether the user is an admin
        public bool IsAdmin { get; set; } = false;

        // Method to set authentication data
        public void SetAuthData(string token, string username, bool isAdmin)
        {
            AuthToken = token;
            Username = username;
            IsAdmin = isAdmin;
        }

        // Method to clear all authentication data
        public void ClearAuthData()
        {
            AuthToken = string.Empty;
            Username = string.Empty;
            IsAdmin = false;
        }
    }



}
