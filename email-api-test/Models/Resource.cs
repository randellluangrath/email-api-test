
namespace email_api_test.Models
{
    public class Resource
    {
        public string Sid { get; set; }
        public string ParentCallSid { get; set; }
        public string DateCreated { get; set; }
        public string DateUpdated { get; set; }
        public string AccountSid { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string PhoneNumberSid { get; set; }
        public string Status { get; set; }
        public string StarTime { get; set; }
        public string EndTime { get; set; }
        public string Duration { get; set; }
        public string Price { get; set; }
        public string PriceUnit { get; set; }
        public string Direction { get; set; }
        public string AnsweredBy { get; set; }
        public string ForwardedFrom { get; set; }
        public string ToFormatted { get; set; }
        public string CallerName { get; set; }
        public string Uri { get; set; }
    }
}