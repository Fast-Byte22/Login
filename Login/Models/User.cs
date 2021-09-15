using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class User
    {
        //model info
        
        int Id {  get; set; }
        DateTime CreateTime = DateTime.Now;

        //user info
        
        string FirstName {  get; set; }
        string LastName {  get; set; }
        string Email {  get; set; }
        string PhoneNumber {  get; set; }
        string Password {  get; set; }
        DateTime DateOfBirth { get; set; }
    }
}