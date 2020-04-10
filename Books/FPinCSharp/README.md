# 함수형 프로그래밍 in C# 스터디
1. 도서: [Functional Programming in C#](https://www.manning.com/books/functional-programming-in-c-sharp?query=functional%20programming%20in%20C#), [소스](https://github.com/la-yumba/functional-csharp-code)  
1. 목차
   - Chapter 01. Introducing functional programming
   - [Chapter 02. Why function purity matters](./Ch02)
   - [Chapter 03. Designing function signatures and types](./Ch03)
   - Chapter 04. Patterns in functional programming
   - Chapter 05. Designing programs with function composition
   - Chapter 06. Functional error handling
   - Chapter 07. Structuring an application with functions
   - Chapter 08. Working effectively with multi-argument functions
   - Chapter 09. Thinking about data functionally
   - Chapter 10. Event sourcing: a functional approach to persistence
   - Chapter 11. Lazy computations, continuations, and the beauty of monadic composition
   - Chapter 12. Stateful programs and stateful computations
   - Chapter 13. Working with asynchronous computations
   - Chapter 14. Data streams and the Reactive Extensions
   - Chapter 15. An introduction to message-passing concurrency
   
## 용어
- 순수 함수(Pure Function)
  - The output depends entirely on the input arguments.
  - Cause no side effects.
- 불순 함수(Impure Function)
  - Factors other than input arguments may affect the output.
  - May cause side effects.
- Parallelization
  - Different threads carry out tasks in parallel
- Lazy evaluation
  - Only evaluate values as needed
- Memoization
  - Cache the result of a function so it’s only computed once

## 참고 자료(한국어)
- [함수형 프로그래밍과 ES6+](https://www.youtube.com/watch?v=4sO0aWTd3yc)
- [모나드와 함수형 아키텍처](https://teamdable.github.io/techblog/Moand-and-Functional-Architecture)
- [기존의 사고 방식을 깨부수는 함수형 사고](https://evan-moon.github.io/2019/12/15/about-functional-thinking/)
- [수학에서 기원한 프로그래밍 패러다임, 순수 함수](https://evan-moon.github.io/2019/12/29/about-pure-functions/)
- [변하지 않는 상태를 유지하는 방법, 불변성(Immutable)](https://evan-moon.github.io/2020/01/05/what-is-immutable/)
- [어떻게 하면 안전하게 함수를 합성할 수 있을까?](https://evan-moon.github.io/2020/01/27/safety-function-composition/)
- [함수형 사고와 Ramda.js로 기업 데이터 처리하기 (1)](https://www.huskyhoochu.com/functional-thinking/)
- [함수형 사고와 Ramda.js로 기업 데이터 처리하기 (2)](https://www.huskyhoochu.com/functional-thinking-advanced/)
- [Monad Programming with Scala Future](https://tech.kakao.com/2016/03/03/monad-programming-with-scala-future/)
- [Monad란 무엇인가?](https://www.youtube.com/watch?v=jI4aMyqvpfQ)
- [파이썬에서 함수형으로 프로그래밍하기](https://www.youtube.com/watch?v=UPmQHHpS3cw)
- [함수형 프로그래머를 찾아서 - 한주영 1부](http://www.podbbang.com/ch/9126?e=22183108)
- [함수형 프로그래머를 찾아서 - 한주영 2부](http://www.podbbang.com/ch/9126?e=22192689)
- [함수형 프로그래머를 찾아서 - 한주영 3부](http://www.podbbang.com/ch/9126?e=22207497)
- [함수형 프로그래머를 찾아서 - 한주영 4부](http://www.podbbang.com/ch/9126?e=22211910)
- [함수형 프로그래머를 찾아서 - 한주영 5부](http://www.podbbang.com/ch/9126?e=22214486)
- [객체지향과 함수형 프로그래밍의 절묘한 만남 - 1부](http://www.podbbang.com/ch/9126?e=21745210)
- [객체지향과 함수형 프로그래밍의 절묘한 만남 - 2부](http://www.podbbang.com/ch/9126?e=21760078)
- [썬한코딩, 모나드 - 1부](https://www.youtube.com/watch?v=laRzp3fuboU&t)
- [썬한코딩, 모나드 - 2부](https://www.youtube.com/watch?v=tjbitGWAKcY)
- [썬한코딩, 모나드 - 3부](https://www.youtube.com/watch?v=DvFv6n32xME)
- [썬한코딩, 함수형 프로그래밍 - 1부](https://www.youtube.com/watch?v=PYKBYfjhwhw)
- [썬한코딩, 함수형 프로그래밍 - 2부](https://www.youtube.com/watch?v=FGpm-mIsbuU)
- [함수형 프로그래밍이란 무엇이고? 어디에? 어떻게 쓸까?](https://tacademy.skplanet.com/live/player/onlineLectureDetail.action?seq=143)
- [함수형 프로그래머가 되고 싶다고? 파트1](https://github.com/FEDevelopers/tech.description/wiki/%ED%95%A8%EC%88%98%ED%98%95-%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%A8%B8%EA%B0%80-%EB%90%98%EA%B3%A0-%EC%8B%B6%EB%8B%A4%EA%B3%A0%3F-(Part-1))
- [함수형 프로그래머가 되고 싶다고? 파트2](https://github.com/FEDevelopers/tech.description/wiki/%ED%95%A8%EC%88%98%ED%98%95-%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%A8%B8%EA%B0%80-%EB%90%98%EA%B3%A0-%EC%8B%B6%EB%8B%A4%EA%B3%A0%3F-(Part-2))
- [함수형 프로그래머가 되고 싶다고? 파트3(https://github.com/FEDevelopers/tech.description/wiki/%ED%95%A8%EC%88%98%ED%98%95-%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%A8%B8%EA%B0%80-%EB%90%98%EA%B3%A0-%EC%8B%B6%EB%8B%A4%EA%B3%A0%3F-(Part-3))
- [함수형 프로그래머가 되고 싶다고? 파트4](https://github.com/FEDevelopers/tech.description/wiki/%ED%95%A8%EC%88%98%ED%98%95-%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%A8%B8%EA%B0%80-%EB%90%98%EA%B3%A0-%EC%8B%B6%EB%8B%A4%EA%B3%A0%3F-(Part-4))
- [함수형 프로그래머가 되고 싶다고? 파트5](https://github.com/FEDevelopers/tech.description/wiki/%ED%95%A8%EC%88%98%ED%98%95-%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%A8%B8%EA%B0%80-%EB%90%98%EA%B3%A0-%EC%8B%B6%EB%8B%A4%EA%B3%A0%3F-(Part-5))
- [함수형 프로그래머가 되고 싶다고? 파트6](https://github.com/FEDevelopers/tech.description/wiki/%ED%95%A8%EC%88%98%ED%98%95-%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%A8%B8%EA%B0%80-%EB%90%98%EA%B3%A0-%EC%8B%B6%EB%8B%A4%EA%B3%A0%3F-(Part-6))

## 참고 자료(영어)
- [x] [Mark Seemann - Refactoring to Aggregate Services](https://github.com/hhko/Learning/tree/master/Blogs/MarkSeemann/RefactoringToAggregateServices)
- [ ] [Paul Louth - How do I use Try<T> with an existing method?](https://github.com/louthy/language-ext/issues/507#issuecomment-432023820)
- [ ] [Mark Seemann - Repeatable execution](https://blog.ploeh.dk/2020/03/23/repeatable-execution/)
- [ ] [Mark Seemann - Repeatable execution in C#](https://blog.ploeh.dk/2020/04/06/repeatable-execution-in-c/)
- [ ] [Mark Seemann - Functional architecture, a definition](https://blog.ploeh.dk/2018/11/19/functional-architecture-a-definition/)
- [ ] [Mark Seemann - Get value out of your monad](https://www.youtube.com/watch?v=F9bznonKc64&t)
- [ ] [Mark Seemann - Dependency Injection revisited](https://www.youtube.com/watch?v=4hvIwRHylj0)
- [ ] [Mark Seemann - Functional architecture, The pits of success](https://www.youtube.com/watch?v=US8QG9I1XW0)
- [ ] [Zoran Horvat - Overcoming the Limitations of Constructors](http://www.codinghelmet.com/articles/overcoming-the-limitations-of-constructors)
- [ ] [Zoran Horvat - What Makes Functional and Object-oriented Programming Equal](http://www.codinghelmet.com/articles/what-makes-functional-and-object-oriented-programming-equal)
- [ ] [Zoran Horvat - Pros and Cons of Multiple Constructors](http://www.codinghelmet.com/articles/pros-and-cons-of-multiple-constructors)
- [ ] [Zoran Horvat - Cascading Abstract Factories to Eliminate Dependencies](http://www.codinghelmet.com/articles/cascading-abstract-factories)
- [ ] [Vladimir Khorikov - Unit Testing Dependencies: The Complete Guide](https://enterprisecraftsmanship.com/posts/unit-testing-dependencies/)
- [ ] [Enrico Buonanno - Logic vs. side effects: functional goodness you don't hear about](https://www.youtube.com/watch?v=wJq86IXkFdQ)
- [ ] [Jorge Yañez - Functional Programming Concepts Applied Using C#](https://nearsoft.com/blog/functional-programming-concepts-applied-using-c/)
- [ ] [Dave Mateer - Functional Programming in C# - Expressions, Option, Either](https://davemateer.com/2019/03/12/Functional-Programming-in-C-Sharp-Expressions-Options-Either) 
