# Chapter 4. Removing Corruption by Only Making Valid State Transitions

## **배움**
1. 객체 크기
   - 객체 크기는 유효성 검사 범위와 같아야 한다.
   - 유효성 검사는 생성자에서 한다(생성 이후는 불변으로 유효성 검사가 필요 없다).
1. 가변 객체 : 객체의 상태 변경
   - Setter 또는 상태 변경 메서드을 갖는 객체이다.
   - 상태 변경을 허용하면 일관성을 깨트린다(생성자 유효성 검사가 무의미해진다).
1. 객체 Raw 데이터
   - Raw 데이터를 제공하지 않는다(Encapsulation을 깨트린다).
   - 호출자가 관련 연산을 구현해야 한다.
1. 복수개 의존 객체 생성
   - Builder 패턴
   - 작은 도메인 모델을 만들자(Constructors as Partial Functions)

<br/>

## 4.1 Reaping the Benefits of Constructor Validation
- 주제 : 유효성 검사의 지역화(생성자) 장점 
- 클래스의 모든 메서드의 유효성 검사는 생성자가 담당한다.
  - Object 규칙 : If you have an object, then it's fine.
  - 클래스 크기 : 유효성 검사가 유사해야 한다.

## 4.2 Defending in Property Setters
- 주제 : Setter 문제점
- 생성자의 유효성 검사를 깨트린다.
- 유효성 검사는 뿔뿔히 흩어지게 한다.

## 4.3 Understanding Distinct Kinds of Properties
- 주제 : 원본 데이터 Getter 문제점
- 원본 데이터를 호출자에게 전달하는 것은 Encapsulation을 깨트리는 것이다.
  - 왜? 원본 데이터 관련 Biz. 연산을 호출자가 수행하기 때문이다.
- 원본 데이터 Getter는 Setter을 허용하게 한다. 

## 4.4 Defending in Complex Mutations
- 주제 : 가변 함수 문제점
- 방어 코드를 증가 시킨다.

## 4.5 Function Domains Revisited
- 주제 : Constructors as Partial Functions
- 방어 코드는 대부분은 메서드 영역 입니다.
  - 유효성 검사 책임을 클래스 단위(생성자)로 분리 시킨다 : SRP 원칙 준수
    - 생성자를 부분 함수로 취급한다.
    - class constructor : validation = 1 : 1
  - 유효한 객체는 다른 유효한 객체를 만듭니다.

## 4.6 When Constructor Depends on Multiple Objects
- 주제 : 복수개 Object에 의존할 때는 Builder 패턴 활용하기
- 복잡한 유효성 검사는 Builder 패턴을 사용한다. 

## 4.7 Creating Objects in Small Steps
- 주제 : 작은 객체에서 큰 객체 생성으로 구조화하기
- Subject <- Professor -> [Exam] <- Student -> [ExamApplication]  

## 4.8 Persistence and Parameterized Constructors
- 주제 : 영속성과 매개변수 생성자
- Domain model = Construction validation(매개변수가 있는 Constructors)
- Persistence = Plain costruction(매개변수가 없는 Constructors)
- Construction validation와 Plain costruction가 불일치한다.