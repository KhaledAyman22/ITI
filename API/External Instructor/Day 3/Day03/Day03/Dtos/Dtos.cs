namespace Day03.Dtos;

public record LoginDto(string Username, string Password);

public record TokenDto(string Token, DateTime Expiry);

public record RegisterDto(string Username,
    string Email,
    int Age,
    string Password);

public record UserInfoDto(string Username, string Email, int Age);