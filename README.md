Digital Banking & Financial System (Capstone)
A multi-layered C# Console Application designed to manage bank accounts, handle secure financial transactions, and provide administrative analytics using LINQ.

Features
Account Management: CRUD operations for Savings and Current accounts.

Transaction Engine: Secure Deposit, Withdrawal, and Atomic Transfers.

Advanced Analytics: Real-time financial reporting using LINQ.

Admin Control: System-wide monitoring and data reset capabilities.

Inheritance & System Design
The Inheritance Model
The system utilizes Class Inheritance to manage different account behaviors while maintaining a dry (Don't Repeat Yourself) codebase.

Account (Base Class): Contains universal properties like AccountNumber, AccountName, and Balance.

SavingsAccount (Derived): Extends the base class with an InterestRate property for long-term wealth management.

CurrentAccount (Derived): Adds an OverdraftLimit to allow transactions beyond a zero balance, simulating real-world business accounts.

Architecture: N-Tier Layered Approach
The project is built on a clean separation of concerns:

Models Layer: Defines the blueprints for data.

Service Layer: Contains the "Brain" of the app (Business Logic, Validations).

Data Layer: An in-memory DataStore that simulates a database environment.

UI Layer: A robust ConsoleApp that manages user interaction and input validation.

LINQ Analytics
The system performs high-level financial reporting without manual loops:

Global Liquidity: Sum() of all account balances.

Transaction Volume: GroupBy() logic to categorize transactions by type.

Risk Management: Where() filters to flag transactions exceeding $1,000.

Top Performers: OrderByDescending() and Take(5) to identify high-value clients.

 Validation Rules
Account Uniqueness: Prevents duplicate account numbers.

Transaction Integrity: Validates positive amounts and prevents illegal overdrafts.

Input Safety: Uses TryParse methods to prevent application crashes during user input.
