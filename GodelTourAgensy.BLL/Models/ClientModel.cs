using System;

namespace GodelTourAgensy.BLL.Models
{
    public class ClientModel
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime Bithday { get; set; }

        public string Phone { get; set; }
    }
}
