# 환경 설정

## 목차

## 1. 계정 설정
- 환경 설정 확인
  ```shell
  git config --list
  ```
- 전역 사용자 설정
  ```shell
  git config --global user.name "awesometic"
  git config --global user.email "awesometic.lab@gmail.com"
  ```
- 로컬 사용자 설정
  - 로컬 사용자 설정은 전역 사용자 설정보다 높은 우선순위를 갖는다.
  ```shell
  git config --local user.name "a-user-only-for-this-repository"
  git config --local user.email "and-an-email-as-well@gmail.com"
  ```
  
## 참고 자료
- [Git 프로젝트/저장소마다 다른 계정 정보 사용하기](https://awesometic.tistory.com/128)

