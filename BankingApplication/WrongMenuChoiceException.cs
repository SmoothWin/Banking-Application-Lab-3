using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApplication
{
    class WrongMenuChoiceException:ApplicationException
    {
        private string messageDetails = string.Empty;

        public DateTime ErrorTimeStamp { get; set; }

        public String causeOfError { get; set; }
        public WrongMenuChoiceException() { }

        public WrongMenuChoiceException(string message) : base(message) { }

        public WrongMenuChoiceException(string message, System.Exception inner) : base(message, inner) { }

        public WrongMenuChoiceException(string message, string cause, DateTime time)
        {
            messageDetails = message;
            causeOfError = cause;
            ErrorTimeStamp = time;
        }

        //override the Exception.Message property
        public override string Message
        {
            get
            {
                return string.Format("{0}|{1}: {2}", ErrorTimeStamp ,messageDetails,causeOfError);
            }
        }
    }
}
