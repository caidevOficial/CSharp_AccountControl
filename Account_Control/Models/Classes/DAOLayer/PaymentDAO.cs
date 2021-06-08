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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLayer {
    public static class PaymentDAO {

        #region Attributes

        private static string connString;
        private static SqlConnection myConnection;
        private static SqlCommand myCommand;

        #endregion

        #region Builder

        static PaymentDAO() {
            connString = " Server = localhost ; Database = AccountControl; Trusted_Connection = true ; ";
            myConnection = new SqlConnection(connString);
            myCommand = new SqlCommand();
            myCommand.Connection = myConnection;
            myCommand.CommandType = CommandType.Text;
        }

        #endregion

        #region Methods

        public static void CreatePayment(Payment payment) {
            try {
                myConnection.Open();
                    myCommand.CommandText = $"INSERT INTO Payments Values(@Date,@Amount,@IdCustomer);";
                    myCommand.Parameters.AddWithValue("@Date", payment.WorkItemDate);
                    myCommand.Parameters.AddWithValue("@Amount", payment.WorkItemAmount);
                    myCommand.Parameters.AddWithValue("@IdCustomer", payment.WorkItemIDCustomer);
                    int rows = myCommand.ExecuteNonQuery();
                
            } catch (Exception ex) {
                throw new Exception("No se pudo crear el Pag..", ex);
            } finally {
                myConnection.Close();
            }
        }

        public static List<Payment> ReadAllPayments() {

            List<Payment> payments = new List<Payment>();
            Payment actualPayment;
            myCommand.CommandText = "Select * from Payments";
            myConnection.Open();
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read()) {
                float.TryParse(myReader["Amount"].ToString(), out float amount);
                actualPayment = new Payment(Convert.ToDateTime(myReader["Date"]), Convert.ToInt16(myReader["id"]), amount, Convert.ToInt16(myReader["Id_Customer"]));
                payments.Add(actualPayment);
            }
            myReader.Close();
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
            while (myReader.Read()) {
                float.TryParse(myReader["Amount"].ToString(), out float amount);
                actualPayment = new Payment(Convert.ToDateTime(myReader["Date"]), Convert.ToInt16(myReader["id"]), amount, Convert.ToInt16(myReader["Id_Customer"]));
                payments.Add(actualPayment);
            }
            myReader.Close();
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
            while (myReader.Read()) {
                float.TryParse(myReader["Amount"].ToString(), out float amount);
                actualPayment = new Payment(Convert.ToDateTime(myReader["Date"]), Convert.ToInt16(myReader["id"]), amount, Convert.ToInt16(myReader["Id_Customer"]));
                payments.Add(actualPayment);
            }
            myReader.Close();
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
                myConnection.Close();
            }
        }


        #endregion
    }
}
