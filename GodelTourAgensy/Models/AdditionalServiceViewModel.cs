using System.ComponentModel;

namespace GodelTourAgensy.Models
{
    public class AdditionalServiceViewModel
    {
        [DisplayName("ID услуги")]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Стоимость")]
        public double Price { get; set; }
    }
}