using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Menudemo.CONNECT;
using Menudemo.DTO;
using Microsoft.Isam.Esent.Interop.Vista;

namespace Menudemo.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;
        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set { instance = value; }
        }
        public static int TableWidth = 100;
        public static int TableHeight = 100;

        FoodDAO() { }
        public List<Food> GetFoodByCategory(int id) {
            List<Food> list = new List<Food>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from food where idCate=" + id + " and active =1");
            foreach (DataRow row in data.Rows)
            {
                Food food = new Food(row);
                list.Add(food);
            }
            return list;
        }
        public int Insert_Food(string name, int idCate, float price)
        {
            string sql = "insert into Food values(N'" + name + "'," + idCate + "," + price + ",1)";

            return DataProvider.Instance.ExecuteNonQuery(sql);
        }
        public int Update_Food(string name, int idCate, float price,int id)
        {
            string sql = "update Food set name= N'" + name + "',idCate= " + idCate + ", Price= " + price + " where id=" + id + "";


            return DataProvider.Instance.ExecuteNonQuery(sql);
        }
        public int Delete_Food(int idCate)
        {
            string sql = "Update   Food set active =0 where id=" + idCate + "";
            return DataProvider.Instance.ExecuteNonQuery(sql);
        }
        public DataTable GetFoodList(string textchange)
        {
            return DataProvider.Instance.ExecuteQuery("select [id] ,[name]   ,[idCate]     ,[Price]   from Food where name like N'%" + textchange + "%'and  active =1 ");
        }


    }
}
