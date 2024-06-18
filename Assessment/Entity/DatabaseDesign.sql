-- store user information 
CREATE TABLE Users (
    user_id INT NOT NULL IDENTITY(1, 1),
    username VARCHAR(50) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- store product information
CREATE TABLE Products (
    product_id INT NOT NULL IDENTITY(1, 1),
    product_name VARCHAR(100) NOT NULL,
    product_description TEXT,
    price DECIMAL(10, 2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- store general transaction information
CREATE TABLE Transactions (
    transaction_id INT NOT NULL IDENTITY(1, 1),
    user_id INT,
    transaction_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    total_amount DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (user_id) REFERENCES Users(user_id)
);

-- store details of each transaction
CREATE TABLE TransactionDetails (
    transaction_detail_id INT NOT NULL IDENTITY(1, 1),
    transaction_id INT,
    product_id INT,
    quantity INT NOT NULL,
    price_at_purchase DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (transaction_id) REFERENCES Transactions(transaction_id),
    FOREIGN KEY (product_id) REFERENCES Products(product_id)
);

-- Indexes to speed up queries
CREATE INDEX idx_user_id ON Transactions(user_id);
CREATE INDEX idx_transaction_id ON TransactionDetails(transaction_id);
CREATE INDEX idx_product_id ON TransactionDetails(product_id);
