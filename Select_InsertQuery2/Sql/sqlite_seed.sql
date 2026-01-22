INSERT INTO "Role" (Name, Description) VALUES
('Customer', 'Normaler Kunde'),
('Employee', 'Mitarbeiter'),
('Admin', 'Administrator');

INSERT INTO UserAccount
(Email, PasswordHash, IsActive, CreatedAt, LastLoginAt)
VALUES
('max@test.ch', 'hash123', 1, '2026-01-20', '2026-01-20');

INSERT INTO Customer
(FirstName, LastName, BirthDate, Phone, Street, Postal, City, Status, fk_RoleID, fk_UserAccountID)
VALUES
('Max', 'Muster', '2000-05-10', '0791112233',
 'Bahnhofstrasse 1', '8000', 'Zürich', 'active', 1, 1);

 INSERT INTO AccountType (Name, Currency, MonthlyFee)
VALUES ('Privatkonto', 'CHF', 5);

INSERT INTO Account
(IBAN, Balance, Status, OpenedAt, fk_AccountType)
VALUES
('CH9300762011623852957', 1000.50, 'open', '2026-01-01', 1);

INSERT INTO Card
(CardType, ExpiryDate, Status, DailyLimit, fk_AccountID)
VALUES
('Debit', '2029-12-31', 'active', 3000, 1);

INSERT INTO TransactionType (Name, Direction, Description)
VALUES
('Payment', '-', 'Zahlung'),
('Deposit', '+', 'Einzahlung');

INSERT INTO "Transaction"
(BookingDate, Description, fk_AccountID, fk_TransactionType)
VALUES
('2026-01-15', 'Migros', 1, 1);

INSERT INTO CustomerAccount (fk_CustomerID, fk_AccountID)
VALUES (1, 1);
