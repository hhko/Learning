# Visual Studio Code 개발 환경 구축하기

## 단축키

- 참조 자료: https://code.visualstudio.com/docs/editor/codebasics
- Ctrl + Shift + P : Command Palette
- Ctrl + Shift + Alt + 방향키/페이지키 : Column Selection
- Shift + Alt + 마우스 : Column Box Selection

## VSCode Settings

1. 폴더 제외 시키기
   - Ctrl + Shift + P > "Preferences: Open Workspace Settins"
   - Workspace > Text Editor > Files
     - Files: Excluede

       ```json
        {
            "files.exclude": {
                "**/bin": true,
                "**/obj": true
            }
        }
       ```

1. settins.json 파일
   - VSCode 설정 파일이다.
1. launch.json 파일
   - VSCode "Debug and Run" 운영을 위한 설정 파일이다.
   - "${workspaceFolder}"은 솔루션 파일이 있는 경로다.
1. tasks.json 파일

## C# 개발 환경

### C# - Visual Studio Code Extension

1. [ ] Auto-Using for C#
   - using 구문을 자동 생성해 준다.
1. [ ] C# Extensions
   - 인터페이스와, 클래스 기본 코드를 자동 생성해 준다.
1. [ ] .NET Core Extension Pack  
   - https://marketplace.visualstudio.com/items?itemName=doggy8088.netcore-extension-pack
