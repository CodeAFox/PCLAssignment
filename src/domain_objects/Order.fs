module PCLAssignment.domain_objects.Order

open System
open PCLAssignment.domain_objects.Customer
open PCLAssignment.domain_objects.Product
open PCLAssignment.domain_objects.Payment
open PCLAssignment.domain_objects.OrderStatus

type Order =
    { OrderId: Guid
      CustomerId: CustomerId
      Products: Product list
      Status: Status
      Payment: PaymentType }

type OrderDrinkMsg =
    | OrderDrink of DrinkRecord * SizeRecord
    | LeaveComment of string

type OrderProductMsg =
    | OrderProduct of Product * int
    | LeaveProductComment of string
