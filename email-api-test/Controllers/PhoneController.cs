using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using email_api_test.Utilities;
using email_api_test.Models;

namespace email_api_test.Controllers
{
    public class PhoneController : TwilioController
    {

        private readonly IConfigurationUtility _configurationUtility;

        public PhoneController(IConfigurationUtility config)
        {
            _configurationUtility = config;
        }

        public ActionResult MakeCall()
        {

            var accountSid = _configurationUtility.TwilioAccountSid;
            var authToken = _configurationUtility.TwilioAuthToken;

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(_configurationUtility.MyPhoneNumber);
            var from = _configurationUtility.TwilioNumber;

            var call = CallResource.Create(
                to: to,
                from: from,
                url: new Uri("http://demo.twilio.com/docs/voice.xml"));

            return Content(call.Sid);
        }

        [HttpPost]
        public ActionResult ReceiveCall()
        {
            var response = new VoiceResponse();
            response.Say("Hello");

            return TwiML(response);
        }




    }
}