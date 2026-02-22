module PCLAssignment.domain_objects.Product

// Types of coffee
type Coffee =
    | Latte
    | Melange
    | Cappuccino

// Types of tea
type Tea = 
    | Oolong
    | GreenTea
    | Matcha
    | BlackTea
    | WhiteTea
    | Chai

// Types of juice
type Juice =
    | OrangeJuice
    | AppleJuice
    | GrapeJuice

// Drinks summarized
type Drink =
    | Coffee of Coffee
    | Tea of Tea
    | Juice of Juice

// Helper records for drinks to make price calculation easier
type DrinkRecord =
    {category: Drink; basePrice: double}

// Restrict sizes
type Size = 
    | Small
    | Medium
    | Large

// Helper for calculations
type SizeRecord =
    {size: Size; priceMultiplier: double}

// The product
type Product = 
    | Beverage of DrinkRecord * SizeRecord
    | Food of string * double
    | Fruit of string * double

let calculatePrice (item:Product) = 
    match item with 
        | Food(name, price) -> price 
        | Fruit(name, price) -> price
        | Beverage(drink, size) ->
            drink.basePrice * size.priceMultiplier