using System;
using System.Xml;

namespace VersionUp.Core
{
    public class Version
    {
        public Version(string[] versionNodeDetails)
        {
            Major = versionNodeDetails[0];
            Minor = versionNodeDetails[1];
            Revision = versionNodeDetails[2];
            BuildNumber = versionNodeDetails[3];
        }

        public string Major { get; set; }
        public string Minor { get; set; }
        public string Revision { get; set; }
        public string BuildNumber { get; set; }

        public void Renew()
        {
            Revision = GenerateRevision();
            var buildNumber = int.Parse(BuildNumber);
            if (buildNumber == 65535)
            {
                Revision = (int.Parse(Revision) + 1).ToString();
                BuildNumber = "0";
            }
            else
            {
                BuildNumber = (buildNumber + 1).ToString();
            }
        }

        public   string GenerateRevision()
        {
            return (DateTime.UtcNow.Year - 2000).ToString() + (DateTime.UtcNow.DayOfYear.ToString("000"));
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Revision}.{BuildNumber}";
        }

    }
}
