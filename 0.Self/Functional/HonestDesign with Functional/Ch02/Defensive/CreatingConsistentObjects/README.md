# 1. Removing Corruption by Only Creating Consistent Objects
 
 ## 목차
 - [x] Creating Objects
   - Stage: ??
 - [x] Creating Consistent Objects
   - Stage: ??
 - [x] Pros and Cons of Multiple Constructors
   - [ ] Visitor
   - [ ] Functional Programming in C# 책의 Option 구현 스타일
   - Stage: 05, 06, 07, 08
 - [x] Understanding Limitations of the Constructor
   - Stage: 09
 - [x] Promoting Constructor into Builder
   - Stage: 10, 11
 - [x] Variations in the Builder Implementation
   - Stage: 12

## 요약
- 객체 식별
  - 생성자는 한개이어야한다.
- 객체 생성 전
  - 생성자에서 유효성 검사를 실패할 때 예외를 발생 시킨다(No Complete).
- 객체 생성 후
  - 객체가 행위를 수행할 때 상태 값의 

## 정리
- Defense 전략
  - Data-centric(일관성이 없고 불안정한 데이터) defense vs. An object approach 
  - Data-centric defense
    - Data may be corrupt
    - Hence need to defend
  - An object approach
    - Wrap data inside an object
    - **Make the object guarantee the data are complete and consistent**
- Factory function
  - Constructor is a proper factory
  - Validates input, constructors an object
  - THE OBJECT RULE
    - **IF YOU HAVE AN OBJECT, IT IS FINE.**
    - **No defense after constructor**
  - No multiple constructors for a class
    - **They indicate multiple responsibilities**
    - They invite lots of defensive code
    - Split them into multiple class
    - Instantiate each class in one way
  - Addressing complex validation rules
    - Abandon constructor validation
    - Builder pattern
  - The builder concept
    - Wrap validation and construction into an object itself
    - Builder implementation can vary in complexity(Fluent Builder, Immutable Fluent Builder)
- Reconsidering exceptions
  - Their value is questionable, as will be seen
  - Object creation 관점
    - Exception instead of an object means the request was not completed
  - Defensive code 관점
    - Exception requires explicit defense
  - Defensive design 관점
    - Defensive design with no exceptions promises no explicit defensive code

