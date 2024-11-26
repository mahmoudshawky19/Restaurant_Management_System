using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using Table_Track.Models;
namespace Table_Track.Models
{   [PrimaryKey("MenuItemId", "ApplicationUserId")]


public class Cart
    {
         public int MenuItemId { get; set; }
        [ForeignKey(nameof(MenuItemId))]
        [ValidateNever]
        public MenuItem MenuItem { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey(nameof(ApplicationUserId))]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

        public int count { get; set; }

    }
}
