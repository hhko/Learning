# Chapter 5. Designing programs with function composition

## 5.1. Function composition

### 5.1.1. Brushing up on function composition
1. 함수 합성 정의
   - **h(x) = (f · g)(x) = f(g(x))**
1. 함수 합성 구현
   - **f 함수는 AppendDomain**, **g 함수는 AbbreviateName**라 가정하자.
     ```
     static string AbbreviateName(Person p)
        => Abbreviate(p.FirstName) + Abbreviate(p.LastName);

     static string AppendDomain(string localPart)
        => $"{localPart}@manning.com";

     static string Abbreviate(string s)
        => s.Substring(0, 2).ToLower();
     ```
   - **함수 합성(h 함수 有 - Func)** : ```emailfor```, ```AppendDomain(AbbreviateName(p));```
     ```
     Func<Person, string> emailFor = p => 
        AppendDomain(AbbreviateName(p));

     var joe = new Person("Joe", "Bloggs");
     var email = emailFor(joe);
     ```
   - **함수 합성(h 함수 無 - Extension Method)** : ```joe.AbbreviateName().AppendDomain();```
     ```
     var joe = new Person("Joe", "Bloggs");
     var email = joe.AbbreviateName().AppendDomain();

     static string AbbreviateName(this Person p)
        => Abbreviate(p.FirstName) + Abbreviate(p.LastName);

     static string AppendDomain(this string localPart)
        => $"{localPart}@manning.com";

     static string Abbreviate(string s)
        => s.Substring(0, 2).ToLower();
     ```   
1. 모나드에서 함수 합성 사용
   - Option 타입(컨테이너)와 Map 함수에서 함수 합성
     ```
     Func<Person, string> emailFor = p => 
        AppendDomain(AbbreviateName(p));

     var joe = Some(new Person("Joe", "Bloggs"));

     // 함수 합성(h 함수 有) : emailFor, AppendDomain(AbbreviateName(p))
     var email1 = joe.Map(emailFor);

     // 함수 합성(h 함수 無) : AbbreviateName.AppendDomain
     var email2 = joe.Map(AbbreviateName)
                     .Map(AppendDomain);

     Assert.AreEqual(email1, email2);
     ```
