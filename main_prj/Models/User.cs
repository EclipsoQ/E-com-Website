using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace main_prj.Models;

public partial class User
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "Bắt buộc")]
    public string? UserName { get; set; }

    [Required(ErrorMessage = "Bắt buộc")]
    [Remote("IsUnique", "Validation", ErrorMessage = "Email đã được sử dụng")]
    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;

    public string? Address { get; set; } = null!;

    [Required(ErrorMessage = "Bắt buộc")]
    public string Password { get; set; } = null!;

    public bool? IsAdmin { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
