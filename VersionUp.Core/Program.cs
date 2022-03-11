using System;
using System.Diagnostics;
using System.Xml;

namespace VersionUp.Core
{
    /// <summary>
    /// args[0]: Target project path
    /// </summary>
    public class Program
    {
        public static int Main(string[] args)
        {
            try
            {
                string projectPath;

                if (args.Length == 0)
                {
                    ConsoleHelper.ShowUsageHelp();
                    return 1;
                }
                else
                {
                    projectPath = args[0];
                }

                UpdateVersionNode(projectPath);

                return 0;

            }
            catch (Exception e)
            {
                ConsoleHelper.WriteLine(e.StackTrace, ConsoleColor.Red);
                return 1;
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
                var versionNodeDetails = versionNode.InnerText.Split('.');
                var version = new Version(versionNodeDetails);
                version.Renew();
                versionNode.InnerText = version.ToString();

                ConsoleHelper.WriteLine("======================================================================", ConsoleColor.DarkRed);
                ConsoleHelper.WriteLine($"Application version updated to {versionNode.InnerText}", ConsoleColor.Green);
                ConsoleHelper.WriteLine("======================================================================", ConsoleColor.DarkRed);
            }
            else
            {
                //Create Base Version

                var propertyGroup = root.SelectSingleNode("PropertyGroup");
                XmlNode verNode = xmldoc.CreateElement("Version");
                verNode.InnerText = $"1.0.0.0";
                propertyGroup.AppendChild(verNode);
                ConsoleHelper.WriteLine("======================================================================", ConsoleColor.DarkRed);
                ConsoleHelper.WriteLine($"Application version created {verNode.InnerText}", ConsoleColor.Green);
                ConsoleHelper.WriteLine("======================================================================", ConsoleColor.DarkRed);
            }

            xmldoc.Save(projectPath);
        }
    }
}
