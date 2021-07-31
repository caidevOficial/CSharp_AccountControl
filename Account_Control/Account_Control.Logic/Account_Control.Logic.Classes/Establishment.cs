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

using System;
using System.Collections.Generic;
using System.Text;

namespace Models {
    public sealed class Establishment {

        #region Attributes

        private short id;
        private string name;
        private string address;
        private short addressNumber;
        private string city;
        private Customer owner;
        private BussinessType type;
        private readonly List<Ticket> tickets;
        private readonly List<Payment> payments;

        #endregion

        #region Builders

        /// <summary>
        /// Default Builder that initializes the lists.
        /// </summary>
        private Establishment() {
            payments = new List<Payment>();
            tickets = new List<Ticket>();
        }

        /// <summary>
        /// Builder for 'Establishment' with all it's params.
        /// </summary>
        /// <param name="id">ID of the Establishment</param>
        /// <param name="owner">Customer owner of the Establishment.</param>
        /// <param name="name">Name of the Establishment.</param>
        /// <param name="address">Address of the Establishment.</param>
        /// <param name="numberAddress">The address's number of the Establishment.</param>
        /// <param name="city">City of the Establishment.</param>
        /// <param name="type">Type of the Establishment.</param>
        public Establishment(short id, Customer owner, string name, string address, short numberAddress, string city, BussinessType type)
            : this() {
            this.ID = id;
            this.Owner = owner;
            this.Name = name;
            this.Address = address;
            this.AddressNumber = addressNumber;
            this.City = city;
            this.BussinessType = type;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets/Sets: The ID of the Establisment.
        /// </summary>
        public short ID {
            get => this.id;
            set {
                if (value > 0) {
                    this.id = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets: The Name of the Establisment.
        /// </summary>
        public string Name {
            get => this.name;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.name = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets: The Address of the Establisment.
        /// </summary>
        public string Address {
            get => this.address;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.address = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets: The AddressNumber of the Establisment.
        /// </summary>
        public short AddressNumber {
            get => this.addressNumber;
            set {
                if (value > 0) {
                    this.addressNumber = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets: The City of the Establisment.
        /// </summary>
        public string City {
            get => this.city;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.city = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets: The BussinessType of the Establisment.
        /// </summary>
        public BussinessType BussinessType {
            get => this.type;
            set {
                if (value.GetType() == typeof(BussinessType)) {
                    this.type = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets: The Customer Owner of the Establisment.
        /// </summary>
        public Customer Owner {
            get => this.owner;
            set {
                if (!(value is null)) {
                    this.owner = value;
                }
            }
        }

        #endregion

        #region Operators

        #region PaymentsRelated

        /// <summary>
        /// Compares if the Establishment have a payment or not.
        /// </summary>
        /// <param name="e">Establishment to check it's payments list.</param>
        /// <param name="p">Paymento to check in the Establisment payment's list.</param>
        /// <returns>True if exist the payment, otherwise returns false.</returns>
        public static bool operator ==(Establishment e, Payment p) {
            if (!(e is null) && !(p is null)) {
                foreach (Payment item in e.payments) {
                    if (item == p) {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Compares if the Establishment have a payment or not.
        /// </summary>
        /// <param name="e">Establishment to check it's payments list.</param>
        /// <param name="p">Paymento to check in the Establisment payment's list.</param>
        /// <returns>True if not exist the payment, otherwise returns false.</returns>
        public static bool operator !=(Establishment e, Payment p) {
            return !(e == p);
        }

        /// <summary>
        /// Try to add a payment into the Establishment payment's list.
        /// </summary>
        /// <param name="e">Establishment to check it's payments list.</param>
        /// <param name="p">Paymento to add in the Establisment payment's list.</param>
        /// <returns>The Establishment with the payment added if not exist, otherwise only will return the Establishment as it.</returns>
        public static Establishment operator +(Establishment e, Payment p) {
            if (!(e is null) && !(p is null)) {
                if (e != p) {
                    e.payments.Add(p);
                }
            }

            return e;
        }

        /// <summary>
        /// Try to remove a payment into the Establishment payment's list.
        /// </summary>
        /// <param name="e">Establishment to check it's payments list.</param>
        /// <param name="p">Paymento to add in the Establisment payment's list.</param>
        /// <returns>The Establishment withouth the payment if exist, otherwise only will return the Establishment as it.</returns>
        public static Establishment operator -(Establishment e, Payment p) {
            if (!(e is null) && !(p is null)) {
                if (e == p) {
                    e.payments.Remove(p);
                }
            }

            return e;
        }

        #endregion

        #region TicketsRelated

        /// <summary>
        /// Compares if the Establishment have a ticket or not.
        /// </summary>
        /// <param name="e">Establishment to check it's tickets list.</param>
        /// <param name="p">Paymento to check in the Establisment tickets's list.</param>
        /// <returns>True if exist the ticket, otherwise returns false.</returns>
        public static bool operator ==(Establishment e, Ticket p) {
            if (!(e is null) && !(p is null)) {
                foreach (Ticket item in e.tickets) {
                    if (item == p) {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Compares if the Establishment have a Ticket or not.
        /// </summary>
        /// <param name="e">Establishment to check it's Tickets list.</param>
        /// <param name="p">Paymento to check in the Establisment Tickets's list.</param>
        /// <returns>True if not exist the Ticket, otherwise returns false.</returns>
        public static bool operator !=(Establishment e, Ticket p) {
            return !(e == p);
        }

        /// <summary>
        /// Try to add a payment into the Establishment Ticket's list.
        /// </summary>
        /// <param name="e">Establishment to check it's Tickets list.</param>
        /// <param name="p">Paymento to add in the Establisment Tickets's list.</param>
        /// <returns>The Establishment with the Ticket added if not exist, otherwise only will return the Establishment as it.</returns>
        public static Establishment operator +(Establishment e, Ticket p) {
            if (!(e is null) && !(p is null)) {
                if (e != p) {
                    e.tickets.Add(p);
                }
            }

            return e;
        }

        /// <summary>
        /// Try to remove a payment into the Establishment Ticket's list.
        /// </summary>
        /// <param name="e">Establishment to check it's Tickets list.</param>
        /// <param name="p">Paymento to add in the Establisment Tickets's list.</param>
        /// <returns>The Establishment withouth the Ticket if exist, otherwise only will return the Establishment as it.</returns>
        public static Establishment operator -(Establishment e, Ticket p) {
            if (!(e is null) && !(p is null)) {
                if (e == p) {
                    e.tickets.Remove(p);
                }
            }

            return e;
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Calculates the total amount of purchased tickets.
        /// </summary>
        /// <returns>The total amount of purchased tickets, rounded with 2 decimals.</returns>
        public double CalculateTotalPurchases() {
            double total = 0;
            foreach (Ticket item in this.tickets) {
                total += item.WorkItemAmount;
            }

            return Math.Round(total, 2);
        }

        /// <summary>
        /// Calculates the total amount of payments.
        /// </summary>
        /// <returns>The total amount of payments, rounded with 2 decimals.</returns>
        public double CalculateTotalPayments() {
            double total = 0;
            foreach (Payment item in this.payments) {
                total += item.WorkItemAmount;
            }

            return Math.Round(total, 2);
        }

        /// <summary>
        /// Calculates the account state of the Establishment (TotalTickets - TotalPayments)
        /// </summary>
        /// <returns>The account state of the Establishment, rounded with 2 decimals.</returns>
        public double CalculateAccountState() {
            double state = (CalculateTotalPurchases() - CalculateTotalPayments());

            return Math.Round(state, 2);
        }

        /// <summary>
        /// Gets the Account info of the Establishment as a string.
        /// </summary>
        /// <returns>The Account info of the Establishment as a string.</returns>
        public string EstablishmentAccountInfo() {
            StringBuilder data = new StringBuilder();
            data.AppendLine("Bussiness Name\tPurchases\tPayments\tAccount State");
            data.Append($"{this.Name}\t");
            data.Append($"${CalculateTotalPurchases()}\t");
            data.Append($"${CalculateTotalPayments()}\t");
            data.AppendLine($"${CalculateAccountState()}\t");

            return data.ToString();
        }

        #endregion
    }
}
