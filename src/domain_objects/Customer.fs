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
    // ----- Value validation -----

let validateCustomerId (CustomerId id) =
    id <> Guid.Empty

let validateViaId (ViaId id) =
    not (isBlank id) && id.Length = 6

let validatePhoneNumber (PhoneNumber phone) =
    not (isBlank phone)
    && phone.Length = 8
    && (phone |> Seq.forall Char.IsDigit)

let validateEmail (Email e) =
    not (isBlank e)
    && e.Contains("@")
    && e.Contains(".")


let validateName (name: CustomerName) =
    not (isBlank name.FirstName)
    && not (isBlank name.LastName)

