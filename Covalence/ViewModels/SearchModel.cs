using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Covalence.ViewModels
{
    public class SearchViewModel
    {
        [Display(Name = "Tags")]
        public List<string> Tags { get; set; }
        public int? Page { get; set; }
        //TODO: Add Location
    }
}