namespace Dyfort.Umbraco.AdPasswordChecker
{
    public class ActiveDirectorySettings
    {
        public const string SectionName = "ActiveDirectory";
        public string Domain { get; set; }
        public bool Enabled { get; set; } = false;
    }
}
