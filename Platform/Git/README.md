# Git

## 목차
- [환경 설정](./CONFIG.md)

## git add
### 자식폴더까지 포함하여 파일 추가히기
- 시나리오
- 명령어
  - `git add .`

### add한 파일을 취소하기
- 명령어
  - `git restore --staged 폴더명/파일명`
  - ..
- 참고 사이트
  - [2.4 Git의 기초 - 되돌리기](https://git-scm.com/book/ko/v2/Git%EC%9D%98-%EA%B8%B0%EC%B4%88-%EB%90%98%EB%8F%8C%EB%A6%AC%EA%B8%B0)

## commit
- push하지 않은 commit 확인하기
  - ```git log --branches --not --remotes```
  - https://blog.outsider.ne.kr/820

## git branch
- 참고 사이트
  - [Git - ( local / remote ) branch 사용법 정리](https://jw910911.tistory.com/16)

## git fetch
### 원격 저장소 브랜치 정보를 로컬 저장소 브랜치에 반영하기
- 시나리오
- 명령어
  - `git fetch -p` : prune (가지치기)
  - Before fetching, **remove any remote-tracking references that no longer exist on the remote**. 
- 예
  ```
  C:\GitSpace>git branch -r
    origin/797-DashboardUtility     // 원격 저장소에 삭제된 브랜치가 표시된다.
    origin/HEAD -> origin/master
    origin/master
  
  C:\GitSpace>git fetch -p          // 원격 저장소에 삭제된 브랜치를 Fetch 한다.
  From http://wish.mirero.co.kr/mirero/project/blue/1.0/h20-secfou-blu10-01/blue-cats
   - [deleted]         (none)     -> origin/797-DashboardUtility
  
  C:\GitSpace>git branch -r         // 원격 저장소에 삭제된 브랜치가 표시되지 않는다.
    origin/HEAD -> origin/master
    origin/master
  ```   

## Q&A
### 폴더 이동 후
- 탐색기에서 폴더를 이동하면 git status에서 자동으로 인식하지 못한다.
  - git add -f [이동된 폴더 경로]
  - git restore --staged [제외시킬 폴더 경로]  
