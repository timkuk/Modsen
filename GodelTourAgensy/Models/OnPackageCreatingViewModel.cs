using GodelTourAgensy.DAL.Entities;
using System.Collections.Generic;

namespace GodelTourAgensy.Models
{
    public class OnPackageCreatingViewModel
    {
        public TravelPackageEntity Package { get; set; }
        public List<AdditionalServiceEntity> Services { get; set; }
        public AdditionalServiceEntity CurrentService { get; set; }
        public int Value { get; set; }

        public OnPackageCreatingViewModel()
        {
            Package = new();
            CurrentService = new();
            Services = new();
        }
    }
}
