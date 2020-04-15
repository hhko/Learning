module Stage1

type Contact = 
    {
        // 이름
        FirstName: string;
        // use "option" to signal optionality
        MiddleInitial: string;
        LastName: string;

        // 메일
        EmailAddress: string;
        // true if ownership of email address is confirmed
        IsEmailVerified: bool;

        // 주소
        Address1: string;
        Address2: string;
        City: string;
        State: string;
        Zip: string;
        // true if validated against address service
        IsAddressValid: bool; 
    }