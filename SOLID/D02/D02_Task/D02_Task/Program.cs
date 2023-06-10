// Apply SOLID design principles on the following code samples for better design

// 1.
// a. Based on specifications, we need to create an interface and a TeamLead class to implement it.
// b. Later another role like Manager, who assigns tasks to TeamLead and will not work on the tasks, is introduced into the system,
// Apply needed refactoring to for better design and mention the current design smells

using System.Text;


Console.WriteLine("Hello");

public interface IEmployee
{
    public List<ITask> Tasks { get; }
    void CreateSubTask();
    void WorkOnTask();
}

public interface ITask
{
    void AssignTo(IEmployee e);
    void AssignTo(ILead e);
}

public interface ILead
{
    void AssignTask(ITask t, IEmployee e);
}

public interface IManager
{
    void AssginTaskToLead(ITask t, ILead l);
}

public class TeamLead : ILead, IEmployee
{
    public List<ITask> Tasks { get; }

    public void AssignTask(ITask t, IEmployee e)
    {
        t.AssignTo(e);
    }

    public void CreateSubTask()
    {
        //Code to create a sub task  
    }

    public void WorkOnTask()
    {
        //Code to implement perform assigned task.  
    }
}

public class Manager : IManager
{
    public void AssginTaskToLead(ITask t, ILead l)
    {
        t.AssignTo(l);
    }
}

// 2. Client need to build an application to manage data using group of SQL files.
// a. we need to develop load text and save text functionalities for group of SQL files in the application directory.
// b. we need a manager class that manages the load and saves the text of group of SQL files along with the SqlFile Class.
// c. New Requirement:
// After some time our leaders might tell us that we may have a few read-only files in the application folder, 
// so we need to restrict the flow whenever it tries to do a save on them.
// d. To avoid an exception we need to modify "SqlFileManager" by adding one condition to the loop.
//e. Apply needed refactoring to for better design and mention the current design smells

public interface IFile
{
    string FilePath { get; set; }
    string FileText { get; set; }
    string LoadText();
}

public interface IWriteableFile
{
    string SaveText();
}

public interface IFilesReader
{
    string GetTextFromFiles();
}

public interface IFilesWriter
{
    void SaveTextIntoFiles();
}

public class SqlFile : IFile, IWriteableFile
{
    public string FilePath { get; set; }
    public string FileText { get; set; }
    public string LoadText()
    {
        /* Code to read text from sql file */
        return "";
    }

    public string SaveText()
    {
        /* Code to save text into sql file */
        return "";
    }
}

public class ReadOnlySqlFile : IFile
{
    public string FilePath { get; set; }
    public string FileText { get; set; }

    public string LoadText()
    {
        /* Code to read text from sql file */
        return "";
    }
}

public class SqlReadOnlyFileManager : IFilesReader
{
    public List<ReadOnlySqlFile> lstSqlFiles { get; set; }

    public string GetTextFromFiles()
    {
        StringBuilder objStrBuilder = new StringBuilder();
        foreach (var objFile in lstSqlFiles)
        {
            objStrBuilder.Append(objFile.LoadText());
        }
        return objStrBuilder.ToString();
    }
}

public class SqlFileManager : IFilesReader, IFilesWriter
{
    public List<SqlFile> lstSqlFiles { get; set; }

    public string GetTextFromFiles()
    {
        StringBuilder objStrBuilder = new StringBuilder();
        foreach (var objFile in lstSqlFiles)
        {
            objStrBuilder.Append(objFile.LoadText());
        }
        return objStrBuilder.ToString();
    }

    public void SaveTextIntoFiles()
    {
        foreach (var objFile in lstSqlFiles)
        {
            objFile.SaveText();
        }
    }
}