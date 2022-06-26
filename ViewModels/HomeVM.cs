using System;
using System.Collections.Generic;
using FrontToBack.Models;

namespace FrontToBack.ViewModels
{
    public class HomeVM
    { 
        public IEnumerable<Slider> Sliders { get; set; }

        public PageIntro PageIntros { get; set; }

        public IEnumerable<Category>  Categories { get; set; }
        
    }
}
