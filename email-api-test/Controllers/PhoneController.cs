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

namespace email_api_test.Controllers
{
    public class PhoneController : TwilioController
    {   

        public ActionResult MakeCall()
        {

            var x = new ConfigurationUtility();

            var accountSid = x.TwilioAccountSid;
            var authToken = x.TwilioAuthToken;

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(x.MyPhoneNumber);
            var from = x.TwilioNumber;

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