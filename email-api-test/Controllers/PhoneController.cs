using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Reflection;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.TwiML;
using Twilio.AspNet.Mvc;
using Twilio.Http;
using email_api_test.Utilities;
using email_api_test.Models;
using email_api_test.Logging;

namespace email_api_test.Controllers
{
    public class PhoneController : TwilioController
    {
        
        private readonly IConfigurationUtility _configurationUtility;

        public PhoneController(IConfigurationUtility config)
        {
            _configurationUtility = config;
        }
        
        public ActionResult MakeCall(Event rsc)
        {
            var accountSid = _configurationUtility.TwilioAccountSid;
            var authToken = _configurationUtility.TwilioAuthToken;

            TwilioClient.Init(accountSid, authToken);

            var to = new PhoneNumber(_configurationUtility.MyPhoneNumber);
            var from = _configurationUtility.TwilioNumber;
            var statusCallbackEvents = new List<string>() {
            "initiated",
            "ringing",
            "answered",
            "completed" };

            var call = CallResource.Create(
                 to: to,
                 from: from,
                 url: new Uri("http://demo.twilio.com/docs/voice.xml"),
                 method: new HttpMethod("GET"),
                 statusCallback: new Uri("https://b2e2d611.ngrok.io/phone/callback"),
                 statusCallbackMethod: new HttpMethod("POST"),
                 statusCallbackEvent: statusCallbackEvents);


            return Content(call.Sid);
        }

        [HttpPost]
        public ActionResult ReceiveCall(Event resource)
        {

            var accountSid = _configurationUtility.TwilioAccountSid;
            var authToken = _configurationUtility.TwilioAuthToken;

            TwilioClient.Init(accountSid, authToken);

            LogRequest(resource);

            var response = new VoiceResponse();
            response.Say($"What's poppin, you're calling from {resource.FromCity}, {resource.CalledState}.");

            return TwiML(response);

        }

        [HttpPost]
        public void Callback(Event resource)
        {
            LogRequest(resource);
        }

        private void LogRequest(Event evt)
        {
            PropertyInfo[] properties = evt.GetType().GetProperties();
            foreach (PropertyInfo e in properties)
            {
                Logger.Info($"{e}: {e.GetValue(evt)}");
            }
        }

    }
}