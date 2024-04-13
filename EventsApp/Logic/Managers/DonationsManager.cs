using EventsApp.Logic.Adapters;
using EventsApp.Logic.Entities;
using EventsApp.Logic.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsApp.Logic.Managers
{
    public static class DonationsManager
    {
        private static DataAdapter<DonationInfo> _adapter;

        public static void Initialize(DataBaseAdapter<DonationInfo> adapter)
        {
            _adapter = adapter;
        }

        public static DonationInfo GetDonation(Guid donationId)
        {
            DonationInfo donationInfo = new DonationInfo(donationId);
            return _adapter.Get(donationInfo.GetIdentifier());
        }

        public static List<DonationInfo> GetAllDonations()
        {
            return _adapter.GetAll();
        }

        public static List<DonationInfo> GetAllDonationsForEvent(Guid eventId)
        {
            List<DonationInfo> donationsForEvent = new List<DonationInfo>();
            foreach (DonationInfo donation in GetAllDonations())
            {
                if (donation.eventGUID == eventId)
                {
                    donationsForEvent.Add(donation);
                }
            }
            return donationsForEvent;
        }

        public static void AddDonation(Guid userId, Guid eventId, float amountOfMoney)
        {
            DonationInfo donationInfo = new DonationInfo(userId, eventId, amountOfMoney);
            _adapter.Add(donationInfo);
        }
    }
}
