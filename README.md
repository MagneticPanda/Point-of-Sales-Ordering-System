# Point of Sales Ordering System

### Navigation
<nav>
  <ol>
    <li><a href="#about">About</a></li>
    <ol>
      <li><a href="#old-operation">Old operation</a></li>
      <li><a href="#problems">Issues with old operation</a></li>
    </ol>
    <li><a href="#fes">Front-End System Overview</a></li>
    <li><a href="#website">Website Overview</a></li>
    <li><a href="#reporting">Reporting Overview</a></li>
  </ol>
</nav>

<section id="about">

## About
Information Technology becomes ever more prevalent in today’s world, characterised
by mobility, communication and connectivity. Information systems play a role in
enhancing operational efficiency and supporting decisions across all sectors.

As part of our final year major IT project, we were tasked with creating a _front end system_ and _website_ for a business which will provide some form of value to their establishment/organisation. These systems are aimed to produce as much data as possible to present reports and support business intelligence.
These deliverables were developed under an iterative agile methodology and presented in four major milestone presentations throughout the academic year.

We were able to have an IT company  play the role of our client, and setup a case study surrounding a canteen within one of their branches.
> **Disclaimer:** This project is not associated with the IT company in any way, and is **not** to be considered a product of the company. Their involvement in this project was simply limited to playing the role of a client.

<section id="old-operation">

### Brief overview of old canteen operation
Employees would head down to the canteen where they would place an order with
one of the available canteen staff members. The staff member would then look up the
pricing of those items and provide the employee with a receipt. The order would be
vocally relayed back to the chef and the employee would wait to receive their order.

</section>

<section id="problems">

### Main reasons underpinning the development of a new system
- Lengthy waiting times during peak hours
- Lack of decision making support surrounding aspects of the canteen
- No intergration of employee access cards or credit scheme
- Adherence to Covid-19 protocols
- General inefficincies resulting from mostly manual procedures

</section>

</section>

<section id="fes">

## Front-End System Overview
The front end system draws inspiration from kiosk stations, which is it's intended method of deployment within the canteen. It fully facilitates the ordering procedure for all employees, and multiple of these statitions can be setup in the canteen to eliminate lengthy queues. The system presents varaibale viewes, depending on the user group of the logged in user. This allows to system to additionally be deployed within the canteen's kitchen such that the pending orders along with their details are viewable to the logged in canteen staff members and they can begin working on servicing the order. 

| **Feature**                | **Short Description**                                                                                                                                                                                                                                           |
|:----------------------------:|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
|   Login - Access control   | All entities can login to the system using their respective credentials. These people include the canteen staff and the Dimension Data employees (which can be further subdivided by a management role). Each user group gets access to their respective pages. |
| Full ordering capabilities | Employees will be able to select their snack and/or drink items from a well-designed user interface, thereafter they can review their order and confirm for payment.                                                                                            |
|        Order history       | Employees can view their complete order history.                                                                                                                                                                                                                |
|      Order Fulfilment      | Canteen workers will be able to view their active order listings and prepare the orders based on their respective details. The system tracks the stages that an order goes through from being placed, ready, and finally collected.                             |
|       Item management      | The canteen manager(s) have control over creating, updating, reading, viewing, and archiving items.                                                                                                                                                             |
|  Credit System Management  | The canteen manager(s) have the ability to set the monthly credit limits for the employees.                                                                                                                                                                     |
|  Canteen Worker Management | Managers have full capabilities to add, archive, update and view the appropriate canteen workers' details.                                                                                                                                                      |
|          Reporting         | The system generates informative reports on various aspects such as sales, stock, canteen workers, and credits. These are all viewable through Power BI. Also included is a receipt that generates from the front-end system upon placing an order.             |

</section>

<section id="website">
  
## Website Overview
The website seeks to mobilise a subset of the functionality from the front-end system whilst also providing additional user experience enhancements.
These "on the go" featues provides the employees a more flexible and convenient way of placing their orders from the comfort of their work offices or current
surroundings.

|         **Feature**        |                                                              **Short Description**                                                              |
|:--------------------------:|-----------------------------------------------------------------------------------------------------------------------------------------------|
| Login - Access Control     | The employees can login to their system using their login credentials. Page access is further governed by employee roles.                       |
| Full Ordering Capabilities | Employees will be able to select their snack and/or drink items from the website interface, and review their order before payment confirmation. |
| Order History              | Employees can view their order history on their profile.                                                                                        |
| Item Management            | Managers have control over creating, updating, reading, and archiving items.                                                                    |
| Reporting                  | The website generates data in tandem with the front end system. These are externally accessed via Power BI.                                     |
</section>

<section id="reporting">
  
## Reporting Overview
Both systems generate plentiful data which can be used to create various reports to support smart decision making surrounding the various aspects of the canteen. Along with a traditional receipt and email confirmation upon placing an order, a dynamic reporting system was created in Power BI to display relevant information surrounding these areas namely: stock, canteen workers, sales, and credits.

| Sales Reporting Dashboard | Credit Reporting Dashboard |
|:-------------------------:|:--------------------------:|
|![Sales dashboard](https://user-images.githubusercontent.com/71750671/183264415-1bf46031-21cf-4edb-b601-322dbede8399.png)|![Credit dashboard](https://user-images.githubusercontent.com/71750671/183264413-497da64c-4f21-4d64-b2dd-28ac049ff048.png)|
| **Stock Reporting Dashboard** |  **Staff Reporting Dashboard** |
|![Stock dashboard](https://user-images.githubusercontent.com/71750671/183264418-5cbd59ec-0403-4b69-85f7-f830cb4a94f8.png)|![Staff dashboard](https://user-images.githubusercontent.com/71750671/183264417-09963f30-9f18-4cd5-a798-9a0920c6dcf7.png)|

> > **Disclaimer:** This project is not associated with the IT company in any way, and is **not** to be considered a product of the company. Their involvement in this project was simply limited to playing the role of a client. Inclusion of company logos was done simply to add to the presentation and realism/believability of the reporting dashboards.

</section>

### Miscellaneous
The MS SQL Server Databases are stored on behalf of the university. Access to these databases are closed off unless a request is made to unlock them for a brief time period. Should a demonstation of the systems working be needed, the necessary arrangements can be made.
