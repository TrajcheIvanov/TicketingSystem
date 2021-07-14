# TicketingSystem - MVC App
Ticketing system

A ticketing system is a management tool that processes and stores customer requests for a given case or issue. We want to create a ticketing system that will allow our users to create requests (tickets) for encountered issues while using our services.

Each ticket should be stored in a database with the following information:

Subject

Description

Date Created

Status (Pending, Processing, Done)

We have two users for our application:

Customer

Customer support

Customer use cases:

The Customer should be able to log in to our ticketing system. After login in the customer should be presented with a page where he can see all of the tickets created by him (if there are any).

In the same view the customer should be presented with the following options: Create new ticket On the “Create ticket” view the customer should be presented with a form where the following information can be entered: Subject

Description This data should be saved in a database along with information about the creation date and the status of the ticket (pending).

Delete existing ticket

When the customer clicks on a delete button for a given ticket, a confirmation pop up should appear so the customer can confirm the action

If confirmed the ticket should be deleted from the database

See details for existing ticket

In the Ticket details view the customer can see all of the data for the ticket along with the current status of the ticket.

In this view, there should be an option to change the status of the Ticket to Done

The customer can see all of the comments for this ticket created by Customer support (see section from customer support)

There should also be an option for the customer to leave a comment on the opened ticket

Customer support use cases:

Customer support user should be able to log in to our ticketing system.

After logging in the customer support should be presented with all tickets created from all customers ordered by date ascending.

In this view, the customer support user should be presented with an option to filter the tickets by status:

Pending

In process

Done

The customer support should have an option to see details for existing ticket:

In the Ticket details view, customer support should have the following options:

Change the status of the ticket to Pending, Processing or Done.

See all comments created for this ticket from Customer

Leave a comment on the opened ticket for the Customer.
