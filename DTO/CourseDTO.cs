﻿using SevStudentsApp.Models;

namespace SevStudentsApp.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }

        public string? Description { get; set; }

        public int TeacherId { get; set; }
    }
}
