using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHubBLL
{
    public class BaseBs
    {
        public CategoryBs CategoryBs { get; set; }
        public UserBs UserBs { get; set; }
        public UrlBs UrlBs { get; set; }

        public BaseBs()
        {
            CategoryBs = new CategoryBs();
            UrlBs = new UrlBs();
            UserBs = new UserBs();
        }
    } // end class BaseBs
}
