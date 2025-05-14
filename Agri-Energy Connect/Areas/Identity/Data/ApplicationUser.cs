﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Agri_Energy_Connect.Models;
using Microsoft.AspNetCore.Identity;

namespace Agri_Energy_Connect.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string LastName { get; set; }

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";

    //Navigation properties
    public ICollection<Product> Products { get; set; }
}

