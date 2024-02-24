using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menudemo.CONNECT;
using Menudemo.DTO;

namespace Menudemo.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance 
        {
            get { if(instance==null) instance = new CategoryDAO(); return CategoryDAO.instance;}
            private set { CategoryDAO.instance = value; }
        }
        private CategoryDAO() { }
        public  List<Category> GetCategory()
        {
            List<Category> categories= new List<Category>();
            DataTable data= new DataTable();
            data = DataProvider.Instance.ExecuteQuery("Select * from FoodCate where active =1 ");
            foreach (DataRow row in data.Rows)
            {
                Category category = new Category(row);
                categories.Add(category);
            }
            return categories;
        }
        public int Insert_Cate(string category)
        {
            string sql = "Insert into FoodCate  values(N'" + category + "',1)";

            return DataProvider.Instance.ExecuteNonQuery(sql);
        }
        public int Update_Cate(string category, int categoryid)
        {
            string sql = "update FoodCate set name= N'" + category + "' where id=" + categoryid + "";


            return DataProvider.Instance.ExecuteNonQuery(sql);
        }
        public int Delete_Cate(int categoryid)
        {
            string sql = "update FoodCate set active=0 where id=" + categoryid + "";
            return DataProvider.Instance.ExecuteNonQuery(sql);
        }
        public DataTable GetCateList(string text)
            
        {
            return DataProvider.Instance.ExecuteQuery("select id,name from FoodCate where name like N'%" + text + "%' and active =1");
        }
    }
}
