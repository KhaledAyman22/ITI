using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

#region Program
IShape[] shapes = new IShape[] { new Square(5), new Rectangle(5,10), new Circle(20), new Triangle(5,15), new Cube(10) };

var areas = Calculator.AreaCalculator(shapes);
var volumes = Calculator.VolumeCalculator(shapes);

foreach (var area in areas)
{
    Console.WriteLine($"Shape: {area.Item1}, has an area = {area.Item2} cm^2");
}

Console.WriteLine("*****************************************************************");

foreach (var vol in volumes)
{
    Console.WriteLine($"Shape: {vol.Item1}, has a volume = {vol.Item2} cm^3");
}
#endregion

#region 1

public interface IEmailValidator
{
    public bool ValidateEmail(string email);
}

public class EmailValidator : IEmailValidator
{
    public virtual bool ValidateEmail(string email)
    {
        return email.Contains("@");
    }
}

public interface IEmailProvider
{
    public void SendEmail(MailMessage message);
}

public class EmailProvider : IEmailProvider
{
    private readonly SmtpClient smtpClient;

    public EmailProvider(SmtpClient smtpClient)
    {
        this.smtpClient = smtpClient;
    }

    public void SendEmail(MailMessage message)
    {
        smtpClient.Send(message);
    }
}

public class UserService
{

    private readonly IEmailProvider emailProvider;
    private readonly IEmailValidator emailValidator;

    public UserService(IEmailProvider _emailProvider, IEmailValidator _emailValidator)
    {
        this.emailProvider = _emailProvider;
        this.emailValidator = _emailValidator;
    }

    public void Register(string email, string password)
    {
        if (!emailValidator.ValidateEmail(email))
            throw new ValidationException("Email is not an email");

        //var user = new User(email, password); ??

        emailProvider.SendEmail(new MailMessage("mysite@nowhere.com", email) { Subject = "HEllo foo" });
    }
}
#endregion

#region 2

public interface IShape
{
    public double TotalArea();
}

public interface I3DShape
{
    public double TotalVolume();
}

public class Rectangle : IShape
{
    public double Height { get; set; }
    public double Width { get; set; }

    public Rectangle(double height, double width)
    {
        Height = height;
        Width = width;
    }

    public double TotalArea()
    {
        return Height * Width;
    }
}

public class Square : IShape
{
    public double Side { get; set; }

    public Square(double side)
    {
        Side = side;
    }

    public double TotalArea()
    {
        return Side * Side;
    }
}

public class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double TotalArea()
    {
        return Radius * Radius * Math.PI;
    }
}

public class Triangle : IShape
{
    public double Base { get; set; }

    public double Height { get; set; }

    public Triangle(double @base, double height)
    {
        Base = @base;
        Height = height;
    }

    public double TotalArea()
    {
        return 0.5 * Base * Height;
    }
}

public class Cube : IShape, I3DShape
{
    public double Side { get; set; }

    public Cube(double side)
    {
        Side = side;
    }

    public double TotalArea()
    {
        return 6 * Side * Side;
    }

    public double TotalVolume()
    {
        return Side * Side * Side;
    }
}

public class Calculator
{
    public static List<(string, double)> AreaCalculator(IShape[] shapes)
    {
        var ret = new List<(string, double)>();
        foreach (var shape in shapes)
        {
            ret.Add((shape.GetType().Name, shape.TotalArea()));
        }

        return ret;
    }

    public static List<(string, double)> VolumeCalculator(IShape[] shapes)
    {
        var ret = new List<(string, double)>();
        foreach (var shape in shapes)
        {
            if(shape is I3DShape _3dShape)
                ret.Add((_3dShape.GetType().Name, _3dShape.TotalVolume()));
        }

        return ret;
    }
}
#endregion

#region 3
public abstract class Shape
{
    public double Dimension01 { get; set; }
}

public class RectangleV2 : Shape
{
    public double Dimension02 { get; set; }

    public RectangleV2(double height, double width)
    {
        Dimension01 = height;
        Dimension02 = width;
    }

    public double TotalArea()
    {
        return Dimension01 * Dimension02;
    }
}

public class SquareV2 : Shape
{
    public SquareV2(double side)
    {
        Dimension01 = side;
    }

    public double TotalArea()
    {
        return Dimension01 * Dimension01;
    }
}
#endregion