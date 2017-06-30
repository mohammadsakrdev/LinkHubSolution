using LinkHubBLL;
using LinkHubBOL;
using LinkHubDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHubBLL
{
    public class CategoryBs
    {
        private CategoryDb catdb;

        public CategoryBs()
        {
            catdb = new CategoryDb();
        }
        public IEnumerable<tbl_Category> GetAll()
        {
            return catdb.GetAll();
        }
        public tbl_Category GetByID(int id)
        {
            return catdb.GetByID(id);
        }
        public void Insert(tbl_Category category)
        {
            catdb.Insert(category);
        }
        public void Delete(int id)
        {
            catdb.Delete(id);
        }
        public void Update(tbl_Category category)
        {
            catdb.Update(category);
        }
    }
}
