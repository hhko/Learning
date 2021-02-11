# Repositiory Pattern 개선

## 교육 목표
   - 공변성/반공변성을 적용한다.

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
	IReadOnlyRepository<out T>, IWriteOnlyRepository<in T>
	↑
	IRepository<T>
	↑
	SqlRepository<T>
   ```
1. DataAccess.cs
   - in, out은 인터페이스에만 적용가능한다.
   - in, out은 함께 사용할 수 없다(함수 입력/출력으로 인터페이스가 분리되어야 한다.)
   - out: 함수 출력, 덜 구체적
   - in: 함수 입력, 더 구체적
1. Program.cs
   - 인터페이스 분리를 통한 구체화: IRepository -> IWriteOnlyRepository, IReadOnlyRepository
   - 덜 구체적: 함수 출력, out 
     - 예: ```IReadOnlyRepository<out T>```
   - 더 구체적: 함수 입력, in
     - 예: ```IWriteOnlyRepository<in T>```

