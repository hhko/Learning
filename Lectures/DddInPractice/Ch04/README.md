## Chaper 4. Aggregate & Repository

## 목차
1. 요약
1. 목표
1. 개발

<br/>

## 1. 요약
![](./Ch04_Summary.png)

<br/>

## 2. 목표
1. ...

<br/>

## 4. 개발

### Step 1.
1. Aggregate
   - 하나의 추상화 아래 여러 Entity을 모여 도메인 모델을 단순화시키는 디자인 패턴이다.
     - 응집(Root Entity) : 개념적 전체이다.
     - 유효성 검사(불변식?) : 여러 Entity가 생애 동안 유지해야하는 불변식을 가지고 있다.
     - 접근(불변식 보호) : Root Entity을 통해서 자식 Entity을 접근해야 한다(Value Object는 불변 객체이기 때문에 노출 가능하다).
       - 추상화가 더 필요할 때 : Entity의 개별 속성 접근을 위한 메서드를 정의한다.
       - 추상화 방법 : 새로운 Value Object 발굴을 고려해야 한다.
     - 저장소 최소 단위(데이터 일관성 유지) : 
1. Aggregate 정의 기준
   - Entity 수명(Lifespan)의 부모다.
   - 일관성(불변식, 트랜잭션)이 최소 단위다.

- 사용자가 투입한 돈 반환 vs. 사용자가 투입한 돈과 동일한 금액 반환 
