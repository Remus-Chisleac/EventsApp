using EventsApp.Logic.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Entities
{
    [Table("Users"), System.Serializable]
    public struct UserInfo
    {
        public const float MIN_SCORE = 4.0f;

        [PrimaryKey] public Guid GUID;
        public string name;
        public string password;

        public UserInfo(Guid guid, string name, string password)
        {
            GUID = guid;
            this.name = name;
            this.password = password;
        }

        public UserInfo(string name, string password)
        {
            GUID = Guid.NewGuid();
            this.name = name;
            this.password = password;
        }

        public UserInfo(Guid guid)
        {
            GUID = guid;
            name = "";
            password = "";
        }

        public UserInfo()
        {
            GUID = Guid.NewGuid();
            name = "";
            password = "";
        }
    }

    [Table("Events"), System.Serializable]
    public struct EventInfo
    {
        [PrimaryKey] public Guid GUID;
        public Guid organizerGUID;
        public string eventName;
        public string categories; // "music, sports, etc."
        public string location;
        public int maxParticipants;
        public string description;
        public DateTime startDate;
        public DateTime endDate;
        public string bannerURL;
        public string logoURL;
        public int ageLimit;
        public float entryFee;

        public EventInfo(Guid guid, Guid userGUID, string eventName, string categories, string location, int maxParticipants, string description, DateTime startDate, DateTime endDate, string bannerURL, string logoURL, int ageLimit, float entryFee)
        {
            GUID = guid;
            this.organizerGUID = userGUID;
            this.eventName = eventName;
            this.categories = categories;
            this.location = location;
            this.maxParticipants = maxParticipants;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.bannerURL = bannerURL;
            this.logoURL = logoURL;
            this.ageLimit = ageLimit;
            this.entryFee = entryFee;
        }

        public EventInfo(Guid userGUID, string eventName, string categories, string location, int maxParticipants, string description, DateTime startDate, DateTime endDate, string bannerURL, string logoURL, int ageLimit, float entryFee)
        {
            GUID = Guid.NewGuid();
            this.organizerGUID = userGUID;
            this.eventName = eventName;
            this.categories = categories;
            this.location = location;
            this.maxParticipants = maxParticipants;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.bannerURL = bannerURL;
            this.logoURL = logoURL;
            this.ageLimit = ageLimit;
            this.entryFee = entryFee;
        }

        public EventInfo(Guid guid)
        {
            GUID = guid;
            organizerGUID = Guid.Empty;
            eventName = "";
            categories = "";
            location = "";
            maxParticipants = 0;
            description = "";
            startDate = DateTime.Now;
            endDate = DateTime.Now;
            bannerURL = "";
            logoURL = "";
            ageLimit = 0;
            entryFee = 0;
        }
    }

    [Table("UsersEventsStatus"), System.Serializable]
    public struct UserEventRelationInfo
    {
        [PrimaryKey] public Guid userGUID;
        [PrimaryKey] public Guid eventGUID;
        public string status;

        public UserEventRelationInfo(Guid userGUID, Guid eventGUID, string status)
        {
            this.userGUID = userGUID;
            this.eventGUID = eventGUID;
            this.status = status;
        }

        public UserEventRelationInfo(Guid userGUID, Guid eventGUID)
        {
            this.userGUID = userGUID;
            this.eventGUID = eventGUID;
            status = "";
        }
    }

    [Table("Reports"), System.Serializable]
    public struct ReportInfo
    {
        [PrimaryKey] public Guid userGUID;
        [PrimaryKey] public Guid eventGUID;
        public enum ReportType
        {
            Harassment,
            Nudity,
            Spam,
            Violence,
            None,
            Fraud,
            Offensive,
            GuidelinesViolations
        }

        public ReportType reportType;

        public ReportInfo(Guid userGUID, Guid eventGUID, ReportType reportType)
        {
            this.userGUID = userGUID;
            this.eventGUID = eventGUID;
            this.reportType = reportType;
        }

        public ReportInfo(Guid userGUID, Guid eventGUID)
        {
            this.userGUID = userGUID;
            this.eventGUID = eventGUID;
            reportType = ReportType.Harassment;
        }

    }

    [Table("Reviews"), System.Serializable]
    public struct ReviewInfo
    {
        [PrimaryKey] public Guid userGUID;
        [PrimaryKey] public Guid eventGUID;
        public float score;
        public string reviewDescription;

        public ReviewInfo(Guid userGUID, Guid eventGUID, float score, string reviewDescription)
        {
            this.userGUID = userGUID;
            this.eventGUID = eventGUID;
            this.score = score;
            this.reviewDescription = reviewDescription;
        }

        public ReviewInfo(Guid userGUID, Guid eventGUID)
        {
            this.userGUID = userGUID;
            this.eventGUID = eventGUID;
            score = 0;
            reviewDescription = "";
        }
    }

    [Table("Expenses"), System.Serializable]
    public struct ExpenseInfo
    {
        [PrimaryKey] public Guid GUID;
        public Guid eventGUID;
        public string expenseName;
        public float cost;

        public ExpenseInfo(Guid guid, Guid eventGUID, string expenseName, float cost)
        {
            GUID = guid;
            this.eventGUID = eventGUID;
            this.expenseName = expenseName;
            this.cost = cost;
        }
    }

    [Table("Donations"), System.Serializable]
    public struct DonationInfo
    {
        [PrimaryKey] public Guid GUID;
        public Guid eventGUID;
        public Guid userGUID;
        public float amount;

        public DonationInfo(Guid guid, Guid eventGUID, Guid userGUID, float amount)
        {
            GUID = guid;
            this.eventGUID = eventGUID;
            this.userGUID = userGUID;
            this.amount = amount;
        }

        public DonationInfo(Guid eventGUID, Guid userGUID, float amount)
        {
            this.eventGUID = eventGUID;
            this.userGUID = userGUID;
            this.amount = amount;
            GUID = Guid.NewGuid();
        }

        public DonationInfo(Guid guid)
        {
            GUID = guid;
            eventGUID = Guid.Empty;
            userGUID = Guid.Empty;
            amount = 0;
        }
    }

    [Table("Admins"), System.Serializable]
    public struct AdminInfo
    {
        [PrimaryKey] public Guid GUID;

        public AdminInfo(Guid guid)
        {
            GUID = guid;
        }
    }
}
