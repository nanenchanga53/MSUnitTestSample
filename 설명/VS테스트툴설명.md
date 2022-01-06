# 비주얼스튜디오 테스트 툴 설명
## [종류](https://docs.microsoft.com/ko-kr/visualstudio/test/improve-code-quality?view=vs-2022)
    
1. 단위 테스트(Unit Test)
2. IntelliTest
3. Live Unit Testing
4. Microsoft Fakes(단위 테스트 격리)
5. Code Coverage

## [단위 테스트(Unit Test)](https://docs.microsoft.com/ko-kr/visualstudio/test/unit-test-basics?view=vs-2022)

 * 한 줄 정리  
> 특정 메서드를 자신이 원하는 데이터로 실행해 보기 위한 별도 프로젝트(모든 VS버전과 등급에서 사용가능)
 
 * 단위 테스트의 일반적 흐름
   - 검증할 매서드를 생성하고 초기화 그리고 메서드에 전달할 값을 준비
   -  검증할 메서드 호출
   -  테스트 결과물을 통해 검증

* FIRST 원칙
  - Fast: 테스트는 빠르게 동작하여 자주 실행시킬 수 있어야 한다.
  - Independent: 각 테스트는 독립적이어야 한다.
  - Repeatable: 어느 환경에서도 반복 가능해야 한다.
  - Self-Validating: 테스트는 성공 또는 실패로 bool 값으로 결과를 내어 자체적으로 검증되어야 한다.
  - Timely: 테스트는 적시에(실제 코드 구현하기 직전에) 구현해야 한다. 


 * 용어정리
   - 테스트 클래스
     + 테스트를 수행할 프로젝트이며 별도의 프로젝트로 만드는게 일반적
     + 라이브러리 프로젝트여야함 
   - 테스트 프로젝트
     + 테스트 프로젝트에서 정의한 클래스 
   - 테스트 실행자(TEST RUNNER)
     +  모든 유닛테스트 프레임워크들은 이 테스트 실행자를 제공하고, 각자의 문법을 제공한다. 이 문법들은 외형에 있어서 차이가 있을 지 몰라도 기본적으로 검증과 관련이 있다.

 * 종류
   1. MSTEST
      * VS를 설치하면 기본적으로 제공해주는 단위 테스트 프로젝트이다
      * 수명에 대한 우려가 적다
      * VS를 사용했을 시 가장 많은 기능을 사용 가능하다(다른 플랫폼간 테스트 지원이 좋다)
      * (예제 소스코드는 전부 MSTEST의 소스코드이다)
      ![image](https://user-images.githubusercontent.com/39551265/148309277-ab548a4f-38c4-4986-b6f8-9b2a04a97f08.png)
  
   2. xUnitTest
      * 비교적 적은 용량으로 사용가능하다(기능이 적다)
      * 다른 테스트 프레임워크에 비해 더 나은 Isolation Test 를(테스트 격리?) 제공한다.
      * 테스트를 실행후 인스턴스를 바로 제거한다.
      ![image](https://user-images.githubusercontent.com/39551265/148309392-d68bd656-4857-4652-98da-27c1530c389c.png)
   3. NUnitTest
      *  JUnit 에서 포트하였기 때문에 JUnit등 다른 프레임워크와의 호환이 쉬움
      *  lambdatest 사이트를 이용한 구측이 위 2개에 비하여 용의
      ![image](https://user-images.githubusercontent.com/39551265/148309326-0c6df0bf-ab57-4e0b-b3de-e2905feeceb7.png)
   4. 그외의 테스트 프레임워크는 다른언어에 사용하자

## [IntelliTest](https://docs.microsoft.com/ko-kr/visualstudio/test/intellitest-manual/?view=vs-2022)
* 한 줄 정리
> .NET FrameWork 전용으로 Enterprise Edition에서만 사용가능하며 메서드 실행에 필요한 인자값의 패턴이나 제약을 지정하면 자동으로 데이터를 생성해 테스트를 할 수 있다.

* 특징
  1. 특성 테스트
     * 기존 테스트의 툴을 이용하여(MSTEST,NUNIT,xUnit) 코드 동작을 수정, 보완 가능 
  2. 단계별 테스트 입력 생성
     * 코드 분석 및 제약 조건을 이용하여 테스트 입력값을 자동으로 생성
  3. IDE 통합
     * Visual Studio IDE에 통합 
  4. 기존 테스트 사례 보완
     * IntelliTest를 사용하여 이미 따르고 있는 기존 테스트 사례를 보완
     * 현재 생성한 테스트 데이터가 테스트 대상 메서드에서 모든 부분에서 사용되는지 확인가능(else if문 등에서 실행되지 않는 구역은 붉은 강조 표시 등의 설정이 가능하다)
     <img width="576" alt="inteliTestUsed" src="https://user-images.githubusercontent.com/39551265/148185739-10e9b062-029a-43c5-bc7f-dc080400e272.png">


## Live Unit Testing
* 한 줄 정리
> 사용자가 코드를 변경할때 실시간으로 단위 테스트를 자동으로 실행
* 특징
  1. 미리 준비된 단위 테스트를 이용 가능
  2. Live Unit Testing을 실행하게 되면 소스코드 변경시 실시간으로 단위 테스트의 결과가 업데이트
## Microsoft Fakes(유닛 테스트 격리)

## Code Coverage
   
## 참고 사이트

* https://docs.microsoft.com/ko-kr/visualstudio/test/?view=vs-2022
* https://m.blog.naver.com/okcharles/222024110730
* https://bb-library.tistory.com/262
* https://mohamedradwan.com/2017/07/05/automated-software-testing/
* https://www.lambdatest.com/blog/nunit-vs-xunit-vs-mstest/