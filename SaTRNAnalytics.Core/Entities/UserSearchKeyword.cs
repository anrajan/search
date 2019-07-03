using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaTRNAnalytics.Core.Entities
{
   public class UserSearchKeyword
    {
        [Required]
        public string BemsID { get; set; }
        [Required]
        public string ProductName { get; set; }
    }
}
