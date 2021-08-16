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

namespace Models {
    public sealed class Supplier : Person {

        #region Attributes

        private string phone;
        private string cuil;
        private string bussinessName;
        private string bussinessAddress;
        private string city;
        private int idVendor;

        #endregion

        #region Builders

        public Supplier() : base() { }

        public Supplier(short id, string name, string surname, string phone, string cuil, string bussinessName, string bussinessAddress, string city, int idVendor)
            : base(id, name, surname) {
            this.Phone = phone;
            this.Cuil = cuil;
            this.BussinessName = bussinessName;
            this.BussinessAddress = bussinessAddress;
            this.City = city;
            this.IdVendor = idVendor;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets/Sets the Phone of the customer.
        /// </summary>
        public string Phone {
            get => this.phone;
            set {
                //if (!String.IsNullOrWhiteSpace(value)) {
                this.phone = value;
                //}
            }
        }

        /// <summary>
        /// Gets/Sets the Cuil of the customer.
        /// </summary>
        public string Cuil {
            get => this.cuil;
            set {
                //if (!String.IsNullOrWhiteSpace(value)) {
                this.cuil = value;
                //}
            }
        }

        /// <summary>
        /// Gets/Sets the BussinessName of the customer.
        /// </summary>
        public string BussinessName {
            get => this.bussinessName;
            set {
                //if (!String.IsNullOrWhiteSpace(value)) {
                this.bussinessName = value;
                //}
            }
        }

        /// <summary>
        /// Gets/Sets the BussinessAddress of the customer.
        /// </summary>
        public string BussinessAddress {
            get => this.bussinessAddress;
            set {
                //if (!String.IsNullOrWhiteSpace(value)) {
                this.bussinessAddress = value;
                //}
            }
        }

        /// <summary>
        /// Gets/Sets the City of the customer.
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
        /// Gets/Sets the IdVendor of the customer.
        /// </summary>
        public int IdVendor {
            get => this.idVendor;
            set {
                if (value > 0) {
                    this.idVendor = value;
                }
            }
        }

        #endregion
    }
}
