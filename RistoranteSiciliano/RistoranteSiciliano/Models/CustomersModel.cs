using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RistoranteSiciliano.Models
{
    public class CustomersModel
    {
        #region Columns - Properties
        public int id { get; set; }
        public string cfname { get; set; }
        public string clname { get; set; }
        public string cemail { get; set; }
        public string cphone { get; set; }
        public string chaddress { get; set; }
        public int balance { get; set; }
        #endregion

        SqlConnection con = new SqlConnection("server= LAPTOP-LS52TP6C\\TRAINERSINSTANCE; database= rsDB; integrated security=true");

        //GET ALL CUSTOMERS FROM TABLE
        public List<CustomersModel> getAllCustomers()
        {
            SqlCommand cmd_allcustomers = new SqlCommand("select * from CustomerDetails", con);
            List<CustomersModel> customerlist = new List<CustomersModel>();
            SqlDataReader readAllCustomers = null;
            try
            {
                con.Open();
                readAllCustomers = cmd_allcustomers.ExecuteReader(); //sql command executes work here and returns data in a list

                while (readAllCustomers.Read())
                {
                    customerlist.Add(new CustomersModel()
                    {
                        id = Convert.ToInt32(readAllCustomers[0]),
                        cfname = readAllCustomers[1].ToString(),
                        clname = readAllCustomers[2].ToString(),
                        cemail = readAllCustomers[3].ToString(),
                        cphone = readAllCustomers[4].ToString(),
                        chaddress = readAllCustomers[5].ToString(),
                        balance = Convert.ToInt32(readAllCustomers[6])
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


        //GET A SINGLE CUSTOMER WITH KEY
        public CustomersModel getACustomersDetail(int id)
        {

            SqlCommand cmd_searchById = new SqlCommand("select * from CustomerDetails where id=@id", con);
            cmd_searchById.Parameters.AddWithValue("@id", id);
            SqlDataReader read_customer = null;
            CustomersModel customer = new CustomersModel();
            try
            {
                con.Open();
                read_customer = cmd_searchById.ExecuteReader(); //where the sqlcommand operates and returns data

                if (read_customer.Read()) //Data presented to Swagger here
                {
                    customer.id = Convert.ToInt32(read_customer[0]);
                    customer.cfname = read_customer[1].ToString();
                    customer.clname = read_customer[2].ToString();
                    customer.cemail = read_customer[3].ToString();
                    customer.cphone = read_customer[4].ToString();
                    customer.chaddress = read_customer[5].ToString();
                    customer.balance = Convert.ToInt32(read_customer[6]);
                }
                else
                {
                    throw new Exception("Customer Not Found");
                }
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                read_customer.Close();
                con.Close();
            }
            return customer;
        }


        //GET A CUSTOMER INVOICE
        public CustomersModel getACustomerInvoice(int cid)
        {

            SqlCommand cmd_searchById = new SqlCommand("SELECT SUM(pprice) as Prices FROM ProductDetails PPD JOIN(SELECT id FROM ProductDetails JOIN(SELECT pdid FROM OrderedProducts JOIN(SELECT id FROM Orders WHERE cid = @cid) AS OPO ON OPO.id = oid) AS PDOP ON PDOP.pdid = id) AS FINAL ON FINAL.id = PPD.id", con);
            cmd_searchById.Parameters.AddWithValue("@cid", cid);
            SqlDataReader read_customer = null;
            CustomersModel customer = new CustomersModel();
            try
            {
                con.Open();
                read_customer = cmd_searchById.ExecuteReader(); //where the sqlcommand operates and returns data

                if (read_customer.Read()) //Data presented to Swagger here
                {
                    //customer.id = Convert.ToInt32(read_customer[0]);
                    //customer.cfname = read_customer[1].ToString();
                    //customer.clname = read_customer[2].ToString();
                    //customer.cemail = read_customer[3].ToString();
                    //customer.cphone = read_customer[4].ToString();
                    //customer.chaddress = read_customer[5].ToString();
                    customer.balance = Convert.ToInt32(read_customer[0]);
                }
                else
                {
                    throw new Exception("Customer Not Found");
                }
            }
            catch (Exception es)
            {
                throw new Exception(/*es.Message + */"Type in a valid customer");

            }
            finally
            {
                read_customer.Close();
                con.Close();
            }
            return customer;
        }


        //ADD A CUSTOMER WITH INFO IN SWAGGER
        public string addACustomer(CustomersModel newCustomer)
        {
            SqlCommand cmd_addCustomer = new SqlCommand("insert into CustomerDetails values(@cfname,@clname,@cemail,@cphone,@chaddress,@balance)", con);
            //cmd_addProduct.Parameters.AddWithValue("@pId",newProduct.productId); -- identity Column
            cmd_addCustomer.Parameters.AddWithValue("@cfname", newCustomer.cfname);
            cmd_addCustomer.Parameters.AddWithValue("@clname", newCustomer.clname);
            cmd_addCustomer.Parameters.AddWithValue("@cemail", newCustomer.cemail);
            cmd_addCustomer.Parameters.AddWithValue("@cphone", newCustomer.cphone);
            cmd_addCustomer.Parameters.AddWithValue("@chaddress", newCustomer.chaddress);
            cmd_addCustomer.Parameters.AddWithValue("@balance", newCustomer.balance);

            

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
            return "Customer Added Successfully";
        }



    }
}