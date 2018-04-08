namespace email_api_test.Utilities
{
    public interface IConfigurationUtility
    {
        string TwilioAccountSid { get;  }
        string TwilioAuthToken { get; }
        string TwilioNumber { get;  }
        string MyPhoneNumber { get;  }
    }
}