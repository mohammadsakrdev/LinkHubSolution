using LinkHubBOL;
using LinkHubDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHubBLL
{
    public class UrlBs
    {
        private UrlDb urldb;

        public UrlBs()
        {
            urldb = new UrlDb();
        }
        public IEnumerable<tbl_Url> GetAll()
        {
            return urldb.GetAll();
        }
        public tbl_Url GetByID(int id)
        {
            return urldb.GetByID(id);
        }
        public void Insert(tbl_Url url)
        {
            urldb.Insert(url);
        }
        public void Delete(int id)
        {
            urldb.Delete(id);
        }
        public void Update(tbl_Url url)
        {
            urldb.Update(url);
        }
        
    } // end class UrlBs
}
