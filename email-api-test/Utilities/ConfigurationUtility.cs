using System.Configuration;

namespace email_api_test.Utilities
{
    //This class provides a wrapper instance for the ConfigurationManager
    public class ConfigurationUtility: IConfigurationUtility
    {
        public string TwilioAccountSid => ConfigurationManager.AppSettings["TwilioAccountSid"];
        public string TwilioAuthToken => ConfigurationManager.AppSettings["TwilioAuthToken"];
        public string TwilioNumber => ConfigurationManager.AppSettings["TwilioNumber"];
        public string MyPhoneNumber => ConfigurationManager.AppSettings["MyPhoneNumber"];
    }
}