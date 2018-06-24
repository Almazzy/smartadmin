using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.Seed.Models.ManageViewModels
{
    public class TopicViewModel
    {
        public int ID { get; set; }
        public string TopicName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string[] Keywords { get; set; }
        public string Status { get; set; }
        public bool isFeatured { get; set; }
        public string[] SelectedSources { get; set; }
    }
}
