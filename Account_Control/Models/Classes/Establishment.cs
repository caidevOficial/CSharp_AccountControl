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
        private BussinessType tipo;
        private List<Ticket> remitos;
        private List<Payment> payments;

        #endregion

        #region Builders

        private Establishment() {
            payments = new List<Payment>();
            remitos = new List<Ticket>();
        }

        public Establishment(short id, Customer owner, string name, string address, short numberAddress, string city, BussinessType tipo)
            : this() {
            this.ID = id;
            this.Owner = owner;
            this.Name = name;
            this.Address = address;
            this.AddressNumber = addressNumber;
            this.City = city;
            this.BussinessType = tipo;
        }

        #endregion

        #region Properties

        public short ID {
            get => this.id;
            set {
                if (value > 0) {
                    this.id = value;
                }
            }
        }

        public string Name {
            get => this.name;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.name = value;
                }
            }
        }

        public string Address {
            get => this.address;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.address = value;
                }
            }
        }

        public short AddressNumber {
            get => this.addressNumber;
            set {
                if (value > 0) {
                    this.addressNumber = value;
                }
            }
        }

        public string City {
            get => this.city;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.city = value;
                }
            }
        }

        public BussinessType BussinessType {
            get => this.tipo;
            set {
                if (value.GetType() == typeof(BussinessType)) {
                    this.tipo = value;
                }
            }
        }

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

        public static bool operator !=(Establishment e, Payment p) {
            return !(e == p);
        }

        public static Establishment operator +(Establishment e, Payment p) {
            if (!(e is null) && !(p is null)) {
                if (e != p) {
                    e.payments.Add(p);
                }
            }

            return e;
        }

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

        public static bool operator ==(Establishment e, Ticket p) {
            if (!(e is null) && !(p is null)) {
                foreach (Ticket item in e.remitos) {
                    if (item == p) {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator !=(Establishment e, Ticket p) {
            return !(e == p);
        }

        public static Establishment operator +(Establishment e, Ticket p) {
            if (!(e is null) && !(p is null)) {
                if (e != p) {
                    e.remitos.Add(p);
                }
            }

            return e;
        }

        public static Establishment operator -(Establishment e, Ticket p) {
            if (!(e is null) && !(p is null)) {
                if (e == p) {
                    e.remitos.Remove(p);
                }
            }

            return e;
        }

        #endregion

        #endregion

        #region Methods

        public double CalculateTotalPurchases() {
            double total = 0;
            foreach (Ticket item in this.remitos) {
                total += item.TicketAmount;
            }

            return Math.Round(total, 2);
        }

        public double CalculateTotalPayments() {
            double total = 0;
            foreach (Payment item in this.payments) {
                total += item.PaymentAmount;
            }

            return Math.Round(total, 2);
        }

        public double CalculateAccountState() {
            double state = CalculateTotalPurchases() - CalculateTotalPayments();

            return Math.Round(state, 2);
        }

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
