// Learn more about F# at http://fsharp.org

open System
open PrimitiveTypes
open Stage2

[<EntryPoint>]
let main argv =
    //// Stage 1 : Discriminated Unions
    //"x" |> constructedSingular
    //["a"; "b"; "c"] |> constructedPural 

    //"x1Let" 
    //|> EmailAddress
    //|> deconstructedSingular1Let        

    //"x2Pipe" 
    //|> EmailAddress
    //|> deconstructedSingular2Pipe

    //let x1 = "a" |> EmailAddress
    //x1 |> deconstructedSingular2Pipe
    
    //let address =
    //    ["a"; "b"; "c"]
    //    |> List.map EmailAddress

    //let address1 =
    //    address
    //    |> List.map (fun (EmailAddress e) -> e)
    //    |> printfn "%A"

    //
    // Stage 2: ...
    //
    let s1 = CreateStateCode "CA"
    let s2 = CreateStateCode "XX"
    
    let e1 = CreateEmailAddress "a@example.com"
    let e2 = CreateEmailAddress "example.com"
        
    0 // return an integer exit code
