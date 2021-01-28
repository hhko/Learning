## Chaper 3. UI와 DB 연동하기

## 사용하기
1. 리소스 추가 : `<ResourceDictionary Source="/WpfCommon;component/Images.xaml"/>`
   ```xaml
   <Application x:Class="Ch03_Step1_ApplicaionService.Desktop.App"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:local="clr-namespace:Ch03_Step1_ApplicaionService.Desktop"
                StartupUri="MainView.xaml">
       <Application.Resources>
           <ResourceDictionary>
               <ResourceDictionary.MergedDictionaries>
                   <ResourceDictionary Source="/WpfCommon;component/Images.xaml"/>
               </ResourceDictionary.MergedDictionaries>
           </ResourceDictionary>
       </Application.Resources>
   </Application>
   ```

## 참고 사이트
- [여러개의 ResourceDictionary를 한번에 참조하기](https://oksujay1127.tistory.com/87)