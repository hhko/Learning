// Learn more about F# at http://fsharp.org

open System
open PrimitiveTypes

[<EntryPoint>]
let main argv =
    // Stage 1 
    // - using the constructor as a function
    let x = "a" |> EmailAddress

    "a" 
    |> EmailAddress
    |> printfn "%A"
        // %s for strings
        // %b for bools
        // %i for ints
        // %f for floats
        // %A for pretty-printing tuples, records and union types
        // %O for other objects, using ToString()

    ["a"; "b"; "c"]
    |> List.map EmailAddress
    |> printfn "%A"

    // - inline deconstruction
    let a1 = "a" |> EmailAddress
    let (EmailAddress a2) = a1
    printfn "%s" a2

    let address =
        ["a"; "b"; "c"]
        |> List.map EmailAddress

    let address1 =
        address
        |> List.map (fun (EmailAddress e) -> e)
        |> printfn "%A"
        
    0 // return an integer exit code
