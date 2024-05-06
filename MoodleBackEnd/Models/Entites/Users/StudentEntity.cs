﻿namespace MoodleBackEnd.Models.Entites.Users
{
    public class StudentEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UserAccountId { get; set; }
        public UserAccountEntity Account { get; set; }
        public List<StudentCourse> Courses { get; set; }
        public StudentEntity() { }
    }
}
