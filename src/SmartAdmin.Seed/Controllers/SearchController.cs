using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nest;
using SmartAdmin.Seed.Data.Entity;
using SmartAdmin.Seed.Models.Search;

namespace SmartAdmin.Seed.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class SearchController : Controller
    {
        private readonly IElasticClient _client;
        public SearchController(IElasticClient client)
        {
            _client = client;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string SearchTerm)
        {
            var response =  _client.Search<Articles>(s => s
                .Index("articles")
                .Type("doc")
                .Size(10)
                .Query(q => q
                    .Match(m => m
                        .Field(f => f.Content)                        
                        .Query(SearchTerm)                    
                    )
                )
                .Aggregations(a => a
                    .Terms("uniq_url", t => t
                        .Field(o => o.Url)                        
                     )
                )
            );
            // var rawQuery = Encoding.UTF8.GetString(response.RequestInformation.Request);

            var model = new SearchResultViewModel
            {
                Took = response.Took,
                Total = response.Total,
                Results = response.Documents,
                SearchTerm = SearchTerm
                
            };

            return View(model);
        }

    }
}
