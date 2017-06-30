using LinkHubBOL;
using LinkHubDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHubBLL
{
    public class UserBs
    {
        private UserDb userdb;

        public UserBs()
        {
            userdb = new UserDb();
        }
        public IEnumerable<tbl_User> GetAll()
        {
            return userdb.GetAll();
        }
        public tbl_User GetByID(int id)
        {
            return userdb.GetByID(id);
        }
        public void Insert(tbl_User user)
        {
            userdb.Insert(user);
        }
        public void Delete(int id)
        {
            userdb.Delete(id);
        }
        public void Update(tbl_User user)
        {
            userdb.Update(user);
        }
    }
}
