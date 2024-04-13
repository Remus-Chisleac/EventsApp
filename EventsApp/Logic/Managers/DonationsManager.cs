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

        public static DonationInfo GetDonation(Guid donationId, Guid eventId)
        {
            DonationInfo donationInfo = new DonationInfo(donationId, eventId);
            return _adapter.Get(donationInfo.GetIdentifier());
        }

        public static List<DonationInfo> GetAllDonations()
        {
            return _adapter.GetAll();
        }
    }
}
