교육 목표
	- 공변성/반공변성 필요성을 이해한다.


1. 데이터 구조
	Person
	↑
	Employee
	↑
	Manager


2. Repo 구조
	IRepository<T>
	↑
	SqlRepository<T>


3. DataAccess.cs
	- where class: 함수 조건 준수(Set<T> 함수), 참조 데이터 타입
	- where class, IEntity: T 타입 제약


4. Program.cs 에러 확인
	- IRepository<Manager> employeeRepository = new SqlRepository<Employee>( ... );
	- IRepository<Person> employeeRepository = new SqlRepository<Employee>( ... );
