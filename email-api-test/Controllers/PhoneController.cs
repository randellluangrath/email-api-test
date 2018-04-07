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


namespace email_api_test.Controllers
{
    public class PhoneController : TwilioController
    {   
        public ActionResult MakeCall()
        {

            const string accountSid = "ACb4d8125a394bb3bff1722bb106d88e4b";
            const string authToken = "25ab5db24e29c2b2cb6d1d1bc56ab110";

            /*
            var accountSid = ConfigurationManager.AppSettings["TwilioAccountSid"];
            var authToken = ConfigurationManager.AppSettings["TwilioAuthToken"];
            */

            TwilioClient.Init(accountSid, authToken);

            /*
            var to = new PhoneNumber(ConfigurationManager.AppSettings["MyPhoneNumber"]);
            var from = new PhoneNumber(ConfigurationManager.AppSettings["TwilioNumber"]);
            */

            var to = new PhoneNumber("+16157139341");
            var from = "+16153986052";

            var call = CallResource.Create(
                to: to,
                from: from,
                url: new Uri("http://demo.twilio.com/docs/voice.xml"));

            return Content(call.Sid);
        }


    }
}