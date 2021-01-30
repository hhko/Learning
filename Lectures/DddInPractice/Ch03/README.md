## Chaper 3. UI와 DB 연동하기

## 개념 정리
![](./Ch03_Summary.png)

<br/>

## MVVM Binding
![](./Ch03_Step1_Binding.png)

<br/>

## 개발

### Step 1. 화면
1. ViewModel
   - 화면 전용 유스케이스를 구현한다.
     - 총합
     ```cs
     public Money MoneyInside => _snackMachine.MoneyInside 
                                    + _snackMachine.MoneyInTransaction;
     ```
1. Domain
   - 도메인 규칙을 구현한다.
     ```cs
     public sealed class Money : ...
     { 
         public override string ToString()
         {
             if (Amount < 1) { ... } // 동전
             else { ... } // 지폐
         }
     }
     ```
   - Entity는 ViewModel Binding을 위해 Value Object를 읽기 전용으로 노출한다.
     ```cs
     public Money MoneyInTransaction => _snackMachine.MoneyInTransaction;
     ```
1. `Money` 클래스 단위 테스트 시나리오
   - `To_string_returns_correct_string_representation` : 돈의 단위 표현(동전 또는 지폐)을 확인한다.

### Step 2. 데이터베이스
1. Entity와 Value Object 테이블
   - Value Object는 Entity와 통합 시킨다.
     - Value Object는 Id을 갖기 않기 때문이다.
     - Value Object은 Entity 없이 스스로 존재할 수 없다(Lifespan이 없다).