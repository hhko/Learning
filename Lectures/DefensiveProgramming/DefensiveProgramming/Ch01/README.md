# Chapter 3. Removing Corruption by Only Creating Consistent Objects

## 3.1 Creating Objects
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

## 3.5 Promoting Constructor into Builder
- 주제 : 책임 분리
- 유효성 검사는 Builder 패턴에서 처리한다.
- 생성자는 생성 책임만을 갖는다.

## 3.6 Variations in the Builder Implementation
