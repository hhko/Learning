# 개발 환경

## 목차
1. **[Oracle VirtualBox 설치하기](#oracle-virtualBox-설치하기)**
1. **[Vagrant 설치하기](#vagrant-설치하기)**
1. **[Vagrant 구성하기](#vagrant-구성하기)**
1. **[가상머신 시작하기](#가상머신-시작하기)**
1. **[Visual Studio Code 가상머신 접속하기](#visual-studio-code-가상머신-접속하기)**
1. **[Jaeger 설치하기](#jaeger-설치하기)**
1. **[ZipKin 설치하기](#zipkin-설치하기)**
1. **[TODO](#todo)**

----

1. Oracle VirtualBox 설치하기
   - Windows hosts 다운로드: [링크](https://www.virtualbox.org/wiki/Downloads)
1. Vagrant 설치하기
   - Windows 64-bit 다운로드: [링크](https://www.vagrantup.com/downloads.html)
1. Vagrant 구성하기
   - Vagrantfile 파일
     - Machine: m1, m2, m3
     - IP: 192.168.99.201, ...202, ...203
     - OS: [Ubuntu](https://app.vagrantup.com/ubuntu/boxes/disco64)
     - Disk: 40GB
     - Memory: 2048
     - Core: 2
   - provision\node.sh 파일
     - [Docker 설치](https://docs.docker.com/install/linux/docker-ce/ubuntu/)
     - [.NET Core 3.1](https://docs.microsoft.com/en-us/dotnet/core/install/linux-package-manager-ubuntu-1910)
   - worksapce 폴더
     - 가상머신과 Host 공유 폴더
1. 가상머신 시작하기
   ```shell
   C:\ ... > dir
        Vargrantfile                // Vagrant 파일
        provision                   // 폴더
   C:\ ... > vagrant up m1          // m1 가상머신 만들기
   C:\ ... > vagrant ssh m1         // m1 가상머신 접속하기
   vagrant@m1:~S ls                 // m1 가상머신
        workspace
   ```
1. Visual Studio Code 가상머신 접속하기
   - 확장 도구 설치
     - [Remote Development](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack), [정보](https://code.visualstudio.com/docs/remote/remote-overview)
   - SSH 정보 얻기
     ```shell
     C: ... > vagrant ssh-config --host m1 
     ```
   - SSH 설정하기
     - Ctrl+Shift+P
     - Remote-SSH: Open Configuration File...
     - C:\Users\계정\.ssh\config
     - (붙여넣기: vagrant ssh-config --host m1)
   - 가상머신 접속하기
     - Console: 가상머신 실행 & 접속
       ```shell
       C:\ ... > vagrant up m1
       C:\ ... > vagrant ssh m1
       ```
     - Visual Studio Code: 가상머신 접속
       - Ctrl+Shift+P
       - Remote-SSH: Connect to Host...
       - m1
   - 가상머신 환경에 Visual Studio Code 확장도구 설치하기
     - [Docker](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-docker)(Install on SSH: m1)
1. Jaeger 설치하기
   - docker: [링크](https://www.jaegertracing.io/docs/1.16/getting-started/)
     ```shell
     C:\ ... > vagrant up m1
     C:\ ... > vagrant ssh m1
     vagrant@m1:~S docker run -d --name jaeger \
                    -e COLLECTOR_ZIPKIN_HTTP_PORT=9411 \
                    -p 5775:5775/udp \
                    -p 6831:6831/udp \
                    -p 6832:6832/udp \
                    -p 5778:5778 \
                    -p 16686:16686 \
                    -p 14268:14268 \
                    -p 14250:14250 \
                    -p 9411:9411 \
                    jaegertracing/all-in-one:1.16
     vagrant@m1:~S docker container ls
     ```
   - 접속하기: http://192.168.99.201:16686/
1. ZipKin 설치하기
   - docker: [링크](https://zipkin.io/pages/quickstart.html)
     ```shell
     C:\ ... > vagrant up m1
     C:\ ... > vagrant ssh m1
     vagrant@m1:~S docker run -d -p 9411:9411 openzipkin/zipkin
     vagrant@m1:~S docker container ls
     ```
   - 접속하기: http://192.168.99.201:9411