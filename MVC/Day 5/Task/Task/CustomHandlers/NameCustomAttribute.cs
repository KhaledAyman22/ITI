using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Task.CustomHandlers
{
    public class NameCustomAttribute : ValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (obj is string s)
                {
                    if(Regex.IsMatch(s, "^([a-zA-Z]| )+$"))
                        return true;
                    else
                    {
                        ErrorMessage = "Name must consist of only letters and spaces.";
                        return false;
                    }
                }
                else
                {
                    ErrorMessage = "Name must be a string.";
                    return false;
                }
            }
        }
}
}