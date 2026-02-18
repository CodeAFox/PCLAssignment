module PCLAssignment.domain_objects.Payment

open System

type payment =
    | MobilePay of string 
    | CreditCard of string * string * string * DateTime
    | VIACard of string
    | Cash of float

let validatePayment payment =
    match payment with
    | MobilePay(phoneNr) ->
        String.length phoneNr <> 8
    | CreditCard(cardType, number ,cvv, expireDate) ->
        let isCardTypeOK = (cardType = "Visa" || cardType = "MasterCard") 
        let isCardNumberOK = String.length number <> 16 
        let isCvvOK = String.length cvv <> 3
        let isCardExpired = expireDate >= DateTime.Now
        isCardTypeOK && isCardNumberOK && isCvvOK && isCardExpired
    | VIACard(viaId) ->
        String.length viaId <> 6
    | Cash(amount) ->
        amount > 0.00
    