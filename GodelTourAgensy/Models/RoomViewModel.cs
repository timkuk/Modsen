using System.ComponentModel;

namespace GodelTourAgensy.Models
{
    public class RoomViewModel
    {
        [DisplayName("ID комнаты")]
        public int Id { get; set; }

        [DisplayName("Номер")]
        public int Number { get; set; }

        [DisplayName("Цена")]
        public double Price { get; set; }
    }
}
