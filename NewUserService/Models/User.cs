﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using NewUserService.Models.Enums;
using NewUserService.Models.Templates;
using NewUserService.Utils;

namespace NewUserService.Models;

[Table("user", Schema = "user_schema")]
public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id", TypeName = "bigint")]
    [Key]
    public long Id { get; set; }

    [Required]
    [Column("first_name", TypeName = "varchar(50)")]
    public string FirstName { get; set; }

    [Required]
    [Column("last_name", TypeName = "varchar(50)")]
    public string LastName { get; set; }

    [Required]
    [Column("gender", TypeName = "varchar(10)")]
    public Gender Gender { get; set; }

    [Required]
    [Column("passport_ser_num", TypeName = "varchar(15)")]
    public string PassportSerNum { get; set; }

    [Required]
    [Column("pinfl", TypeName = "varchar(14)")]
    [RegularExpression(@"^\d{14}$", ErrorMessage = "The PINFL field must be 14 digits.")]
    public string PINFL { get; set; }

    [EmailAddress] 
    [Column("email")] 
    public string Email { get; set; }

    [Required]
    [Column("username", TypeName = "varchar(150)")]
    [RegularExpression(@"[a-zA-Z0-9_]{3,20}$", ErrorMessage = "Invalid username format.")]
    public string Username { get; set; }

    [JsonIgnore]
    [Required]
    [Column("password_hash")]
    public byte[] PasswordHash { get; set; }

    [JsonIgnore]
    [Required]
    [Column("salt")]
    public byte[] Salt { get; set; }


    public void CreateUser(UserCreateTemplate userCreateTemplate)
    {
        FirstName = userCreateTemplate.FirstName;
        LastName = userCreateTemplate.LastName;
        Gender = userCreateTemplate.Gender == "Male" ? Gender.Male : Gender.Female;
        PassportSerNum = userCreateTemplate.PassportSerNum;
        PINFL = userCreateTemplate.PINFL;
        Email = userCreateTemplate.Email;
        Username = userCreateTemplate.Username;
        Salt = PasswordHasher.GenerateSalt();
        PasswordHash = PasswordHasher.HashPassword(userCreateTemplate.Password, Salt);
    }

    public void UpdateUser(UserCreateTemplate userCreateTemplate)
    {
        FirstName = userCreateTemplate.FirstName;
        LastName = userCreateTemplate.LastName;
        Gender = userCreateTemplate.Gender == "Male" ? Gender.Male : Gender.Female;
        PassportSerNum = userCreateTemplate.PassportSerNum;
        PINFL = userCreateTemplate.PINFL;
        Email = userCreateTemplate.Email;
        Username = userCreateTemplate.Username;
        Salt = PasswordHasher.GenerateSalt();
        PasswordHash = PasswordHasher.HashPassword(userCreateTemplate.Password, Salt);
    }
}