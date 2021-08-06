﻿/*
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAOLayer {
    public class ConnectionDAO : DAOAbstract, IDAOCRUD<Ticket>, IDAOCRUD<Payment> {

        #region Attributes

        private const string CREATE_VERB = "Creating";
        private const string UPDATE_VERB = "Updating";
        private const string DELETE_VERB = "Deleting";
        private const string READ_VERB = "Reading";

        #endregion

        #region Methods

        /// <summary>
        /// Creates an object and insert it into the DB.
        /// </summary>
        /// <param name="workItem">Entity to insert into the db.</param>
        /// <param name="typeEntity">Type of object to insert into the db.</param>
        /// <returns>True if can insert into the db, otherwise returns false.</returns>
        public bool Create(object workItem, EntityType typeEntity) {
            bool success = false;
            if (typeEntity is EntityType.Customer) {
                success = this.CreateCustomer((Customer)workItem);
            } else if (typeEntity is EntityType.Ticket) {
                success = ((IDAOCRUD<Ticket>)this).CreateObject((Ticket)workItem);
            } else {
                success = this.CreateObject((Payment)workItem);
            }

            return success;
        }

        #region Tickets_Related

        /// <summary>
        /// Creates a ticket in the DB.
        /// </summary>
        /// <param name="ticket">Ticket to be inserted into the db.</param>
        private bool CreateTicket(Ticket ticket) {
            bool success = false;
            string objectName = ticket.GetType().Name;
            try {
                if (!(ticket is null)) {
                    ConnectionDAO.MyConection.Open();
                    ConnectionDAO.MyCommand.CommandText = $"INSERT INTO Tickets Values(@Date, @id_Customer, @Amount);";
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Date", ticket.WorkItemDate);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@id_Customer", ticket.WorkItemIDCustomer);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Amount", Math.Round(ticket.WorkItemAmount, 2));
                    int rows = ConnectionDAO.MyCommand.ExecuteNonQuery();
                    success = true;
                } else {
                    throw new ArgumentNullException();
                }
            } catch (Exception ex) {
                throw new Exception($"Error {CREATE_VERB} {objectName}", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return success;
        }

        /// <summary>
        /// Gets a list of all tickets of the DB.
        /// </summary>
        /// <returns>A list of all tickets of the DB.</returns>
        public List<Ticket> ReadAllTickets() {
            List<Ticket> tickets = new List<Ticket>();
            Ticket actualTicket;
            ConnectionDAO.MyCommand.CommandText = "Select T.id, T.Date, T.id_customer, C.name, T.amount FROM Tickets as T, Customer as C WHERE C.id = T.id_customer";
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    float.TryParse(item["amount"].ToString(), out float amount);
                    actualTicket = new Ticket(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), item["name"].ToString(), amount, Convert.ToInt16(item["id_customer"]));
                    tickets.Add(actualTicket);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} tickets.", ex);
            } finally {
                ConnectionDAO.MyConection.Close();
            }

            return tickets;
        }

        /// <summary>
        /// Reads all tickets of customer id 'idCustomer'.
        /// </summary>
        /// <param name="idCustomer">ID of the customer to search it's tickets.</param>
        /// <returns>A list of tickets of the customer.</returns>
        public List<Ticket> ReadAllTicketsByCustomer(short idCustomer) {

            List<Ticket> payments = new List<Ticket>();
            Ticket actualTicket;
            ConnectionDAO.MyCommand.CommandText = "Select * from Tickets WHERE Id_Customer = @idCustomer";
            ConnectionDAO.MyCommand.Parameters.AddWithValue("@IdCustomer", idCustomer);
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    float.TryParse(item["Amount"].ToString(), out float amount);
                    actualTicket = new Ticket(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                    payments.Add(actualTicket);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} tickets.", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return payments;
        }

        /// <summary>
        /// Reads all Tickets of an specific date (DateTime).
        /// </summary>
        /// <param name="ticketDate">Date in DateTime format to search the Tickets.</param>
        /// <returns>A list of Tickets of an specific date.</returns>
        public List<Ticket> ReadAllTicketsByDate(DateTime ticketDate) {

            List<Ticket> tickets = new List<Ticket>();
            Ticket actualTicket;
            ConnectionDAO.MyCommand.CommandText = "Select T.id, T.Date, C.name, T.Amount from Tickets as T, Customers as C WHERE Date = @ticketDate AND C.id = T.id_customer";
            ConnectionDAO.MyCommand.Parameters.AddWithValue("@ticketDate", ticketDate);
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    float.TryParse(item["Amount"].ToString(), out float amount);
                    actualTicket = new Ticket(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), item["name"].ToString(), amount, Convert.ToInt16(item["Id_Customer"]));
                    tickets.Add(actualTicket);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} payments.", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return tickets;
        }

        public bool UpdateTicket() {
            bool success = false;

            return success;
        }

        public static void DeleteTicket() {

        }

        /// <summary>
        /// Creates a ticket in the DB.
        /// </summary>
        /// <param name="myObject">Ticket to be inserted into the db.</param>
        public bool CreateObject(Ticket myObject) {
            bool success = false;
            string objectName = myObject.GetType().Name;
            try {
                if (!(myObject is null)) {
                    ConnectionDAO.MyConection.Open();
                    ConnectionDAO.MyCommand.CommandText = $"INSERT INTO Tickets Values(@Date, @id_Customer, @Amount);";
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Date", myObject.WorkItemDate);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@id_Customer", myObject.WorkItemIDCustomer);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Amount", Math.Round(myObject.WorkItemAmount, 2));
                    int rows = ConnectionDAO.MyCommand.ExecuteNonQuery();
                    success = true;
                } else {
                    throw new ArgumentNullException();
                }
            } catch (Exception ex) {
                throw new Exception($"Error {CREATE_VERB} {objectName}", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return success;
        }

        /// <summary>
        /// Gets a list of all tickets of the DB.
        /// </summary>
        /// <returns>A list of all tickets of the DB.</returns>
        List<Ticket> IDAOCRUD<Ticket>.ReadAllObjects() {
            List<Ticket> tickets = new List<Ticket>();
            Ticket actualTicket;
            ConnectionDAO.MyCommand.CommandText = "Select T.id, T.Date, C.name, T.Amount from Tickets as T, Customers as C WHERE C.id = T.id_customer";
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    float.TryParse(item["Amount"].ToString(), out float amount);
                    actualTicket = new Ticket(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), item["name"].ToString() ,amount, Convert.ToInt16(item["Id_Customer"]));
                    tickets.Add(actualTicket);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} tickets.", ex);
            } finally {
                ConnectionDAO.MyConection.Close();
            }

            return tickets;
        }

        /// <summary>
        /// Reads all tickets of customer id 'idCustomer'.
        /// </summary>
        /// <param name="idCustomer">ID of the customer to search it's tickets.</param>
        /// <returns>A list of tickets of the customer.</returns>
        List<Ticket> IDAOCRUD<Ticket>.ReadAllObjectsByCustomer(short idCustomer) {
            List<Ticket> payments = new List<Ticket>();
            Ticket actualTicket;
            ConnectionDAO.MyCommand.CommandText = "Select * from Tickets WHERE Id_Customer = @idCustomer";
            ConnectionDAO.MyCommand.Parameters.AddWithValue("@IdCustomer", idCustomer);
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    float.TryParse(item["Amount"].ToString(), out float amount);
                    actualTicket = new Ticket(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                    payments.Add(actualTicket);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} tickets.", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return payments;
        }

        /// <summary>
        /// Reads all Tickets of an specific date (DateTime).
        /// </summary>
        /// <param name="ticketDate">Date in DateTime format to search the Tickets.</param>
        /// <returns>A list of Tickets of an specific date.</returns>
        List<Ticket> IDAOCRUD<Ticket>.ReadAllObjectsByDate(DateTime ticketDate) {
            List<Ticket> tickets = new List<Ticket>();
            Ticket actualTicket;
            ConnectionDAO.MyCommand.CommandText = "Select * from Tickets WHERE Date = @ticketDate";
            ConnectionDAO.MyCommand.Parameters.AddWithValue("@ticketDate", ticketDate);
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    float.TryParse(item["Amount"].ToString(), out float amount);
                    actualTicket = new Ticket(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                    tickets.Add(actualTicket);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} payments.", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return tickets;
        }

        #endregion

        #region Payments_Related

        /// <summary>
        /// Creates a Payment in the DB.
        /// </summary>
        /// <param name="payment">Payment to be inserted into the db.</param>
        private bool CreatePayment(Payment payment) {
            bool success = false;
            string objectName = payment.GetType().Name;
            try {
                if (!(payment is null)) {
                    ConnectionDAO.MyConection.Open();
                    ConnectionDAO.MyCommand.CommandText = $"INSERT INTO Payments Values(@Date,@IdCustomer,@Amount);";
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Date", payment.WorkItemDate);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Amount", Math.Round(payment.WorkItemAmount, 2));
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@IdCustomer", payment.WorkItemIDCustomer);
                    int rows = ConnectionDAO.MyCommand.ExecuteNonQuery();
                    success = true;
                }
            } catch (Exception ex) {
                throw new Exception($"Error {CREATE_VERB} {objectName}.", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return success;
        }

        /// <summary>
        /// Creates a Payment in the DB.
        /// </summary>
        /// <param name="myObject">Payment to be inserted into the db.</param>
        public bool CreateObject(Payment myObject) {
            bool success = false;
            string objectName = myObject.GetType().Name;
            try {
                if (!(myObject is null)) {
                    ConnectionDAO.MyConection.Open();
                    ConnectionDAO.MyCommand.CommandText = $"INSERT INTO Payments Values(@Date,@IdCustomer,@Amount);";
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Date", myObject.WorkItemDate);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Amount", Math.Round(myObject.WorkItemAmount, 2));
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@IdCustomer", myObject.WorkItemIDCustomer);
                    int rows = ConnectionDAO.MyCommand.ExecuteNonQuery();
                    success = true;
                }
            } catch (Exception ex) {
                throw new Exception($"Error {CREATE_VERB} {objectName}.", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return success;
        }

        /// <summary>
        /// Gets a list of all Payments of the DB.
        /// </summary>
        /// <returns>A list of all Payments of the DB.</returns>
        public static List<Payment> ReadAllPayments() {

            List<Payment> payments = new List<Payment>();
            Payment actualPayment;
            ConnectionDAO.MyCommand.CommandText = "Select * from Payments";
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            foreach (DataRow item in myDT.Rows) {
                float.TryParse(item["Amount"].ToString(), out float amount);
                actualPayment = new Payment(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                payments.Add(actualPayment);
            }
            ConnectionDAO.MyConection.Close();

            return payments;
        }

        /// <summary>
        /// Gets a list of all Payments of the DB.
        /// </summary>
        /// <returns>A list of all Payments of the DB.</returns>
        public List<Payment> ReadAllObjects() {
            List<Payment> payments = new List<Payment>();
            Payment actualPayment;
            ConnectionDAO.MyCommand.CommandText = "Select * from Payments";
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            foreach (DataRow item in myDT.Rows) {
                float.TryParse(item["Amount"].ToString(), out float amount);
                actualPayment = new Payment(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                payments.Add(actualPayment);
            }
            ConnectionDAO.MyConection.Close();

            return payments;
        }

        /// <summary>
        /// Reads all Payment of customer id 'idCustomer'.
        /// </summary>
        /// <param name="idCustomer">ID of the customer to search it's Payments.</param>
        /// <returns>A list of Payments of the customer.</returns>
        public List<Payment> ReadAllPaymentsByCustomer(short idCustomer) {

            List<Payment> payments = new List<Payment>();
            Payment actualPayment;
            ConnectionDAO.MyCommand.CommandText = "Select * from Payments WHERE Id_Customer = @idCustomer";
            ConnectionDAO.MyCommand.Parameters.AddWithValue("@IdCustomer", idCustomer);
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    float.TryParse(item["Amount"].ToString(), out float amount);
                    actualPayment = new Payment(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                    payments.Add(actualPayment);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} payments.", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return payments;
        }

        /// <summary>
        /// Reads all Payment of customer id 'idCustomer'.
        /// </summary>
        /// <param name="idCustomer">ID of the customer to search it's Payments.</param>
        /// <returns>A list of Payments of the customer.</returns>
        public List<Payment> ReadAllObjectsByCustomer(short idCustomer) {
            List<Payment> payments = new List<Payment>();
            Payment actualPayment;
            ConnectionDAO.MyCommand.CommandText = "Select * from Payments WHERE Id_Customer = @idCustomer";
            ConnectionDAO.MyCommand.Parameters.AddWithValue("@IdCustomer", idCustomer);
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    float.TryParse(item["Amount"].ToString(), out float amount);
                    actualPayment = new Payment(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                    payments.Add(actualPayment);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} payments.", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return payments;
        }

        /// <summary>
        /// Reads all Payment of an specific date (DateTime).
        /// </summary>
        /// <param name="paymentDate">Date in DateTime format to search the payments.</param>
        /// <returns>A list of payments of an specific date.</returns>
        public static List<Payment> ReadAllPaymentsByDate(DateTime paymentDate) {

            List<Payment> payments = new List<Payment>();
            Payment actualPayment;
            ConnectionDAO.MyCommand.CommandText = "Select * from Payments WHERE Date = @paymentDate";
            ConnectionDAO.MyCommand.Parameters.AddWithValue("@paymentDate", paymentDate);
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    float.TryParse(item["Amount"].ToString(), out float amount);
                    actualPayment = new Payment(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                    payments.Add(actualPayment);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} payments.", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return payments;
        }

        /// <summary>
        /// Reads all Payment of an specific date (DateTime).
        /// </summary>
        /// <param name="paymentDate">Date in DateTime format to search the payments.</param>
        /// <returns>A list of payments of an specific date.</returns>
        public List<Payment> ReadAllObjectsByDate(DateTime paymentDate) {
            List<Payment> payments = new List<Payment>();
            Payment actualPayment;
            ConnectionDAO.MyCommand.CommandText = "Select * from Payments WHERE Date = @paymentDate";
            ConnectionDAO.MyCommand.Parameters.AddWithValue("@paymentDate", paymentDate);
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    float.TryParse(item["Amount"].ToString(), out float amount);
                    actualPayment = new Payment(Convert.ToInt16(item["id"]), Convert.ToDateTime(item["Date"]), amount, Convert.ToInt16(item["Id_Customer"]));
                    payments.Add(actualPayment);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} payments.", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return payments;
        }

        public static void UpdatePayment(Payment payment) {
            string objectName = payment.GetType().Name;
            try {
                ConnectionDAO.MyConection.Open();
                if (!(payment is null)) {
                    ConnectionDAO.MyCommand.CommandText = $"UPDATE Payments SET Date = @Date, Amount = @Amount, Id_Customer = @Id_Customer WHERE id = @id;";
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Date", payment.WorkItemDate);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Amount", payment.WorkItemAmount);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Id_Customer", payment.WorkItemIDCustomer);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@id", payment.WorkItemID);
                    int rows = ConnectionDAO.MyCommand.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                throw new Exception($"Error {UPDATE_VERB} {objectName}", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }
        }

        public static void DeletePayment(short idPayment) {
            try {
                ConnectionDAO.MyConection.Open();
                ConnectionDAO.MyCommand.CommandText = $"DELETE FROM Payments WHERE id=@id;";
                ConnectionDAO.MyCommand.Parameters.AddWithValue("@id", idPayment);
                int rows = ConnectionDAO.MyCommand.ExecuteNonQuery();
            } catch (Exception e) {
                throw new Exception($"Error {DELETE_VERB} payment ID: {idPayment}", e);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }
        }

        #endregion

        #region Customer_Related

        /// <summary>
        /// Creates a Customer in the DB.
        /// </summary>
        /// <param name="customer">Customer to be inserted into the db.</param>
        private bool CreateCustomer(Customer customer) {
            bool success = false;
            string objectName = customer.GetType().Name;
            try {
                ConnectionDAO.MyConection.Open();
                if (!(customer is null)) {
                    ConnectionDAO.MyCommand.CommandText = $"INSERT INTO Customer Values(@Name, @Surname, @Phone, @Cuil, @Bussiness_Name, @Bussiness_Type, @Bussiness_Address, @City, @Id_Vendor);";
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Name", customer.Name);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Surname", customer.Surname);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Phone", customer.Phone);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Cuil", customer.Cuil);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Bussiness_Name", customer.BussinessName);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Bussiness_Type", customer.BussinessType.ToString());
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Bussiness_Address", customer.BussinessAddress);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@City", customer.City);
                    ConnectionDAO.MyCommand.Parameters.AddWithValue("@Id_Vendor", customer.IdVendor);
                    int rows = ConnectionDAO.MyCommand.ExecuteNonQuery();
                    success = true;
                } else {
                    throw new ArgumentNullException();
                }
            } catch (Exception ex) {
                throw new Exception($"Error {CREATE_VERB} {objectName} \"{customer.Name} {customer.Surname}\".", ex);
            } finally {
                ConnectionDAO.MyCommand.Parameters.Clear();
                ConnectionDAO.MyConection.Close();
            }

            return success;
        }

        public static List<Customer> ReadAllCustomers() {
            List<Customer> customers = new List<Customer>();
            Customer actualCustomer;
            ConnectionDAO.MyCommand.CommandText = "Select * from Customer";
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    Enum.TryParse(item["bussiness_type"].ToString(), out BussinessType bType);
                    actualCustomer = new Customer(Convert.ToInt16(item["id"]), item["name"].ToString(), item["surname"].ToString(), item["phone"].ToString(), item["cuil"].ToString(), item["bussiness_name"].ToString(), bType, item["bussiness_address"].ToString(), Convert.ToInt16(item["id_vendor"]));
                    customers.Add(actualCustomer);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} customers.", ex);
            } finally {
                ConnectionDAO.MyConection.Close();
            }

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
            ConnectionDAO.MyCommand.CommandText = "Select * from Vendor";
            ConnectionDAO.MyConection.Open();
            SqlDataReader myReader = ConnectionDAO.MyCommand.ExecuteReader();
            DataTable myDT = new DataTable();
            myDT.Load(myReader);
            try {
                foreach (DataRow item in myDT.Rows) {
                    actualVendor = new Vendor(Convert.ToInt16(item["id"]), item["name"].ToString(), item["surname"].ToString());
                    vendors.Add(actualVendor);
                }
            } catch (Exception ex) {
                throw new Exception($"Error {READ_VERB} vendors.", ex);
            } finally {
                ConnectionDAO.MyConection.Close();
            }

            return vendors;
        }

        #endregion

        #endregion
    }
}
