using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class Speaker
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public int? Experience { get; set; }
		public bool HasBlog { get; set; }
		public string BlogURL { get; set; }
		public WebBrowser Browser { get; set; }
		public List<string> Certifications { get; set; }
		public string Employer { get; set; }
		public int RegistrationFee { get; set; }
		public List<BusinessLayer.Session> Sessions { get; set; }

		public int? RegisterSpeaker(IRepository repository)
		{
            int? speakerId = null;
            if (string.IsNullOrWhiteSpace(FirstName)) throw new ArgumentNullException("First Name is required");
            if (string.IsNullOrWhiteSpace(LastName)) throw new ArgumentNullException("Last name is required.");
            if (string.IsNullOrWhiteSpace(Email)) throw new ArgumentNullException("Email is required.");
            if (!cumpleStandares()) throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
            if (Sessions.Count() == 0) throw new ArgumentException("Can't register speaker with no sessions to present.");
            if (!sessionsApproved()) throw new NoSessionsApprovedException("No sessions approved.");

            RegistrationFee = calcularRegistrationFee();
            
            try
		    {
			    speakerId = repository.SaveSpeaker(this);
		    }
		    catch (Exception e)
		    {
                throw new ArgumentException("Error: "+e.Message);
            }

			return speakerId;
		}
        public bool cumpleStandares()
        {
            var domains = new List<string>() { "aol.com", "hotmail.com", "prodigy.com", "CompuServe.com" };
            var employers = new List<string>() { "Microsoft", "Google", "Fog Creek Software", "37Signals" };
            if ((Experience > 10 || HasBlog || Certifications.Count() > 3 || employers.Contains(Employer)))
                return true;
            else
            {
                string emailDomain = Email.Split('@').Last();
                return !(domains.Contains(emailDomain) && ((Browser.Name == WebBrowser.BrowserName.InternetExplorer && Browser.MajorVersion < 9)));
            }
        }
        public bool sessionsApproved()
        {
            bool approved = false;
            var oldTecnologies = new List<string>() { "Cobol", "Punch Cards", "Commodore", "VBScript" };

            foreach (var session in Sessions)
            {
                foreach (var tech in oldTecnologies)
                {
                    session.Approved = !(session.Title.Contains(tech) || session.Description.Contains(tech));
                    if(session.Approved) approved = true;
                }
            }
            return approved;
        }
        public int calcularRegistrationFee()
        {
            int montoFee = 0;
            switch (Experience)
            {
                case 1:
                    montoFee = 500;
                    break;
                case 2:
                case 3:
                    montoFee = 250;
                    break;
                case 4:
                case 5:
                    montoFee = 100;
                    break;
                case 6:
                case 7:
                case 8:
                case 9:
                    montoFee = 50;
                    break;
            }
            return montoFee;
        }

        #region Custom Exceptions
        public class SpeakerDoesntMeetRequirementsException : Exception
		{
			public SpeakerDoesntMeetRequirementsException(string message)
				: base(message)
			{
			}

			public SpeakerDoesntMeetRequirementsException(string format, params object[] args)
				: base(string.Format(format, args)) { }
		}

		public class NoSessionsApprovedException : Exception
		{
			public NoSessionsApprovedException(string message)
				: base(message)
			{
			}
		}
		#endregion
	}
}