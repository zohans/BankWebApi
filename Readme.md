Development Environment
Visual Studio 2019 and above
Dot Net 5

USER GUIDE
This Application provides simple web api to manage user and bank account

Running application steps:
1. Update BankContext connection strings in appsettings.json. e.g. server [ServerName]\\MSSQLSERVERDEV 
2. Build BankWebApplication.sln solution and Hit F5, and screen will show with local host url, e.g. https://localhost:44369/api/user. Note : this can be changed/adjusted later on
3. Bank Account Db be created.
4. Import Postman package can be used for testing.
5. Error will be log to C:\Temp\bank\logs. This can be customised in nlog.config.


Api lists:
1. Create user :           /api/user/create
2. Get user bank account : /api/bankaccount
3. Deposit :               /api/bankaccount/deposit
4. Withdraw :              /api/bankaccount/withdraw

Enjoy!

