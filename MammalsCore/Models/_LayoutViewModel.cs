using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MammalsCore.Models
{
    public class _LayoutViewModel
    {
        [Required]
        private string searchQuery;
        [Required]
        public string SearchQuery { get => searchQuery; set => searchQuery = value; }
    }
}
