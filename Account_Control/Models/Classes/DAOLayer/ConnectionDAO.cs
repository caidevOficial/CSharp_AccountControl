/*
 * MIT License
 * 
 * Copyright (c) 2021 [FacuFalcone]
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAOLayer {
    public static class ConnectionDAO {

        #region Attributes

        private static SqlConnection myConnection;
        private static SqlCommand myCommand;
        private static string connString;
        private static bool trustedConnection = true;
        private static string serverName = "localhost";
        private static string dbName = "AccountControl";

        #endregion

        #region Builders

        /// <summary>
        /// Basic Connection Builder
        /// </summary>
        static ConnectionDAO() {
            connString = $"Server = {serverName} ; Database = {dbName}; Trusted_Connection = {trustedConnection} ; ";
            myConnection = new SqlConnection(connString);
            myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;
        }

        #endregion

        #region Methods

        public static void Nothing() {

        }

        public static String GetTimestamp(DateTime value) {
            return value.ToString("yyyyMMddHHmmssffff");
        }

        #region Tickets_Related

        /// <summary>
        /// Creates a ticket in the DB.
        /// </summary>
        /// <param name="ticket">Ticket to be inserted into the db.</param>
        public static bool CreateTicket(Ticket ticket) {
            bool success = false;
            //String timestamp;
            try {
                myConnection.Open();
                if (!(ticket is null)) {
                    myCommand.CommandText = $"INSERT INTO Tickets Values(@Date, @id_Customer, @Amount);";
                    myCommand.Parameters.AddWithValue("@Date", ticket.WorkItemDate);
                    myCommand.Parameters.AddWithValue("@id_Customer", ticket.WorkItemIDCustomer);
                    myCommand.Parameters.AddWithValue("@Amount", Math.Round(ticket.WorkItemAmount, 2));
                    int rows = myCommand.ExecuteNonQuery();
                    success = true;
                } else {
                    throw new Exception();
                }
            } catch (Exception ex) {
                throw new Exception("No se pudo crear el ticket", ex);
            } finally {
                myCommand.Parameters.Clear();
                myConnection.Close();
            }

            return success;
        }

        public static void ReadAllTickets() {

        }

        public static void UpdateTicket() {

        }

        public static void DeleteTicket() {

        }

        #endregion

        #region Payments_Related

        /// <summary>
        /// Creates a Payment in the DB.
        /// </summary>
        /// <param name="payment">Payment to be inserted into the db.</param>
        public static bool CreatePayment(Payment payment) {
            bool success = false;
            try {
                myConnection.Open();
                myCommand.CommandText = $"INSERT INTO Payments Values(@Date,@IdCustomer,@Amount);";
                myCommand.Parameters.AddWithValue("@Date", payment.WorkItemDate);
                myCommand.Parameters.AddWithValue("@Amount", Math.Round(payment.WorkItemAmount, 2));
                myCommand.Parameters.AddWithValue("@IdCustomer", payment.WorkItemIDCustomer);
                int rows = myCommand.ExecuteNonQuery();
                success = true;
            } catch (Exception ex) {
                throw new Exception("No se pudo crear el Pago.", ex);
            } finally {
                myCommand.Parameters.Clear();
                myConnection.Close();
            }

            return success;
        }

        public static List<Payment> ReadAllPayments() {

            List<Payment> payments = new List<Payment>();
            Payment actualPayment;
            myCommand.CommandText = "Select * from Payments";
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            foreach (DataRow item in myDT.Rows) {
                float.TryParse(item["Amount"].ToString(), out float amount);
                actualPayment = new Payment(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                payments.Add(actualPayment);
            }
            //myReader.Close();
            myConnection.Close();

            return payments;
        }

        public static List<Payment> ReadAllPaymentsByCustomer(short idCustomer) {

            List<Payment> payments = new List<Payment>();
            Payment actualPayment;
            myCommand.CommandText = "Select * from Payments WHERE Id_Customer = @idCustomer";
            myCommand.Parameters.AddWithValue("@IdCustomer", idCustomer);
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            foreach (DataRow item in myDT.Rows) {
                float.TryParse(item["Amount"].ToString(), out float amount);
                actualPayment = new Payment(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                payments.Add(actualPayment);
            }
            myCommand.Parameters.Clear();
            //myReader.Close();
            myConnection.Close();

            return payments;
        }

        public static List<Payment> ReadAllPaymentsByDate(DateTime paymentDate) {

            List<Payment> payments = new List<Payment>();
            Payment actualPayment;
            myCommand.CommandText = "Select * from Payments WHERE Date = @paymentDate";
            myCommand.Parameters.AddWithValue("@paymentDate", paymentDate);
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            foreach (DataRow item in myDT.Rows) {
                float.TryParse(item["Amount"].ToString(), out float amount);
                actualPayment = new Payment(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                payments.Add(actualPayment);
            }
            myCommand.Parameters.Clear();
            //myReader.Close();
            myConnection.Close();

            return payments;
        }

        public static void UpdatePayment(Payment payment) {
            try {
                myConnection.Open();
                if (!(payment is null)) {
                    myCommand.CommandText = $"UPDATE Payments SET Date = @Date, Amount = @Amount, Id_Customer = @Id_Customer WHERE id = @id;";
                    myCommand.Parameters.AddWithValue("@Date", payment.WorkItemDate);
                    myCommand.Parameters.AddWithValue("@Amount", payment.WorkItemAmount);
                    myCommand.Parameters.AddWithValue("@Id_Customer", payment.WorkItemIDCustomer);
                    myCommand.Parameters.AddWithValue("@id", payment.WorkItemID);
                    int rows = myCommand.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                throw new Exception("Error", ex);
            } finally {
                myCommand.Parameters.Clear();
                myConnection.Close();
            }
        }

        public static void DeletePayment(short idPayment) {
            try {
                myConnection.Open();
                myCommand.CommandText = $"DELETE FROM Payments WHERE id=@id;";
                myCommand.Parameters.AddWithValue("@id", idPayment);
                int rows = myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                throw new Exception("Error", e);
            } finally {
                myCommand.Parameters.Clear();
                myConnection.Close();
            }
        }

        #endregion

        #region Customer_Related

        /// <summary>
        /// Creates a Customer in the DB.
        /// </summary>
        /// <param name="customer">Customer to be inserted into the db.</param>
        public static bool CreateCustomer(Customer customer) {
            bool success = false;
            try {
                myConnection.Open();
                if (!(customer is null)) {
                    myCommand.CommandText = $"INSERT INTO Customer Values(@Name, @Surname, @Phone, @Cuil, @Bussiness_Name, @Bussiness_Type, @Bussiness_Address, @City, @Id_Vendor);";
                    myCommand.Parameters.AddWithValue("@Name", customer.Name);
                    myCommand.Parameters.AddWithValue("@Surname", customer.Surname);
                    myCommand.Parameters.AddWithValue("@Phone", customer.Phone);
                    myCommand.Parameters.AddWithValue("@Cuil", customer.Cuil);
                    myCommand.Parameters.AddWithValue("@Bussiness_Name", customer.BussinessName);
                    myCommand.Parameters.AddWithValue("@Bussiness_Type", customer.BussinessType.ToString());
                    myCommand.Parameters.AddWithValue("@Bussiness_Address", customer.BussinessAddress);
                    myCommand.Parameters.AddWithValue("@City", customer.City);
                    myCommand.Parameters.AddWithValue("@Id_Vendor", customer.IdVendor);
                    int rows = myCommand.ExecuteNonQuery();
                    success = true;
                } else {
                    throw new Exception();
                }
            } catch (Exception ex) {
                throw new Exception(string.Format("No se pudo crear el cliente \"{0} {1}\".", customer.Name, customer.Surname), ex);
            } finally {
                myCommand.Parameters.Clear();
                myConnection.Close();
            }

            return success;
        }

        public static List<Customer> ReadAllCustomers() {
            List<Customer> customers = new List<Customer>();
            Customer actualCustomer;
            myCommand.CommandText = "Select * from Customer";
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            foreach (DataRow item in myDT.Rows) {
                Enum.TryParse(item["bussiness_type"].ToString(), out BussinessType bType);
                actualCustomer = new Customer(Convert.ToInt16(item["id"]), item["name"].ToString(), item["surname"].ToString(), item["phone"].ToString(), item["cuil"].ToString(), item["bussiness_name"].ToString(), bType, item["bussiness_address"].ToString(), Convert.ToInt16(item["id_vendor"]));
                customers.Add(actualCustomer);
            }
            //myReader.Close();
            myConnection.Close();

            return customers;
        }

        public static void UpdateCustomer() {

        }

        public static void DeleteCustomer() {

        }

        #endregion

        #region Vendors_Related

        /// <summary>
        /// Reads all vendors from the DB.
        /// </summary>
        /// <returns>A list of all vendors.</returns>
        public static List<Vendor> ReadAllVendors() {

            List<Vendor> vendors = new List<Vendor>();
            Vendor actualVendor;
            myCommand.CommandText = "Select * from Vendor";
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            foreach (DataRow item in myDT.Rows) {
                actualVendor = new Vendor(Convert.ToInt16(item["id"]), item["name"].ToString(), item["surname"].ToString());
                vendors.Add(actualVendor);
            }
            myReader.Close();
            myConnection.Close();

            return vendors;
        }

        #endregion

        #endregion
    }
}
