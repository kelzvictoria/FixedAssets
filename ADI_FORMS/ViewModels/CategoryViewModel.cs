using ADI_FORMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ADI_FORMS.ViewModels
{
    public class CategoryViewModel
    {
         public IEnumerable<Category> Categories { get; set; }
        public Category Category { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryViewModel()
        {
            Id = 0;
        }

        public CategoryViewModel(Category cat)
        {
            Id = cat.Id;
            Name = cat.Name;
        }

        public string Title
        {
            get{
                return "Category Definition";
            }
            
        }
    }
}