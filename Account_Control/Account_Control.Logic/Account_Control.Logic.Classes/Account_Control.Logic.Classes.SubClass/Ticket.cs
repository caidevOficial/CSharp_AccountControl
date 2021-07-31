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
    public sealed class Ticket : WorkItem {

        #region Attributes

        #endregion

        #region Builders

        public Ticket(short id)
            : this(DateTime.Now, id) { }

        public Ticket(DateTime date, short id)
            : this(date, id, 0) { }

        public Ticket(DateTime date, float amount, short idCustomer)
            : this(0, date, amount, idCustomer) { }

        public Ticket(short id, DateTime date, float amount, short idCustomer)
            : base(date, id, amount, idCustomer) { }

        #endregion

        #region Properties

        #endregion

        #region Operators

        public static bool operator ==(Ticket t1, Ticket t2) {
            if (!(t1 is null) && !(t2 is null)) {
                return t1.WorkItemID == t2.WorkItemID;
            }

            return false;
        }

        public static bool operator !=(Ticket t1, Ticket t2) {
            return !(t1 == t2);
        }

        #endregion

        #region Methods

        #endregion
    }
}
