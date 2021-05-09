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

namespace Models {
    public class Customer : Person {

        #region Attributes

        private string phone;
        private string cuil;

        #endregion

        #region Builders

        public Customer(short id, string name, string surname)
            : this(id, name, surname, "Sin Teléfono", "Sin Cuil") { }

        public Customer(short id, string name, string surname, string phone)
            : this(id, name, surname, phone, "Sin Cuil") { }

        public Customer(short id, string name, string surname, string phone, string cuil)
            : base(id, name, surname) {
            this.Phone = phone;
            this.Cuil = cuil;
        }

        #endregion

        #region Properties

        public string Phone {
            get => this.phone;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.phone = value;
                }
            }
        }

        public string Cuil {
            get => this.cuil;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.cuil = value;
                }
            }
        }

        #endregion

        #region Operators

        public static bool operator ==(Customer c1, Customer c2) {
            if (!(c1 is null) && !(c2 is null)) {
                return c1.ID == c2.ID;
            }

            return false;
        }

        public static bool operator !=(Customer c1, Customer c2) {
            return !(c1 == c2);
        }

        #endregion

        #region Methods

        #endregion
    }
}