using System;
using System.Diagnostics;
using System.Xml;

namespace VersionUp.Core
{
    /// <summary>
    /// args[0]: Target project path
    /// </summary>
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                string projectPath;

                if (args.Length == 0)
                {
                    ConsoleHelper.ShowUsageHelp();
                    return -1;
                }
                else
                {
                    projectPath = args[0];
                }

                UpdateVersionNode(projectPath);

                return 1;

            }
            catch (Exception e)
            {
                ConsoleHelper.WriteLine(e.StackTrace, ConsoleColor.Red);
                throw;
            }
        }

        private static void UpdateVersionNode(string projectPath)
        {
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(projectPath);
            XmlNode root = xmldoc.DocumentElement;
            XmlNode versionNode = root.SelectSingleNode("PropertyGroup/Version");

            if (versionNode != null)
            {
                //Update Version
                var version = new Version(versionNode);
                version.Renew();
                versionNode.InnerText = version.ToString();
                xmldoc.Save(projectPath);

                ConsoleHelper.WriteLine($"Application version updated to {versionNode.InnerText}", ConsoleColor.Green);
            }
            else
            {
                //Create Base Version
                var verNode = xmldoc.CreateElement("Version");
                verNode.InnerText = "1.0.0.0";
                root.AppendChild(verNode);

                ConsoleHelper.WriteLine($"Application version created {verNode.InnerText}", ConsoleColor.Green);
            }
            
        }
    }
}
