using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.Seed.Data.Entity
{
    public class Sources
    {
        public int ID { get; set; }

        [Required]
        public string SourceName { get; set; }

        public int SourceTypeId { get; set; }

        public enum SourceType
        {
            News, Forum, Blog, Facebook, Twitter
        }

        [Required]
        public string SourceUrl { get; set; }

        [DisplayName("SourceConfiguration")]
        private string _SourceConfiguration;
        [NotMapped]
        public string[] SourceConfiguration
        {
            get { return JsonConvert.DeserializeObject<string[]>(this._SourceConfiguration); }
            set { _SourceConfiguration = JsonConvert.SerializeObject(value); }
        }

        public ICollection<Articles> Articles { get; set; }


    }
}
