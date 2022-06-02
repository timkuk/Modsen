using System;

namespace GodelTourAgensy.BLL.Models
{
    public class  TravelPackageModel
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public int RoomId { get; set; }

        public bool BookingMark { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
