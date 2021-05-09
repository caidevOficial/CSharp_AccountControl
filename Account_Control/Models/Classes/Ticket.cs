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
    public sealed class Ticket {

        #region Attributes

        private short ticketID;
        private DateTime ticketDate;
        private float ticketAmount;

        #endregion

        #region Builders

        public Ticket(short id)
            : this(id, DateTime.Now) { }

        public Ticket(short id, DateTime date)
            : this(id, date, 0) { }

        public Ticket(short id, DateTime date, float amount) {
            this.TicketID = id;
            this.TicketDate = date;
            this.TicketAmount = amount;
        }

        #endregion

        #region Properties

        public short TicketID {
            get => this.ticketID;
            set {
                if (value > 0) {
                    this.ticketID = value;
                }
            }
        }

        public DateTime TicketDate {
            get => this.ticketDate;
            set {
                this.ticketDate = value;
            }
        }

        public float TicketAmount {
            get => this.ticketAmount;
            set {
                if (value >= 0) {
                    this.ticketAmount = value;
                }
            }
        }

        #endregion

        #region Operators

        public static bool operator ==(Ticket t1, Ticket t2) {
            if (!(t1 is null) && !(t2 is null)) {
                return t1.TicketID == t2.TicketID;
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
