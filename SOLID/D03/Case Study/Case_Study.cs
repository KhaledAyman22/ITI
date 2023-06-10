
// DeadLine: 04/06/2023

// Apply the SOLID Principles for refactoring the following Case Study' implementation To have a Good Design: 

// Case Study V1:
// 1. We need to work on an error logging module that logs exception stack traces into a file.
// 2. A client wants to exports data from many files to a database.
 
// Case Study V2:
// 3. New Requirement:
// client wants to store this stack trace in a database if an IO exception occurs.
// Design considerations:
// 1. Whenever the client wants to introduce a new logger, try to avoid/limit modifications
// 2. ExceptionLogger directly contacts the low-level classes FileLogger,... to log the exceptions; so
// We need to alter the design so that this ExceptionLogger class can be loosely coupled with those classes.

//Case Study V3:
// 4. Apply DIP using IOC DI by any IOC containers (Windsor, structure map ,.....)
// using the Logging module in a separate program ... same as Shopping module


public class FileLogger
{
    public void LogMessage(string aStackTrace)
    {
        //code to log stack trace into a file.  
    }
}
public class ExceptionLogger
{
    public void LogIntoFile(Exception aException)
    {
        FileLogger objFileLogger = new FileLogger();
        objFileLogger.LogMessage(GetUserReadableMessage(aException));
    }
    private GetUserReadableMessage(Exception ex)
    {
        string strMessage = string.Empty;
        //code to convert Exception's stack trace and message to user readable format.  
        //........
       return strMessage;
    }
}

// class to export data from many files to a database.
public class DataExporter
{
    public void ExportDataFromFile()
    {
        try
        {
            //code to export data from files to database.  
        }
        catch (Exception ex)
        {
            new ExceptionLogger().LogIntoFile(ex);
        }
    }
}