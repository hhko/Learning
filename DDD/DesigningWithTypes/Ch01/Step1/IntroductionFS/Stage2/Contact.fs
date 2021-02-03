module Stage2
    // module -> open

// 이름
type PersonalName = 
    {
        FirstName: string;
        // use "option" to signal optionality
        MiddleInitial: string; // option;
        LastName: string;
    }

// 메일
type EmailContactInfo = 
    {
        EmailAddress: string;
        // true if ownership of email address is confirmed
        IsEmailVerified: bool;
    }

// 주소
type PostalAddress = 
    {
        Address1: string;
        Address2: string;
        City: string;
        State: string;
        Zip: string;
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