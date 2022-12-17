namespace SpellBoundAR.AppIdentification
{
    public class AppReleaseVariant
    {
        public string ProductName { get; }
        public string ApplicationIdentifier { get; }
        public string IconPath { get; }

        public override string ToString()
        {
            return $"ProductName: {ProductName}\n" +
                   $"ApplicationIdentifier: {ApplicationIdentifier}\n" +
                   $"IconPath: {IconPath}\n";
        }

        public AppReleaseVariant(string productName, string applicationIdentifier, string iconPath)
        {
            ProductName = productName;
            ApplicationIdentifier = applicationIdentifier;
            IconPath = iconPath;
        }
    }
}
