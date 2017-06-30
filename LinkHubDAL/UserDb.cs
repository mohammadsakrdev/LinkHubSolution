using LinkHubBOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkHubDAL
{
    public class UserDb
    {
        private LinkHubDbEntities db;
        public UserDb()
        {
            db = new LinkHubDbEntities();
        }
        public IEnumerable<tbl_User> GetAll()
        {
            return db.tbl_User.ToList();
        }
        public tbl_User GetByID(int id)
        {
            return db.tbl_User.Find(id);
        }
        public void Insert(tbl_User user)
        {
            db.tbl_User.Add(user);
            Save();
        }
        public void Delete(int id)
        {
            tbl_User user = db.tbl_User.Find(id);
            db.tbl_User.Remove(user);
        }
        public void Update(tbl_User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
