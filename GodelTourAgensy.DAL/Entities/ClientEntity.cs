using System;

namespace GodelTourAgensy.DAL.Entities
{
    public class ClientEntity
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public DateTime Bithday { get; set; }

        public string Phone { get; set; }
    }
}