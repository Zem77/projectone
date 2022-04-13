using System;
using System.Collections.Generic;
using System.Data.SqlClient;



namespace RistoranteSiciliano.Models
{
    public class OrderedProductsModel
    {
        #region
        public int id { get; set; }
        public int oid { get; set; }
        public int pdid { get; set; }
        #endregion

        SqlConnection con = new SqlConnection("server= LAPTOP-LS52TP6C\\TRAINERSINSTANCE; database= rsDB; integrated security=true");


        //GET ALL ORDERED ITEMS               
        public List<OrderedProductsModel> getAllCustomerOrders()
        {
            SqlCommand cmd_allcustomers = new SqlCommand("select * from OrderedProducts", con);
            List<OrderedProductsModel> customerlist = new List<OrderedProductsModel>();
            SqlDataReader readAllCustomers = null;
            try
            {
                con.Open();
                readAllCustomers = cmd_allcustomers.ExecuteReader(); //sql command executes work here and returns data in a list

                while (readAllCustomers.Read())
                {
                    customerlist.Add(new OrderedProductsModel()
                    {
                        id = Convert.ToInt32(readAllCustomers[0]),
                        oid = Convert.ToInt32(readAllCustomers[1]),
                        pdid = Convert.ToInt32(readAllCustomers[2]),

                    });
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllCustomers.Close();
                con.Close();
            }
            return customerlist;
        }



        //GET ALL ORDERED ITEMS FOR A CUSTOMER              
        public List<OrderedProductsModel> getACustomersOrders(int cid)
        {
            SqlCommand cmd_allcustomers = new SqlCommand("select oid, pdid from OrderedProducts JOIN(select id from Orders where cid=@cid) as OPO ON oid = OPO.id ", con);
            cmd_allcustomers.Parameters.AddWithValue("@cid", cid);
            List<OrderedProductsModel> customerlist = new List<OrderedProductsModel>();
            SqlDataReader readAllCustomers = null;
            try
            {
                con.Open();
                readAllCustomers = cmd_allcustomers.ExecuteReader(); //sql command executes work here and returns data in a list

                while (readAllCustomers.Read())
                {
                    customerlist.Add(new OrderedProductsModel()
                    {
                        id = Convert.ToInt32(readAllCustomers[0]),
                        oid = Convert.ToInt32(readAllCustomers[1]),
                        pdid = Convert.ToInt32(readAllCustomers[1]),

                    });
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllCustomers.Close();
                con.Close();
            }
            return customerlist;
        }



        //ADD A ORDERED PRODUCT
        public string addAOrderedProduct(int oid, int pid)
        {
            SqlCommand cmd_addOrderedProduct = new SqlCommand("insert into OrderedProducts values(@oid,@pid)", con);
            //cmd_addProduct.Parameters.AddWithValue("@pId",newProduct.productId); -- identity Column
            cmd_addOrderedProduct.Parameters.AddWithValue("@oid", oid);
            cmd_addOrderedProduct.Parameters.AddWithValue("@pid", pid);
            try
            {
                con.Open();
                cmd_addOrderedProduct.ExecuteNonQuery();
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


        //GET ONE PARTICULAR ORDER
        //GET ALL ORDERED ITEMS FOR A CUSTOMER              
        public List<OrderedProductsModel> getOneOrder(int id)
        {
            SqlCommand cmd_allcustomers = new SqlCommand("select oid, pdid from OrderedProducts JOIN(select id from Orders where id=@id) as OPO ON oid = OPO.id ", con);
            cmd_allcustomers.Parameters.AddWithValue("@id", id);
            List<OrderedProductsModel> customerlist = new List<OrderedProductsModel>();
            SqlDataReader readAllCustomers = null;
            try
            {
                con.Open();
                readAllCustomers = cmd_allcustomers.ExecuteReader(); //sql command executes work here and returns data in a list

                while (readAllCustomers.Read())
                {
                    customerlist.Add(new OrderedProductsModel()
                    {
                        id = Convert.ToInt32(readAllCustomers[0]),
                        oid = Convert.ToInt32(readAllCustomers[1]),
                        pdid = Convert.ToInt32(readAllCustomers[1]),

                    });
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllCustomers.Close();
                con.Close();
            }
            return customerlist;
        }




    }
}




