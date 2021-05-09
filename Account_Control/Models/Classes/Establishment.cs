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

namespace Models {
    public sealed class Establishment {

        #region Attributes

        public enum BussinessType {
            Ferreteria,
            Corralon,
            CasaSanitarios,
            Particular
        }

        private short id;
        private string name;
        private string address;
        private short addressNumber;
        private string city;
        private Customer owner;
        private BussinessType tipo;
        //private List<Remito> remitos;
        private List<Payments> payments;

        #endregion

        #region Builders

        private Establishment() {
            payments = new List<Payments>();
        }

        public Establishment(short id, Customer owner, string name, string address, short numberAddress, string city, BussinessType tipo) {
            this.ID = id;
            this.Owner = owner;
            this.Name = name;
            this.Address = address;
            this.AddressNumber = addressNumber;
            this.City = city;
            this.Bussiness_Type = tipo;
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

        public Customer Owner {
            get => this.owner;
            set {
                if (!(value is null)) {
                    this.owner = value;
                }
            }
        }

        public BussinessType Bussiness_Type {
            get => this.tipo;
            set {
                if (value.GetType() == typeof(BussinessType)) {
                    this.tipo = value;
                }
            }
        }


        #endregion

        #region Operators

        public static bool operator ==(Establishment e, Payments p) {
            if (!(e is null) && !(p is null)) {
                foreach (Payments item in e.payments) {
                    if (item == p) {
                        return true;
                    }
                }
            }

            return false;
        }

        public static bool operator !=(Establishment e, Payments p) {
            return !(e == p);
        }

        public static Establishment operator +(Establishment e, Payments p) {
            if (!(e is null) && !(p is null)) {
                if (e != p) {
                    e.payments.Add(p);
                }
            }

            return e;
        }

        public static Establishment operator -(Establishment e, Payments p) {
            if (!(e is null) && !(p is null)) {
                if (e == p) {
                    e.payments.Remove(p);
                }
            }

            return e;
        }

        #endregion

        #region Methods

        #endregion
    }
}
