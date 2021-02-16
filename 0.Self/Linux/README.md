
### Offline 설치를 위한 Ubuntu 패캐지 다운로드
1. 명령어 구성
   - `apt-get download` : 패키지를 다운로드 한다.
   - `apt-cache depends` : 패키지 의존성 정보를 출력한다.
   - `grep "^\w"` : 문자로 시작하는 줄만 출력한다.
   -  `sort -u` : 정렬 후 중복을 제거한다.
1. 패키지 다운로드 명령어 
   ```
   apt-get download $(apt-cache depends --recurse --no-recommends --no-suggests --no-conflicts --no-breaks --no-replaces --no-enhances [패키지명] | grep "^\w" | sort -u)
   ```
1. 예. vim 패키지 다운로드	 
   ```
   apt-get download $(apt-cache depends --recurse --no-recommends --no-suggests --no-conflicts --no-breaks --no-replaces --no-enhances [패키지명] | grep "^\w" | sort -u)
   sudo dpkg -i *
   ```
1. 참고 사이트	 
   - [Download Recursive Dependencies Of A Package In Ubuntu](https://ostechnix.com/download-recursive-dependencies-of-a-package-in-ubuntu/)