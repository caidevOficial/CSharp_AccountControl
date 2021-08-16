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
-- MAIN DATABASE
USE MASTER
GO
    CREATE DATABASE AccountControl
GO
    USE AccountControl
GO
    -- TABLE: VENDOR
    CREATE TABLE Vendors (
        id int IDENTITY(1, 1) NOT NULL,
        name varchar(50) NULL,
        surname varchar(50) NULL,
        username varchar(50) NOT NULL,
        password varchar(50) NOT NULL,
        CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED (id ASC) WITH (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON,
            OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
        ) ON [PRIMARY]
    ) ON [PRIMARY]
GO
    -- TABLE: CUSTOMER
    CREATE TABLE Customers (
        id int IDENTITY(1, 1) NOT NULL,
        name varchar(50) NULL,
        surname varchar(50) NULL,
        phone varchar(50) NULL,
        cuil varchar(50) NULL,
        bussiness_name varchar(50) NULL,
        bussiness_type varchar(50) NULL,
        bussiness_address varchar(50) NULL,
        city varchar(50) NULL,
        id_vendor int NOT NULL,
        CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED ([id] ASC) WITH (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON,
            OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
        ) ON [PRIMARY]
    ) ON [PRIMARY]
GO
ALTER TABLE
    Customers WITH CHECK
ADD
    CONSTRAINT [FK_Customer_Vendor] FOREIGN KEY([id_vendor]) REFERENCES Vendors ([id])
GO
ALTER TABLE
    Customers CHECK CONSTRAINT [FK_Customer_Vendor]
GO
     -- TABLE: SUPPLIER
    CREATE TABLE Suppliers (
        id int IDENTITY(1, 1) NOT NULL,
        name varchar(50) NULL,
        surname varchar(50) NULL,
        phone varchar(50) NULL,
        cuil varchar(50) NULL,
        bussiness_name varchar(50) NULL,
        bussiness_address varchar(50) NULL,
        city varchar(50) NULL,
        id_vendor int NOT NULL,
        CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED ([id] ASC) WITH (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON,
            OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
        ) ON [PRIMARY]
    ) ON [PRIMARY]
GO
ALTER TABLE
    Suppliers WITH CHECK
ADD
    CONSTRAINT [FK_Supplier_Vendor] FOREIGN KEY([id_vendor]) REFERENCES Vendors ([id])
GO
ALTER TABLE
    Suppliers CHECK CONSTRAINT [FK_Supplier_Vendor]
GO
   -- TABLE: PAYMENTS
    CREATE TABLE Payments (
        id int IDENTITY(1, 1) NOT NULL,
        Date datetime NOT NULL,
        id_customer int NOT NULL,
        amount float NOT NULL,
        CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED ([id] ASC) WITH (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON,
            OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
        ) ON [PRIMARY]
    ) ON [PRIMARY]
GO
ALTER TABLE
    Payments WITH CHECK
ADD
    CONSTRAINT [FK_Payments_Customer] FOREIGN KEY([id_customer]) REFERENCES Customers ([id])
GO
ALTER TABLE
    Payments CHECK CONSTRAINT [FK_Payments_Customer]
GO
    -- TABLE: TICKETS
    CREATE TABLE Tickets (
        [id] [int] IDENTITY(1, 1) NOT NULL,
        [Date] [datetime] NOT NULL,
        [id_customer] [int] NOT NULL,
        [amount] float NOT NULL,
        CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED ([id] ASC) WITH (
            PAD_INDEX = OFF,
            STATISTICS_NORECOMPUTE = OFF,
            IGNORE_DUP_KEY = OFF,
            ALLOW_ROW_LOCKS = ON,
            ALLOW_PAGE_LOCKS = ON,
            OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF
        ) ON [PRIMARY]
    ) ON [PRIMARY]
GO
ALTER TABLE
    Tickets WITH CHECK
ADD
    CONSTRAINT [FK_Tickets_Customer] FOREIGN KEY([id_customer]) REFERENCES Customers ([id])
GO
ALTER TABLE
    Tickets CHECK CONSTRAINT [FK_Tickets_Customer]
GO