using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Day5Demo_43.Models
{
    public class MinAge : ValidationAttribute
    {
        int Value;
        public MinAge(int num)
        {
            Value = num;
        }
        public override bool IsValid(object obj)
        {   
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (obj is int)
                {
                    int suppliedValue = (int)obj;
                    if (suppliedValue > Value)
                    {
                        return true;
                    }
                    else
                    {
                        ErrorMessage = "Minimum value for age should be + " + Value; //user validation error
                        return false;
                    }
                }
                else
                {
                    return false;
                }    
            }
        }
    }
}