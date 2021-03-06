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
    public abstract class Person {

        #region Attributes

        private short id;
        private string name;
        private string surname;

        #endregion

        #region Builders

        /// <summary>
        /// Default builder for Person.
        /// </summary>
        public Person() {

        }

        /// <summary>
        /// Builder of Person with all it's parameters.
        /// </summary>
        /// <param name="id">ID of the Person.</param>
        /// <param name="name">Name of the Person.</param>
        /// <param name="surname">Surname of the Person.</param>
        public Person(short id, string name, string surname) : this() {
            this.ID = id;
            this.Name = name;
            this.Surname = surname;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets/Sets: The ID of the Person.
        /// </summary>
        public short ID {
            get => this.id;
            set {
                if (value > 0) {
                    this.id = value;
                }
            }
        }

        /// <summary>
        /// Gets/Sets: The Name of the Person.
        /// </summary>
        public string Name {
            get => this.name;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.name = value;
                } else {
                    this.name = "Sin Nombre";
                }
            }
        }

        /// <summary>
        /// Gets/Sets: The Surname of the Person.
        /// </summary>
        public string Surname {
            get => this.surname;
            set {
                if (!String.IsNullOrWhiteSpace(value)) {
                    this.surname = value;
                } else {
                    this.surname = "Sin Apellido";
                }
            }
        }

        #endregion

    }
}
