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
    public class Vendor : Person {

        #region Attributes

        private string username;
        private string password;

        #endregion

        #region Builders

        /// <summary>
        /// Builder with name, surname and id. It sets password and username as 'admin'
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        public Vendor(short id, string name, string surname)
            : this(id, name, surname, "admin", "admin") { }

        /// <summary>
        /// Full builder of a vendor.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public Vendor(short id, string name, string surname, string username, string password)
            : base(id, name, surname) {
            this.Username = username;
            this.Password = password;
        }

        #endregion

        #region Properties

        public string Username {
            get => this.username;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.username = value;
                }
            }
        }

        public string Password {
            get => this.password;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.password = value;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Shows id, name and surname of the vendor.
        /// </summary>
        /// <returns>id, name and surname of the vendor as a string.</returns>
        public override string ToString() {
            return $"{this.ID} {this.Name} {this.Surname}.";
        }

        #endregion
    }
}
