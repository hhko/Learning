# [Domain-Driven Design in Practice](https://app.pluralsight.com/library/courses/domain-driven-design-in-practice/table-of-contents?aid=7010a000002LUv7AAG)

## 목차
- [1장. DDD Introduction](./Ch01)
- [2장. Value Object vs. Entity](./Ch02)
- [3장. UI & Persistence Layer](./Ch03)
- [4장. Aggregate](./Ch04)
- [5장. Repository](./Ch05)

## 요구사항
- 스낵머신에 돈을 투입한다.
- 스낵머신에서 스낵을 구매한다.
- 스낵머신에서 돈을 반환한다.
- 스낵머신 Slot은 최대 3개이다(Slot 단위로 스낵이 위치한다).  
  - 3 slots of snacks
- 구매할 수 있는 Snack이 있어야 한다.  
  - Check if the slot isn’t empty.
  - Snack pile is not empty.
- 스낵 구매를 위한 충분한 돈이 투입되어야 한다.  
  - Check if inserted money is enough.
  - Inserted money is sufficient.
- 스낵을 구매한 후 잔액을 반환할 수 있다.  
  - Return the change
- 충분한 잔액이 있어야 한다. 
  - Check if there’s enough change.
  - The amount of money inside is sufficient to return the change.

<br/>

## DDD 패키지
- [ABP Framework](https://github.com/abpframework/abp)
- [eShopOnContainers](https://github.com/dotnet-architecture/eShopOnContainers)
- [Akkatecture](https://github.com/Lutando/Akkatecture)
- [Hands On Domain Driven Design with .NET Core](https://github.com/PacktPublishing/Hands-On-Domain-Driven-Design-with-.NET-Core)

## 참고 사이트
- [Hands-on Domain-Driven Design with .NET Core book](https://github.com/alexeyzimarev/ddd-book)
- [Value Object](https://docs.microsoft.com/ko-kr/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/implement-value-objects)
- [Value Object | Youtube](https://www.youtube.com/watch?v=kVtfQrkDC94)
- [Entity](https://docs.microsoft.com/ko-kr/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/seedwork-domain-model-base-classes-interfaces)
- [Docker에서 SQL Server 컨테이너 이미지 실행](https://docs.microsoft.com/ko-kr/sql/linux/quickstart-install-connect-docker?view=sql-server-ver15&preserve-view=true&pivots=cs1-bash)
- [SQL Server Docker 컨테이너 배포 및 연결](https://docs.microsoft.com/ko-kr/sql/linux/sql-server-linux-docker-container-deployment?view=sql-server-ver15&pivots=cs1-bash)
