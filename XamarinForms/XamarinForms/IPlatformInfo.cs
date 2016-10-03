namespace XamarinForms
{
    // This interface will be implemented by classes from the different platform projects
    public interface IPlatformInfo
    {
        string GetModel();
        string GetVersion();
    }
}
