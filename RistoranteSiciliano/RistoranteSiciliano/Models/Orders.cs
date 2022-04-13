using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RistoranteSiciliano.Models
{
    public class Orders
    {
        #region Column - Properties
        public int id { get; set; }
        public string otime { get; set; }
        public int cid { get; set; }
        public int balance { get; set; }
        #endregion

        SqlConnection con = new SqlConnection("server= LAPTOP-LS52TP6C\\TRAINERSINSTANCE; database= rsDB; integrated security=true");


        //ADD A ORDER
        public string addAOrder(int cid)
        {
            SqlCommand cmd_addCustomer = new SqlCommand("insert into Orders values(GETDATE(),@cid,0)", con);
            //cmd_addProduct.Parameters.AddWithValue("@pId",newProduct.productId); -- identity Column
            cmd_addCustomer.Parameters.AddWithValue("@cid", cid);

            try
            {
                con.Open();
                cmd_addCustomer.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);

            }
            finally
            {
                con.Close();
            }
            return "Order Added Successfully";
        }


    }
}
