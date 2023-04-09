namespace APis.Identity.Day3.Dtos;

public record LoginDto(string UserName, string Password);

public record TokenDto(string Token, DateTime Expiry);

public record RegisterDto(string UserName,
    string Email,
    string Department,
    string Password);