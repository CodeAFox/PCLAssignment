module PCLAssignment.domain_objects.Customer

type CustomerId = CustomerId of Guid
type ViaId = ViaId of string
type PhoneNumber = PhoneNumber of string
type Email = Email of string

type CustomerName =
    { FirstName: string
      LastName: string }

// Optional: future extension (room delivery for VIA customers)
type Campus =
    | Aarhus
    | Horsens
    | Randers
    | Online

type RoomDelivery =
    { Campus: Campus
      Building: string
      Room: string }

type DeliveryOption =
    | Pickup
    | DeliverToRoom of RoomDelivery


// Customers 
type ViaCustomerInfo =
    { CustomerId: CustomerId
      ViaId: ViaId
      Name: CustomerName
      Email: Email option
      Delivery: DeliveryOption }   // prepared for room delivery later

type GuestInfo =
    { CustomerId: CustomerId
      Name: CustomerName
      Phone: PhoneNumber option
      Email: Email option
      Delivery: DeliveryOption }   

type Customer =
    | VIAStaff of ViaCustomerInfo
    | VIAStudent of ViaCustomerInfo
    | Guest of GuestInfo