using System.ComponentModel;

namespace GodelTourAgensy.Models.Data
{
    public class SearchViewModel
    {
        [DisplayName("Критерий")]
        public int FilterType { get; set; }

        [DisplayName("Ключ")]
        public string Value { get; set; }
    }
}
