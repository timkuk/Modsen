using System;
using System.ComponentModel;

namespace GodelTourAgensy.Models
{
    public class ClientViewModel
    {
        [DisplayName("ID заказа")]
        public int Id { get; set; }

        [DisplayName("Ф.И.О.")]
        public string FullName { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime Bithday { get; set; }
       
        [DisplayName("Телефон")]
        public string Phone { get; set; }
    }
}
