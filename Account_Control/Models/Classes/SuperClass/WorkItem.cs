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
    public abstract class WorkItem {

        #region Attributes

        private short workItemID;
        private DateTime workItemDate;
        private float workItemAmount;
        private short workItemIdCustomer;

        #endregion

        #region Builders

        public WorkItem(DateTime date, short id, float amount, short idCustomer) {
            this.WorkItemID = id;
            this.WorkItemDate = date;
            this.WorkItemAmount = amount;
            this.WorkItemIDCustomer = idCustomer;
        }

        #endregion

        #region Properties

        public short WorkItemID {
            get => this.workItemID;
            set {
                if (value > 0) {
                    this.workItemID = value;
                }
            }
        }

        public DateTime WorkItemDate {
            get => this.workItemDate;
            set {
                this.workItemDate = value;
            }
        }

        public float WorkItemAmount {
            get => this.workItemAmount;
            set {
                if (value >= 0) {
                    this.workItemAmount = value;
                }
            }
        }

        public short WorkItemIDCustomer {
            get => this.workItemIdCustomer;
            set {
                if (value > 0) {
                    this.workItemIdCustomer = value;
                }
            }
        }

        #endregion

        #region Operators

        #endregion

        #region Methods

        #endregion
    }
}
