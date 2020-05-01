module PrimitiveTypes

// Discriminated Unions
// https://docs.microsoft.com/ko-kr/dotnet/fsharp/language-reference/discriminated-unions
// constructed and deconstructed

type EmailAddress = EmailAddress of string
type ZipCode = ZipCode of string
type StateCode = StateCode of string

// 예 
// "x" |> constructedSingular
let constructedSingular value = 
    value
    |> EmailAddress
    |> printfn "%A"
        // %s for strings
        // %b for bools
        // %i for ints
        // %f for floats
        // %A for pretty-printing tuples, records and union types
        // %O for other objects, using ToString()

// 예
// ["a"; "b"; "c"] |> constructedPural 
let constructedPural values =
    values
    |> List.map EmailAddress
    |> printfn "%A"

// 예
// "a" |> EmailAddress |> deconstructedSingular1Let
let deconstructedSingular1Let value =
    let (EmailAddress a2) = value
    printfn "%s" a2

let deconstructedSingular2Pipe value =
    value 
    |> (fun (EmailAddress a2) -> a2)
    |> printfn "%s"
