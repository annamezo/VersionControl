﻿namespace UserMaintenance;
using System;

public class User
{
    public Guid ID { get; set; } = Guid.NewGuid();
    
    
   // public string FirstName { get; set; }
   // public string LastName { get; set; }
    public string FullName { get; set; }
    //{
    //    get
    //    {
    //        return string.Format(
    //            "{0} {1}",
    //            LastName,
    //            FirstName);
    //   }
    //}
}
