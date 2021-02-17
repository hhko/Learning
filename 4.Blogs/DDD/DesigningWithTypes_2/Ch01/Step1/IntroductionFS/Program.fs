// Learn more about F# at http://fsharp.org

open System
open Stage1
open Stage2

[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"

    // 타입 추론: 타입을 명시하지 않고 생성할 수 있다.
    // 레코드 타입: https://docs.microsoft.com/ko-kr/dotnet/fsharp/language-reference/records
    let stage1Contact = { 
            // 이름
            FirstName = "n1";
            MiddleInitial = "n2";
            LastName = "n3";

            // 메일
            EmailAddress = "e1";
            IsEmailVerified = false;

            // 주소
            Address1 = "a1";
            Address2 = "a2";
            City = "a3";
            State = "a4";
            Zip = "a5";
            IsAddressValid = false; 
        }

    // 이름
    let personalName = {
        FirstName = "n1";
        MiddleInitial = "n2";
        LastName = "n3";
    }

    // 메일
    let emailContactInfo = {
        EmailAddress = "e1";
        IsEmailVerified = false;
    }

    // 주소
    let postalAddress = {
        Address1 = "a1";
        Address2 = "a2";
        City = "a3";
        State = "a4";
        Zip = "a5";
    }

    let postalContactInfo = {
        Address = postalAddress;
        IsAddressValid = false;
    }

    let stage2Contact = {
        Name = personalName;
        EmailContactInfo = emailContactInfo;
        PostalContactInfo = postalContactInfo
    }

    0 // return an integer exit code
