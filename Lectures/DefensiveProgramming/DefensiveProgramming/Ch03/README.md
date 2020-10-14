# Chapter 3. Removing Corruption by Only Creating Consistent Objects

## **배움**
1. Object 규칙
   - If you have an object, then it's fine.
1. SRP 준수
   - 사전 조건(유효성 검사) 책임 : Builder 패턴
   - 객체 생성 : 생성자
   - 사후 조건 : x(필요 없음, 불변)
1. 객체 크기
   - Class : Factory Method(생성자) = 1 : 1
   - 복수 생성자일 때는 타입으로 구분한다.

<br/>

## 3.1 Creating (Inconsistent) Objects
- 주제 : 객체 생성
- 일관성이 없는 데이터 : 유효성이 항상 만족하지 않는 데이터. 예 : NULL, 빈 문자열, ...
  - Defense Code와 코드 중복을 발생 시킨다.

## 3.2 Creating Consistent Objects
- 주제 : 객체 생성
- 처음부터 유효한 객체만 생성한다.
  - 명시적 생성자로 유효한 객체만 생성한다.
  - 유효하지 않는 데이터 입력일 때는 예외를 발생 시킨다(객체를 생성하지 않는다).

## 3.3 Pros and Cons of Multiple Constructors
- 주제 : 객체 식별(크기)
- class : factory function = 1 : 1
- 식별 데이터(bool, enum, ...)는 객체로 구분한다.
  - 식별 데이터는 제어 흐름 코드(Control flow code)를 생산하고 코드 복잡도를 증가 시킨다.

## 3.4 Understanding Limitations of the Constructor
- 주제 : 기본 생성자의 제약 사항
- 기본 생성자는 결과 타입이 없다.
  - 객체 생성 결과만 갖는다.
  - 유효성 검사 실패시 예외를 발생 시킬 수 밖에 없다.
  - 이름은 반드시 클래스명과 같아야 한다.
- 책임
  - 유효성 검사 책임
  - 객체 생성 책임

## 3.5 Promoting Constructor into Builder
- 주제 : 책임 분리
- 유효성 검사는 Builder 패턴에서 처리한다.
- 생성자는 생성 책임만을 갖는다.
- 생성자는 더 이상 유효성 검사를 하지 않는다(중복 제거, 책임 분리)

## 3.6 Variations in the Builder Implementation
- 주제 : Builder 패턴 구현 방법
- 네임스페이스로 Builder와 객체(감춘다)를 분리 시킨다.
- 데이터와 구성 메커니즘 소유자가 Builder을 소용한다.
- Func<T> 반환 값을 이용하여 항상 객체를 생성시킬 수 있다.
 
