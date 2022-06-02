using System;
using System.ComponentModel;

namespace GodelTourAgensy.Models
{
    public class TravelPackageViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Ф.И.О. клиента")]
        public string ClientId { get; set; }

        [DisplayName("Номер комнаты")]
        public int RoomId { get; set; }

        [DisplayName("Зарезервированно")]
        public bool BookingMark { get; set; }
        
        [DisplayName("Начало")]
        public DateTime StartDate { get; set; }

        [DisplayName("Конец")]
        public DateTime EndDate { get; set; }
    }
}
