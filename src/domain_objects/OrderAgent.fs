module PCLAssignment.domain_objects.OrderAgent

open PCLAssignment.domain_objects.Product
open PCLAssignment.domain_objects.Order

// Actor / MailboxProcessor
let gtgAgent =
    MailboxProcessor<OrderDrinkMsg>.Start(fun inbox ->

        let rec loop () =
            async {

                // Receive message
                let! msg = inbox.Receive()

                match msg with

                // Handle drink order
                | OrderDrink(drink, size) ->

                    // Build product
                    let product = Beverage(drink, size)

                    // Calculate price using Sprint 1 function
                    let price = calculatePrice product

                    // Apply VAT only for coffee
                    let finalPrice =
                        match drink.category with
                        | Coffee _ -> gtgVAT 25 price
                        | _ -> price

                    printfn "Please pay DKK %.2f for your drink. Thanks!" finalPrice


                // Handle comment message
                | LeaveComment text -> printfn "Thanks for your comment: %s" text

                return! loop ()
            }

        loop ())
