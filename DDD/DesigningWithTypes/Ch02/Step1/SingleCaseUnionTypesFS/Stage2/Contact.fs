module Stage2

// 이름
type PersonalName =
    {
        FirstName: string;
        // use "option" to signal optionality
        MiddleInitial: string; // option;
        LastName: string;
    }

type EmailAddress = EmailAddress of string

// 메일
type EmailContactInfo = 
    {
        EmailAddress: EmailAddress;
        // true if ownership of email address is confirmed
        IsEmailVerified: bool;
    }

type ZipCode = ZipCode of string
type StateCode = StateCode of string

// 주소
type PostalAddress = 
    {
        Address1: string;
        Address2: string;
        City: string;
        State: StateCode;
        Zip: ZipCode;
    }

type PostalContactInfo = 
    {
        Address: PostalAddress;
        // true if validated against address service
        IsAddressValid: bool;
    }

type Contact = 
    {
        // 이름
        Name: PersonalName;

        // 메일
        EmailContactInfo: EmailContactInfo;
    
        // 주소
        PostalContactInfo: PostalContactInfo;
    }

let CreateEmailAddress (s: string) =
    if System.Text.RegularExpressions.Regex.IsMatch(s, @"^\S+@\S+\.\S+$")
        then Some (EmailAddress s)
        else None

let CreateStateCode (s: string) = 
    let s' = s.ToUpper()
    let stateCodes = ["AZ"; "CA"; "NY"] // etc
    if stateCodes |> List.exists ((=) s')
        then Some (StateCode s')
        else None
