#region Before OCP
// Before: OCP
class Logger
 def initialize(logging_form)
 @logging_form = logging_form
 end

 def log(message)
 puts message if @logging_form == “console”
 File.write(“logs.txt”, message) if @logging_form == “file”
 end
end
#endregion

#region After OCP
// After: OCP
class EventTracker
 def initialize(logger: ConsoleLogger.new)
 @logger = logger
 end
 def log(message)
 @logger.log(message)
 end
end

class ConsoleLogger
 def log(message)
 puts message
 end
end

class FileLogger
 def log(message)
 File.write(“logs.txt”, message)
 end
end

abstract class Logger
{
    abstract Log(string message);
}

Interface ILogger
{
    Log(string message);
}

class ConsoleLogger : Logger
{
    void Log(string message)
    {
        //puts message on Console
    }
}

class FileLogger : Logger
{
    void Log(string message)
    {
        //File.write(“logs.txt”, message) if @logging_form == “file”
    }
}

#endregion

