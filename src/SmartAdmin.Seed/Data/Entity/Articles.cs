using Nest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartAdmin.Seed.Data.Entity
{
    [ElasticsearchType(Name = "doc")]
    public class Articles
    {
        //Data for index
        [NotMapped]
        public Guid esID { get; set; }
                    
        [NotMapped]
        [Text(Name = "title")]
        public string[] Title { get; set; }

        [NotMapped]
        [Text(Name = "content")]
        public string[] Content { get; set; }
        [NotMapped]
        [Text(Name = "description")]
        public string[] Description { get; set; }

        [NotMapped]
        [Keyword(Name = "url")]
        public string[] Url { get; set; }

        [NotMapped]
        [Date(Name = "modified")]
        public DateTime[] Modified { get; set; }

        //Data for database mapping
        public int ID { get; set; }

        [Required]
        public string articleTitle
        {
            get; set;
        }

        public string articleContent { get; set; }

        public string articleDescription { get; set; }

        [DisplayName("Tags")]
        private string _Tags { get; set; }
        [NotMapped]
        public string[] Tags
        {
            get { return _Tags.Split(","); }
            set { _Tags = string.Join(",", value); }
        }

        public string articleUrl { get; set; }

        public DateTime publishedDate { get; set; }

        public DateTime lastModified { get; set; }
    }
}
