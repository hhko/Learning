## Chaper 2.

## ���� ����
![](./Ch02_Summary.png)

### 1. ������ ��
1. Domain Model  
   == Domain Logic  
   == Domain Knowledge  
   == Business Logic  
   == Business Rules  
1. Domain vs. Domain Model
   - Domain : The problem we are working on
   - Domain Model : The solution for the problem, The artifact of the solution  

### 2. ����
1. Types of Equality(����) vs. ����(==)
   - Identifier Equality : id
   - Reference Equality : Reference
   - Structural Equality : Properties

### 3. Value Object vs. Entity
1. Value Object
   - Lifecycle�� ���� �ʴ´�.
   - �Һ���(���� ��� �ֵ� ����.) : ��ȯ�����Ѵ�(Interchangeable).
   - Id�� ���� �ʴ´�.
   - Equality : Reference Equality, Structural Equality
1. Entity
   - Lifecyce�� ���´�.
   - ������ : ��ȯ �Ұ����Ѵ�.
   - Id�� ���´�.
   - Equality : Reference Equality, Identifier Equality
1. ������
   | ����            | Entity     | Value Object |
   |-----------------|:----------:|:------------:|
   | Lifecycle       | O          | X            |
   | Immutable       | X          | O            |
   | Identity        | O          | X            |
   | Interchangeable | X          | O            |
   ----
   | Equality            | Entity | Value Object |
   |---------------------|:------:|:------------:|
   | Identifier Equality | O      | X            |
   | Reference Equality  | O      | O            |
   | Structural Equality | X      | O            |

<br/>

## ����
### 1. Pluralsight
1. Value Object �䱸����
   - [x] Generic Ÿ�� 
   - [x] Properties �� : Equals, ==, !=
   - [ ] GetHashCode ���� ����ȭ
   - [ ] Generic Ÿ�� ���� ���� : `public abstract class ValueObject<T> where T : ValueObject<T>`
   - [ ] GetHashCode ����
1. Entity
   - [ ] Entity Id ������
   - [ ] Entity Equals ���� �׽�Ʈ
   - [ ] Fluent Assertions ShouldBeEquivalentTo -> ?

### 2. ABP Framework
1. Value Object ������
   ```
   public abstract class ValueObject
   {
        protected ValueObject();

        public bool ValueEquals(object obj);
        protected abstract IEnumerable<object> GetAtomicValues();
   }
   ```
   - `Equals`�� �ƴ� `ValueEquals`�� ����ؾ� �Ѵ�.
   - `GetAtomicValues`�� �����ؾ� �Ѵ�.
   - `GetHashCode`�� �������� �ʴ´�.
1. Entity ������
   - [ ] Entity Id ������
   - [ ] Entity Equals ���� �׽�Ʈ
   
### 3. eShopOnContainers
1. Value Object
   - `protected override IEnumerable<object> GetEqualityComponents()`�� �����ؾ� �Ѵ�(abstract : o).
   - `Equals`�� ����� �� �ִ�.
   - `GetHashCode`�� �����Ѵ�.
1. Entity
   - [ ] Entity Id ������
   - [ ] Entity Equals ���� �׽�Ʈ

### 4. Akkatecture
1. Value Object
   - `protected override IEnumerable<object> GetEqualityComponents()`�� ������ �� �ִ�(abstract : x).
   - `Equals`�� ����� �� �ִ�.
   - `GetHashCode`�� �����Ѵ�.
1. Entity
   - Id�� ��������� �����ؾ� �Ѵ�.
     ```cs
     using Akkatecture.Core;
     using Akkatecture.ValueObjects;
     using Newtonsoft.Json;

     [JsonConverter(typeof(SingleValueObjectConverter))]
     public class SnackMachineId : Identity<SnackMachineId>
     {
         public SnackMachineId(string entityId)
             : base(entityId)
         {
         }
     }
     ```