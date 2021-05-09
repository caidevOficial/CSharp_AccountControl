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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models {
    public sealed class Payments {

        #region Attributes

        private short paymentID;
        private DateTime paymentDate;
        private float paymentAmount;

        #endregion

        #region Builders

        public Payments(short id)
            : this(id, DateTime.Now) { }

        public Payments(short id, DateTime date)
            : this(id, date, 0) { }

        public Payments(short id, DateTime date, float amount) {
            this.PaymentID = id;
            this.PaymentDate = date;
            this.PaymentAmount = amount;
        }

        #endregion

        #region Properties

        public short PaymentID {
            get => this.paymentID;
            set {
                if (value > 0) {
                    this.paymentID = value;
                }
            }
        }

        public DateTime PaymentDate {
            get => this.paymentDate;
            set {
                this.paymentDate = value;
            }
        }

        public float PaymentAmount {
            get => this.paymentAmount;
            set {
                if (value >= 0) {
                    this.paymentAmount = value;
                }
            }
        }

        #endregion

        #region Operators

        public static bool operator ==(Payments p1, Payments p2) {
            if (!(p1 is null) && !(p2 is null)) {
                return p1.PaymentID == p2.PaymentID;
            }

            return false;
        }

        public static bool operator !=(Payments p1, Payments p2) {
            return !(p1 == p2);
        }

        #endregion

    }
}
