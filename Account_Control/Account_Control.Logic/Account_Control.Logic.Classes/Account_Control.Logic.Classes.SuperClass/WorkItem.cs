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
        private string customerName;
        private DateTime workItemDate;
        private float workItemAmount;
        private short workItemIdCustomer;

        #endregion

        #region Builders

        /// <summary>
        /// Default builder for WorkItem.
        /// </summary>
        public WorkItem() {

        }

        /// <summary>
        /// Builder for WorkItem with all it's parameters.
        /// </summary>
        /// <param name="date">Date with format DateTime of the WorkItem.</param>
        /// <param name="id">ID of the WorkItem.</param>
        /// <param name="amount">Amount of the WorkItem.</param>
        /// <param name="idCustomer">ID of the customer associated with this WorkItem.</param>
        public WorkItem(DateTime date, short id, float amount, short idCustomer) : this() {
            this.WorkItemID = id;
            this.WorkItemDate = date;
            this.WorkItemAmount = amount;
            this.WorkItemIDCustomer = idCustomer;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets/Sets: the ID of the WorkItem.
        /// </summary>
        public short WorkItemID {
            get => this.workItemID;
            set {
                if (value > 0) {
                    this.workItemID = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets: the Date of the WorkItem.
        /// </summary>
        public DateTime WorkItemDate {
            get => this.workItemDate;
            set {
                this.workItemDate = value;
            }
        }

        /// <summary>
        /// Gets/Sets: the Customer's ID of the WorkItem.
        /// </summary>
        public short WorkItemIDCustomer {
            get => this.workItemIdCustomer;
            set {
                if (value > 0) {
                    this.workItemIdCustomer = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets: the Customer's Name of the WorkItem.
        /// </summary>
        public string CustomerName {
            get => this.customerName;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.customerName = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets: the Amount of the WorkItem.
        /// </summary>
        public float WorkItemAmount {
            get => this.workItemAmount;
            set {
                if (value >= 0) {
                    this.workItemAmount = value;
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
