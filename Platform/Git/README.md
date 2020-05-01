# Git

## 목차
- [환경 설정](./CONFIG.md)

### add
- 전체 추가하기
  - ```git add .```
- add 취소하기
  - ```git restore --staged 폴더명/파일명```
- add 목록 확인하기
  - ```git status```  

### commit
- push하지 않은 commit 확인하기
  - ```git log --branches --not --remotes```
  - https://blog.outsider.ne.kr/820
  
## Q&A
### 폴더 이동 후
- 탐색기에서 폴더를 이동하면 git status에서 자동으로 인식하지 못한다.
  - git add -f [이동된 폴더 경로]
  - git restore --staged [제외시킬 폴더 경로]  