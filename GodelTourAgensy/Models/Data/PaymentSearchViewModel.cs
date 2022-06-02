using System;
using System.ComponentModel;

namespace GodelTourAgensy.Models.Data
{
    public class PaymentSearchViewModel
    {
        [DisplayName("Дата")]
        public DateTime Date { get; set; } = DateTime.Now;

        public bool IsEnabled { get; set; } = true;
    }
}
