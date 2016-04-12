using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OzTip.Models;

namespace OzTip.Web.Models.Search
{
    public class SearchResultsViewModel
    {
        public List<Competition> Competitions { get; set; }
        public string SearchString { get; set; }
    }
}