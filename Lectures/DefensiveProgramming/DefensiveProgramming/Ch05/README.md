# Chapter 5. Dismissing Defensive Code by Avoiding Primitive Types

## **배움**
1. Domain 데이터 타입과 Infrastrucutre 데이터 타입을 분리한다.
1. Domain 데이터 타입
   - 유효성 검사
   - 비교 기능 : Equals, GetHashCode 메서드 재정의
   - 영속성 인터페이스 제공
1. Infrastrucutre 데이터 타입
   - 영속성 데이터
   - 영속성 인터페이스 구현
1. CQRS와 MVVM 패턴
   - Model은 Command이다.
   - ViewModel은 Query이다(유효성 검사가 없다).

<br/>

## 5.1 The Reasons to Avoid Enumerations
- 주제 : enum 불안정한 타입
- 정수 임의의 값이 입력 가능하다.
- 내부 정보 값이 명확하지 않다. 

## 5.2 Alternatives to Enumerations
- 주제 : enum 객체화
- enum Grade -> public class Grade
- { A } -> { private Grade() {}, public static Grade A { get; }}
- x     -> IsPassing, Label, ... 

## 5.3 Converting Enumeration to a Class
- 주제 : enum -> class 변환
- 기존 유효성 검사는 null 검사만으로 처리한다.
- class 변환으로 기존에할 수 없었던 연산을 할 수 있다.

## 5.4 The Reasons to Never Stringify Data
- 주제 : 객체지향은 복잡한 기능을 수행하기 위해 함께 구성된 많은 작은 객체입니다.
- 요구사항을 기본타임이 아닌 비즈니스 타입으로 표현하자.
  - string name; vs. PersonalName name;

## 5.5 Reaping the Benefits of String Encapsulation
- 주제 : Euqals, GetHashCode 재정의
- 비교는 데이터 자체가 제공해야 한다.
  - 도메인 로직은 데이터에 가깝게 배치한다.

## 5.6 Avoiding Primitive Types Altogether
- 주제 : 기본 타입의 제약 조건
- 기본 타입은 불필요한 분기를 만든다(해결책을 제시하지 않는다).
- 지루하고 오류를 발생하기 쉬운 코드를 만든다.

## 5.7 Example: Modeling Money
- 주제 : Money, MoneyBag, PositiveMoney 클래스? 
- 끊임없이 추상화가 부족하다는 것을 인식해야 한다.

## 5.8 Persistence: Small-scale CQRS and DDD
- 주제 : CQRS와 Model vs. ViewModel
- Model은 Command이다.
- ViewModel은 Query이다(유효성 검사가 없다).

## 5.9 Demonstrating Persistence
- 주제 : Domain과 Infrastructure 분리
- Domain의 Professor는 비즈니스을 표현한다(영속성 관련 정보는 없다).
  - 영속성 인터페이스를 제공한다.
- Infrastructure의 Professor는 영속성(DB)을 표현한다.
  - 영속성 인터페이스를 구현한다.
  - Domain <-> Infrastructure 데이터 변환을 담당한다.