using System;
using System.Collections.Generic;
using FrontToBack.Models;

namespace FrontToBack.ViewModels
{
    public class HomeVM
    { 
        public IEnumerable<Slider> Sliders { get; set; }

        public PageIntro pageIntros { get; set; }

        public IEnumerable<Category>  categories { get; set; }
        
    }
}
