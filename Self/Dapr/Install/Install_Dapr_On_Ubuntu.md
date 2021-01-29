## 목차
1. Dapr 개요
1. Dapr 설치
1. Dapr 설치 확인
1. Dapr 대시보드
1. Dapr 제거
1. 명령 Summary

<br/>

## 1. Dapr 개요
- 2020-12-23(수) 최신 버전은 CLI(1.0.0.-rc.3), Runtime(1.0.0.-rc.2) 이다.
- dapr는 3개 컨터이너 이미지(daprio/dapr:1.0.0-rc.2, redis, openzipkin/zipkin)으로 구성한다.
- 대시보드도 함께 설치된다.

<br/>

## 2. Dapr 설치
1. Dapr CLI installation scripts	
   - CLI 버전 : `-s 1.0.0-rc.3` 
   - 설치 명령 : `wget -q https://raw.githubusercontent.com/dapr/cli/master/install/install.sh -O - | /bin/bash -s 1.0.0-rc.3`
   - 확인 명령 : `ls /usr/local/bin`  
     ![image](/Images/ls_dapr.png)
   - 참고 사이트 : [How-To: Install Dapr CLI](https://v1-rc2.docs.dapr.io/getting-started/install-dapr-cli/)
1. Install Dapr into your local environment
   - Runtime 버전 : `1.0.0-rc.2`
   - 명령 : `dapr init --runtime-version 1.0.0-rc.2`  
     ![image](/Images/dapr_init.png)
   - 참고 사이트 : [Install Dapr into your local environment](https://v1-rc1.docs.dapr.io/getting-started/install-dapr-selfhost/)

<br/>

## 3. Dapr 설치 확인
1. 버전
   - 명령 : `dapr --version`  
   - 결과 :
     - CLI 버전 : 1.0.0.-rc.3
     - Runtime 버전 : 1.0.0.-rc.2  
      ![image](/Images/dapr_version.png)
1. 컨테이너
   - 명령 : `docker container ls`  
   - 결과 :
     - daprio/dapr:1.0.0-rc.2
     - redis
     - openzipkin/zipkin  
      ![image](/Images/dapr_images.png)
1. 폴더 구성
   - 명령 : `ls $HOME -al`  
   - 결과 : `.dapr`  
     ![image](/Images/dapr_folders.png)
   - 명령 : `ls $HOME/.dapr`
   - 결과 : bin, components, config.yaml  
     ![image](/Images/dapr_inspect.png)
   - 폴더 구성 이해
     ```shell
     $HOME
        /.dapr
           config.yaml
           /components          # Pub/Sub Redis
              pubsub.yaml
              statestore.yaml
           /bin
              /web
              daprd              # 데몬
              dashboard          # 대시보드
     ```
1. 참고 사이트
   - [Install Dapr into your local environment](https://v1-rc2.docs.dapr.io/getting-started/install-dapr-selfhost/)

<br/>

## 4. Dapr 대시보드
1. 실행
   - 명령 : `dapr dashboard` 또는 `dapr dashboard -p 9999`  
     ![image](/Images/dapr_dashboard_run.png)
   - 결과 : http://localhost:8080 (기본 포트 : 8080)  
     ![image](/Images/dapr_dashboard.png)
1. 참고 사이트
   - [dapr/dashboard](https://github.com/dapr/dashboard)

<br/>

## 5. Dapr 제거
1. 부분 제거
   - 제거 대상 :
     - 컨테이너 : Dapr Actor Placement
     - 폴더 : $HOME/.dapr/bin
   - 명령 : `dapr uninstall`  
     ![image](/Images/dapr_uninstall.png)
1. 전체 제거
   - 제거 대상
     - 컨테이너 : Dapr Actor Placement, ZipKin, Redis
     - 폴더 : $HOME/.dapr, /usr/local/bin/dapr
   - 명령 : `dapr uninstall --all`  
     ![image](/Images/dapr_uninstall_all.png)
   - 제외 :
     - `/usr/local/bin` 폴더에 있는 `dapr`은 제거하지 않는다.
1. 참고 사이트
   - [Install Dapr into your local environment](https://v1-rc2.docs.dapr.io/getting-started/install-dapr-selfhost/)
   
<br/>

## 6. 명령 Summary
```shell
# Dapr CLI 설치
wget -q https://raw.githubusercontent.com/dapr/cli/master/install/install.sh -O - | /bin/bash -s 1.0.0-rc.3

# Dapr 로컬 환경 구성
dapr init --runtime-version 1.0.0-rc.2

# Dapr 대시보드 사이트 실행, http://localhost:9999
dapr dashboard -p 9999

# Dapr 제거
dapr uninstall --all
```