1. Awesome DotNetCore Pack
   - C# and DotNetCore
     - [x] C# for Visual Studio Code (powered by OmniSharp)
     - [x] C# Extensions
     - [ ] C# Snippets
     - [ ] Super Sharp (C# extensions)
     - [ ] Paste JSON as Code
     - [ ] Dotnet Core Essentials
     - [ ] Essential ASP.NET Core Snippets
   - Code formatting and comments
     - [ ] EditorConfig
     - [ ] XML Documentation Comments Support for Visual Studio Code
   - Dev Tools
     - [ ] IL Viewer for Visual Studio Code
     - [ ] .NET Core Test Explorer
     - [ ] GitLens
     - [ ] Path Intellisense
     - [ ] Todo Tree
     - [ ] Copy text
1. Dev Tools
   - [ ] Output Colorizer
   - [ ] Todo+
   - [ ] VS Live Share
   - [ ] GitLab Workflow
   - [ ] Remote – Containers
   - [ ] Path Intellisence
   - [ ] Visual Studio IntelliCode
   - [ ] GitHub Extension
   - [ ] Docker
   - [ ] Code Spell Checker
   - [ ] Markdown PDF
   - [ ] Color Picker
   - [ ] C# FixFormat
   - [ ] C# Namespace Autocompletion
   - [ ] C# Model to Builder
   - [ ] Roslynator
     - TODO: Nullable 결과를 Editor에서 확인할 수 있는 것 찾기
   - [ ] .NET Core Tools : "Build, Run, Execute" Context 메뉴 제공
   - [ ] vscode-solution-explorer
   - [ ] Dotnet core commands : dotnet Command 명령어을 Palette에서 처리한다.
   - [ ] dotnet : dotnet Command 명령어을 Palette에서 처리한다.
   - [ ] .NET Core Add Reference : 프로젝트 참조를 .csproj 파일의 Context 메뉴 제공
1. Icons
   - [x] Studio Icons

1. Markdown
   - [x] [Markdown All in One](https://marketplace.visualstudio.com/items?itemName=yzhang.markdown-all-in-one) 설치
     - 미리보기: Ctrl + Shift + V
   - [x] [markdownlint](https://marketplace.visualstudio.com/items?itemName=DavidAnson.vscode-markdownlint) 설치
     - Markdown 작성 코멘트
1. Diagram
   - [x] [PlantUmlClassDiagramGenerator](https://github.com/pierre3/PlantUmlClassDiagramGenerator)
     - dotnet tool을 이용하여 설치한다.

       ```shell
       dotnet tool install --global PlantUmlClassDiagramGenerator --version 1.2.0
       ```

     - 프로젝트 단위로 PlantUML 파일 만들기
  
       ```shell
       puml-gen 입력경로 출력경로 -dir -excludePaths bin,obj -allInOne
       puml-gen .\01 .\01\UMLs -dir -excludePaths bin,obj -allInOne
       ```

1. PlantUML
   - [x] [PlantUML](https://github.com/qjebbs/vscode-plantuml) 설치
   - [x] [Graphviz](https://graphviz.gitlab.io/_pages/Download/Download_windows.html) 다운로드 및 설치
     - VS Code 환경 설정
       - [PlantUML extension for Visual Studio Code on Windows only working with sequence diagrams](https://stackoverflow.com/questions/53856294/plantuml-extension-for-visual-studio-code-on-windows-only-working-with-sequence)

       ```config
       {
           "plantuml.commandArgs": [
              "-DGRAPHVIZ_DOT=C:/Program Files (x86)/Graphviz2.38/bin/dot.exe"
           ]
       }  
       ```

     - 미리보기: Alt + D

## F# 개발 환경

### F# - Visual Studio Code Extension

1. Dev Tools
   - [x] Ionide-fsharp
     - F# 전용 솔루션 탐색기, 파일 순서(위/아래) 제어를 제공한다. 

## Java 개발 환경

### Java 개발 환경 구성하기

1. JDK 최신 버전 설치하기.
   - [JDK 최신 버전](https://www.oracle.com/technetwork/java/javase/downloads/index.html)을 다운로드 받는다.
   - 2020-01-11(토) 기준으로 13.0.1이 최신 버전이다.
   - 기본 설치 경로: C:\Program Files\Java\jdk-13.0.1\
1. Maven 최신 버전 설치하기
   - [Maven 치신 버전](https://maven.apache.org/download.cgi)을 다운로드 받는다.
   - 2020-01-11(토) 기준으로 3.6.3이 최신 버전이다.
   - "C:\Apache\apache-maven-3.6.3" 경로에 압축을 해제한다(경로에 공백이 없어야 한다).

   ```shell
   C:\Apache\apache-maven-3.6.3\bin\mvn.cmd
   ```

1. "환경 변수 > 시스템 변수" 추가하기
   - JAVA_HOME: C:\Program Files\Java\jdk-13.0.1
   - JDK_HOME: C:\Program Files\Java\jdk-13.0.1
   - Path: ... ;%JAVA_HOME%\bin;C:\Apache\apache-maven-3.6.3\bin
1. Java 버전 확인하기
   - java -version
  
   ```shell
   C:\Users\HyungHo.Ko>java -version
   java version "13.0.1" 2019-10-15
   Java(TM) SE Runtime Environment (build 13.0.1+9)
   Java HotSpot(TM) 64-Bit Server VM (build 13.0.1+9, mixed mode, sharing)
   ```

1. Maven 버전 확인하기
   - mvn -version

   ```shell
   C:\Users\HyungHo.Ko>mvn -version
   Apache Maven 3.6.3 (cecedd343002696d0abb50b32b541b8a6ba2883f)
   Maven home: C:\Apache\apache-maven-3.6.3\bin\..
   Java version: 13.0.1, vendor: Oracle Corporation, runtime: C:\Program Files\Java\jdk-13.0.1
   Default locale: ko_KR, platform encoding: MS949
   OS name: "windows 10", version: "10.0", arch: "amd64", family: "windows"
   ```

1. VS Code 설치하기
   - https://code.visualstudio.com/ 사이트를 방문하여 최신 버전을 설치한다.
   - 기본 옵션으로 설치한다.

1. VS Code 확장 도구 설치하기
   - 단축키: Ctrl + Shift + X
   - "Java Extention Pack"을 설치한다(추가적으로 5개 확장 도구가 함께 설치된다).
     - Java Dependensy Viewer
     - Language Support for Java(TM) by Red Hat
     - Debugger for Java
     - Java Test Runner
     - Maven for Java

1. VS Code 환경 변수 설정하기
   - 단축키: Ctrl + ,
   - Maven과 Java 경로를 추가한다.

   ```shell
   {
       "maven.executable.path": "C:/Apache/apache-maven-3.6.3/bin/mvn.cmd",
       "java.home": "C:/Program Files/Java/jdk-13.0.1"
   }
   ```

### hello 프로젝트 만들기

1. Palette로 프로젝트 만들기
   - Ctrl + Shift + P
   - Maven: Create Maven Project  
   - maven-archetype-quickstart  
   - 1.4  
   - 프로젝트를 생성할 상위 폴더을 선택한다.  
   - (Maven 시작)  
   - groupId 입력 요구에 "hello"을 입력한다.  
   - artifactId 입력 요구에 "hello"을 입력한다.  
   - version' 1.0-SNAPSHOT와 package 입력 요구는 Enter로 기본값을 사용한다.  
   - (Maven 완료)  
1. App.java 파일 열기
   - "./src/main/java/hello/App.java" 파일을 연다.
1. hello 프로젝트 실행하기
   - Visual Studio Code
     - F5 또는 Ctrl + F5
   - 콘솔
     - -cp <class search path of directories and zip/jar files>

     ```shell
     java -cp .\target\classes hello.App
     ```

   - 콘솔 & Maven

     ```shell
     mvn install
     java -cp .\target\hello-1.jar hello.App
     ```

### 의존성 있는 프로젝트 만들기

1. 의존성 추가하기
   - 단축키: Ctrl + Shift + P
   - Maven: Add a dependency
   - 추가할 프로젝트를 선택한다(예. hello).
   - 추가할 의존성을 검색한다(예. commons-codec).
   - 검색된 의존성을 선택한다(예. commons-codec commons-codec).
   - 의존성이 추가된다.
   - pom.xml 파일에서 의존성을 확인한다.

     ```xml
     <project ...>
       <dependencies>
         <dependency>
           <groupId>commons-codec</groupId>
           <artifactId>commons-codec</artifactId>
           <version>20041127.091804</version>
         </dependency>
       </dependencies>
     </project>
     ```

   - verion을 "20041127.091804"에서 "1.13"으로 변경한다.

     ```xml
     <version>1.13</version>
     ```

1. Maven 의존성 설치하기
   - 의존성 설치하기

     ```xml
     mvn install
     ```

   - 의존성 확인하기
     - Maven 경로
       - %USERPROFILE%\.m2\repository
       - 예. C:\Users\Hyungho.Ko\.m2\repository
     - 의존성 경로 
       - 예. C:\Users\Hyungho.Ko\.m2\repository\commons-codec\commons-codec\1.13
   - 의존성을 출력 경로에 포함 시키기(안됨)

     ```xml
        <plugin>
          <artifactId>maven-dependency-plugin</artifactId>
          <executions>
            <execution>
              <phase>process-sources</phase>
              <goals>
                <goal>copy-dependencies</goal>
              </goals>
              <configuration>
                <outputDirectory>${targetdirectory}</outputDirectory>
              </configuration>
            </execution>
          </executions>
        </plugin>
    ```

    - 의존성을 jar 파일에 포함 시키기

      ```xml
<plugin>
    <artifactId>maven-assembly-plugin</artifactId>
    <version>3.1.1</version>
    <configuration>
        <descriptorRefs>
            <descriptorRef>jar-with-dependencies</descriptorRef>
        </descriptorRefs>
    </configuration>
    <executions>
        <execution>
            <id>make-assembly</id>                        <!-- this is used for inheritance merges -->
            <phase>package</phase>                        <!-- bind to the packaging phase -->
            <goals>
                <goal>single</goal>
            </goals>
        </execution>
    </executions>
</plugin>
      ```

### Reference URLs

- [Java Project Management in VS Code](https://code.visualstudio.com/docs/java/java-project)
- [Visual Studio Code 에 Java 개발 환경 만들기](https://soolper.tistory.com/6)
- [Visual Studio Code 에서의 Java 한글 인코딩 문제](https://soolper.tistory.com/7?category=768175)
- [Visual Studio Code의 Java 확장을 이용한 간단한 프로젝트 구축](https://www.sysnet.pe.kr/Default.aspx?mode=2&sub=0&detail=1&pageno=0&wid=11980&rssMode=1&wtype=0)

### TODO

1. hello 예제 작성하여 추가하기
1. 의존성 예제 작성하여 추가하기
