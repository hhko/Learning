# Repositiory Pattern

## 교육 목표
   - 공변성/반공변성 필요성을 이해한다.

## 주요 내용
1. 데이터 구조
   ```cs
    Person
	↑
	Employee
	↑
	Manager
   ```
1. Repo 구조
   ```cs
	IRepository<T>
	↑
	SqlRepository<T>
   ```
1. DataAccess.cs
   - where class: 함수 조건 준수(Set<T> 함수), 참조 데이터 타입
   - where class, IEntity: T 타입 제약
1. Program.cs 에러 확인
   - IRepository<Manager> employeeRepository = new SqlRepository<Employee>( ... );
   - IRepository<Person> employeeRepository = new SqlRepository<Employee>( ... );
