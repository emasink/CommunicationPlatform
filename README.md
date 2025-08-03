Here's a sample README file for the Communication Platform API:

**Communication Platform API**
==========================

**Overview**
---------------

The Communication Platform API is a RESTful API designed to manage customer communications. It provides a set of endpoints for creating, reading, updating, and deleting customers and templates, as well as sending emails.

**Features**
-------------

*   **Customer Management**: Create, read, update, and delete customers.
*   **Email Sending**: Send emails to customers using the EmailSender service.
*   **Template Management**: Create, read, update, and delete templates.

**Endpoints**
------------

*   `GET /{id}`: Retrieves a single customer/template by ID.
*   `GET /all`: Retrieves all customers/templates.
*   `POST /create`: Creates a new customer/template.

*   `PUT /update`: Updates an existing customer/template.
*   `DELETE /delete/{id}`: Deletes a customer/template by ID.

#### Customer Creation request
```json
{
  "name": "John",
  "email": "john@email.com"
}
```
#### Template Creation request
```json
{
  "name": "Demo Template",
  "subject": "Demo",
  "body": "Dear customer, we are happy to inform you took {{rank}} place in marathon"
}
```
N.B. template body can have placeholders for dynamic data, e.g., `{{name}}`. 
These placeholders will be replaced with actual data passed in `sendEmail` request body.
* `POST /sendEmail`: Sends an email to a customer using the EmailSender service.

    Restrictions for email template placeholders:
    *   Placeholders must be enclosed in double curly braces (e.g., `{{name}}`)
#### Sending email request
```json
{
  "customerId": 1,
  "templateId": 3,
  "placeholderValues": {
    "rank": "100"
  }
}
```
As a result, in the console of our API application, we should see the email output
```
 Email sent john@email.com
 Demo
 Dear customer, we are happy to inform you took 100 place in marathon
```

**Getting Started**
------------------

To get started with the Communication Platform API, follow these steps:

1.  Clone the repository.
2.  For the purpose of this application docker was utilised to run mssql server.
    * image pulled from Docker hub: `mcr.microsoft.com/mssql/server:2022-latest`
    * container ran with volume binding, port mapping and authentication 
    ```txt
    docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=<‘passwordFromConfig> \
    -p 8081:1433 --name CcmServer--hostname CcmSqlServer \
    -v /<LocalPath>:/var/opt/mssql/data \
    -v <LocalPath>:/var/opt/mssql/log \
    -v <LocalPath>:/var/opt/mssql/secrets \
    -v <LocalPath>:/var/opt/mssql/backups \
    -d mcr.microsoft.com/mssql/server:2022-latest
    ```
3. Start the API application by running `dotnet run` in the CommunicationPlatform.API  directory of the project.
**API Documentation**
--------------------

