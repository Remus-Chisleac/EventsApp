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

        public static void AddDonation(Guid userId, Guid eventId, float amount)
        {
            DonationInfo donationInfo = new DonationInfo(userId, eventId, amount);
            _adapter.Add(donationInfo);
        }

        public static float GetTotalDonationsForEvent(Guid eventId)
        {
            float totalDonations = 0;
            foreach (DonationInfo donation in GetAllDonationsForEvent(eventId))
            {
                totalDonations += donation.amount;
            }
            return totalDonations;
        }

        public static List<DonationInfo> GetDonationsFromUser(Guid userId)
        {
            List<DonationInfo> donationsFromUser = new List<DonationInfo>();
            foreach (DonationInfo donation in GetAllDonations())
            {
                if (donation.userGUID == userId)
                {
                    donationsFromUser.Add(donation);
                }
            }
            return donationsFromUser;
        }

        public static void RemoveDonation(Guid donationId)
        {
            DonationInfo donationInfo = new DonationInfo(donationId);
            _adapter.Delete(donationInfo.GetIdentifier());
        }

        public static void RemoveAllDonationsForEvent(Guid eventId)
        {
            foreach (DonationInfo donation in GetAllDonationsForEvent(eventId))
            {
                _adapter.Delete(donation.GetIdentifier());
            }
        }
    }
}
