﻿교육 목표
	- 다형성을 이해한다.
	- 불변성/공변성/반공변성을 이해한다.


1. 다형성
	- 좌측 = 우측
	- 생성 타입 | 부모 타입 = 생성 타입


2. Generic 불변성
	- 같은 타입 = ...
	- 부모 타입 = ...			// 에러
	- 자식 타입 = ...			// 에러


3. Generic 공변성
	- 같은 타입 = ...
	- 부모 타입 = ...			
	- 자식 타입 = ...			// 에러


4. Generic 반공변성(상속 관계가 역전된다)
	- 같은 타입 = ...
	- 부모 타입 = ...			// 에러
	- 자식 타입 = ...
