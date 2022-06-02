using System;

namespace GodelTourAgensy.DAL.Entities
{
    public class TravelPackageEntity
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int RoomId { get; set; }

        public bool BookingMark { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(10);
    }
}
