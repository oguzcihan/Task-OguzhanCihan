﻿namespace Core.Entities;

public class User : AbsBaseEntity
{
    public string FirstName { get; set; }
    public string UserName { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
}