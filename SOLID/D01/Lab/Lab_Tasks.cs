// Apply SOLID design principles on the following code samples for better design
//1.  
public class UserService  
{  
   public void Register(string email, string password)  
   {  
      if (!ValidateEmail(email))  
         throw new ValidationException("Email is not an email");  
      
      var user = new User(email, password);  
  
      SendEmail(new MailMessage("mysite@nowhere.com", email) { Subject="HEllo foo" });  
   }
   public virtual bool ValidateEmail(string email)  
   {  
     return email.Contains("@");  
   }  
   public bool SendEmail(MailMessage message)  
   {  
     _smtpClient.Send(message);  
   }  
}   
 
// 2.
//a. Add Circle & Square & Triangle & Cube
//b. Add function to get volume for the supported shapes
//c. noting that cube shape only support volume calculation

public class Rectangle{  
  public double Height {get;set;}  
  public double Wight {get;set; }  
}  
public class Circle{  
  public double Radius {get;set;}  
}  
public class AreaCalculator  
{  
  public double TotalArea(object[] arrObjects)  
  {  
     double area = 0;  
     Rectangle objRectangle;  
     Circle objCircle;  
     foreach(var obj in arrObjects)  
     {  
        if(obj is Rectangle)  
        {    
           area += obj.Height * obj.Width;  
        }  
        else  
        {  
           objCircle = (Circle)obj;  
           area += objCircle.Radius * objCircle.Radius * Math.PI;  
        }  
     }  
     return area;  
  }  
}

// 3.
class Rectangle
 def initialize(width, height)
 @width, @height = width, height
 end
 def set_width(width)
 @width = width
 end
 def set_height(height)
 @height = height
 end
end
class Square<Rectangle "inherits"
 def set_width(width)
 super(width)
 @height = height
 end
 def set_height(height)
 super(height)
 @width = width
 end
end