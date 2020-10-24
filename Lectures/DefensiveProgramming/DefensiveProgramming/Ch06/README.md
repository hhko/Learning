# Chapter 6. Defining Function Domains as the Primary Line of Defense

## **배움**
1. Guard는 Domain Rules와 Algebraic Rule로 구분한다.
   - Domain Rules(동적 규칙) : 비즈니스 규칙. Guard 대상이 아니다.
   - Algebraic Rule(고정 규칙) : 수학적 규칙(예. 범위). Guard 대상이다.

<br/>

## 6.1 Introducing Guard Clauses
- 주제 : Guard은 
- Guard Clauses는 제어 흐름의 일부가 아니다.

## 6.2 Guarding Against Null Only
- 주제 : 타입 정의를 통해 NULL을 제외한 모든 Guard을 제거한다.
- 사용자 정의 타입을 통해 NULL을 제외함 모든 Guard을 제거한다.

## 6.3 Don't Guard Business Rules
- 주제 : 비즈니스 규칙은 Guard화하지 않는다.
- 비즈니스 규칙은 동적과 고정으로 구분할 수 있다.
- bool 반환은 raw 데이터 반환과 같다. 가급적 피하자.

## 6.4 Removing Guards Through Design
- 주제 : Implicit Validation Principle
- One consistent object constructs another consistent object.
- `bool 반환 메서드(상태 확인) vs. 객체 반환 메서드(역량 요청)`
- `객체 반환 메서드(역량 요청)`은 이미 consistent object에게 다른 consistent object을 요청하는 것이다.

## 6.5 Turning Domain Rules into Rule Objects
- 주제 : 

## 6.6 Turning Rule Objects into Active Elements
- 주제 : 

## 6.7 Completing the Students Filter
- 주제 : 

## 6.8 Persistence: Querying View Models
- 주제 : 

