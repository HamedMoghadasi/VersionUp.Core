using System;
using System.Xml;

namespace VersionUp.Core
{
    internal class Version
    {
        internal Version(XmlNode versionNode)
        {
            var versionNodeDetails = versionNode.InnerText.Split('.');
            Major = versionNodeDetails[0];
            Minor = versionNodeDetails[1];
            Revision = versionNodeDetails[2];
            BuildNumber = versionNodeDetails[3];
        }

        internal string Major { get; set; }
        internal string Minor { get; set; }
        internal string Revision { get; set; }
        internal string BuildNumber { get; set; }

        internal void Renew()
        {
            Revision = (DateTime.UtcNow.Year - 2000).ToString() + (DateTime.UtcNow.DayOfYear.ToString("000"));
            var buildNumber = int.Parse(BuildNumber);
            if (buildNumber == 65535)
            {
                Revision = Revision + 1;
                BuildNumber = "0";
            }
            else {
            BuildNumber = (buildNumber + 1).ToString();
            }
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Revision}.{BuildNumber}";
        }

    }
}
