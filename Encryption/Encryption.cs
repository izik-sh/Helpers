using System.Configuration;
using System.Diagnostics;

namespace Encryption
{
    public class Encryption
    {

    }

    public class ConnectionProtection
    {
        public string FileName { get; set; }
        /// <summary>
        /// Determine if configuration file exists for application
        /// </summary>
        /// <param name="FileName">Current executable and path</param>
        public ConnectionProtection(string FileName)
        {
            if (!File.Exists(string.Concat(FileName, ".config")))
            {
                throw new FileNotFoundException(string.Concat(FileName, ".config"));
            }

            this.FileName = FileName;
        }
        /// <summary>
        /// Encrypt ConnectionString
        /// </summary>
        /// <param name="encrypt"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool EncryptConnectionString(bool encrypt, string? fileName = "")
        {
            fileName = Path.GetDirectoryName(Environment.ProcessPath);

            bool success = true;

            try
            {
                System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(fileName);
                ConfigurationSection? configSection = configuration.GetSection("connectionStrings") as ConnectionStringsSection;

                if ((!configSection.ElementInformation.IsLocked) && (!(configSection.SectionInformation.IsLocked)))
                {
                    if (encrypt && (!configSection.SectionInformation.IsProtected))
                    {
                        // encrypt the file
                        configSection.SectionInformation.ProtectSection("DataProtectionConfigurationProvider");
                    }

                    if ((!encrypt) && configSection.SectionInformation.IsProtected) //encrypt is true so encrypt
                    {
                        // decrypt the file. 
                        configSection.SectionInformation.UnprotectSection();
                    }

                    configSection.SectionInformation.ForceSave = true;
                    configuration.Save();

                    success = true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                success = false;
            }

            return success;

        }
        public bool IsProtected()
        {
            System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(FileName);
            var configSection = configuration.GetSection("connectionStrings") as System.Configuration.ConnectionStringsSection;
            return configSection.SectionInformation.IsProtected;
        }
        public bool EncryptFile()
        {
            if (File.Exists(FileName))
            {
                return EncryptConnectionString(true, FileName);
            }
            else
            {
                return false;
            }
        }
        public bool DecryptFile()
        {
            if (File.Exists(FileName))
            {
                return EncryptConnectionString(false, FileName);
            }
            else
            {
                return false;
            }
        }
    }
}