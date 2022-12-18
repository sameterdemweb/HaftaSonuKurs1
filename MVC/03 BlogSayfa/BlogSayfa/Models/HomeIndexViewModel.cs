using BlogSayfa.Entities;

namespace BlogSayfa
{
    public class HomeIndexViewModel
    {
        public List<Slider> Sliderlar { get; set; }
        public List<Blog> Bloglar { get; set; }
        public List<Hizmetler> Hizmetler { get; set; }
    }
}