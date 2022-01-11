# MSTest 설명
> 여기서는 MSTEST의 간단한 설명(자주 사용할 것들만 적는다)

## MS 테스트 프로젝트 생성

1. 실행 프로젝트 생성
   * 문자를 입력하면 첫번째 글자가 대문자인지(로마자) 판별하는 프로그램을 만드는 것을 목표로 한다고 가정한다.
   * 실행 프로젝트 **ShowCase** 프로젝트를 생성
2. **ShowCase** 에서 사용하며 테스트 대상이 될 라이브러리 프로젝트 **LibrariesProject** 생성
   * String에는 첫번째 글자가 대문자인지 반환하는 것이 없기에 첫글자가 대문자인지 확인하고 bool 로 반환한다고 가정하자
3. 테스트 프로젝트 생성
   * 테스트 프로젝트를 생성한다 이때 MSTEST를 사용한다(framework 와 core 이후를 잘 구별하자)
   ![image](https://user-images.githubusercontent.com/39551265/148309277-ab548a4f-38c4-4986-b6f8-9b2a04a97f08.png)
4. 실행 프로젝트, 테스트 프로젝트에 라이브러리 프로젝트 **참조 추가**(라이블러리를 사용해야하니 당연히 참조를 추가해야한다.)

## 테스트 메소드 생성

1. 테스트 프로젝트의 **[TestClass]** 가 생성되었을 것이다 하나의 테스트 메소드를 생성하려면 아래 소스코드를 늘리면 된다.
```C#
[TestMethod]
public void TestMethod()
{
    Assert.IsTrue(true);
}
```

2. 다른 방법은 테스트하려는 메소드의 이름을 마우스 오른쪽 클릭 -> 단위 테스트 만들기를 클릭하여 나오는 메뉴를 통해서도 만들 수 있다.
![image](https://user-images.githubusercontent.com/39551265/148723216-2c18539d-569a-41ab-99e2-e98732d6de63.png)

## 테스트 메소드 설정
1. 테스트 결과 비교
   * 우선 테스트 하려는 메소드를 이용해서 결과 값을 받아오자 이때 테스트 메소드 안에 직접 변수, 배열 등을 이용해 값을 넣어 메소드를 호출한다. 
   * 호출한 결과를 `Assert` 문에 집어넣어 결과를 확인한다. -> [Assert 종류와 용도 확인](https://www.meziantou.net/mstest-v2-exploring-asserts.htm)
2. 테스트 케이스 설정
   * 테스트 메소드를 `[DataTestMethod]`로 지정하면 ('[TestMethod]' 대체) 
   * 위 설정을 하면 `[DataRow]`를 이용하여 메소드에 변수값에 값을 넣을 수 있다(이름도 같이 지정할 수 있지만 그냥 순서대로 넣자)
   * [DataRow]는 위에서부터 아래로 순서대로 모든케이스를 실행하게 된다.
   * 아래 소스를 실행하면 테스트 메소드 안의 value 값은 asdf -> as -> abc -> abcde 순서로 값을 갖고 테스트를 실행하게 된다
   
   ```C#
   [DataTestMethod]
    [DataRow("asdf")]
    [DataRow("as")]
    [DataRow("abc")]
    [DataRow("abcde")]
    public void IsShortString(string value)
   ```   
   * `[TimeOut]` 메소드에 시간제한을 둬서 성공여부를 판단할 수 있는 설정이다. 아래 소스대로 하면 2초 안에 실행이 되어야 성공으로 간주한다.
   ```c#
   [TestMethod]
        [Timeout(2000)] //밀리세컨드
        public void TestTimeout2()
        {
            // OK
            System.Threading.Thread.Sleep(1000);
        }
   ```
   
3. 파일에서 테스트 값 불러오기
   *  파일애서 값을 불러오는 건 기본적으로 일반 프로젝트랑 똑같이 작성하면 된다. 파일을 읽어오고 파일에 저장된 데이터에 맞게 객체로 읽어와 그것을 이용하여 테스트 메소드에서 사용 가능하다
   *  만약 테스트 메소드의 값을 순서대로 호출하고 싶다면 yeild를 이용하면 된다.
   *  예제 테스트 메소드는 `TestJson`이다
   * 덤으로 FrameWork 까지 사용이 가능한 방법으로 csv 파일을 불러오는 방법이 있는데
     1. system.Data 참조추가
     2. `[TestMethod]` 에 추가로 `[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @"test.csv", "test#csv", DataAccessMethod.Sequential)]`를 추가한다.
     3. csv 파일을 생성후 테스트 프로젝트 시작위치에 같이 넣어둔다(파일위치 설정은 알거라고 생각하지만 파일설정 속성 출력 디렉터리 복사에서 새 버전이면 복사를 설정하자)
     4. `public TestContext TestContext { get; set; }` 이걸 테스트 메소드 별도로 선언을하여 TextContext를 생성한다.
     5. `TestContext.DataRow["TestCase"].ToString()` 이런식으로 DataRow 안에 csv파일의 열 이름을 가져올 수 있다.(위에서 아래로 행별로 실행이 된다) 

## 테스트 실행
1. 테스트 메소드를 완성했다면 테스트 프로젝트를 오른쪽 클릭해 **테스트 실행**을 실행하거나 테스트 탐색기를 열어 실행 표시의 버튼을 눌러 실행이 가능하다.
2. 각 테스트 메소드의 이름을 오른쪽 클릭해서 한개 씩 실행 가능하다.
3. 만약 디버그가 필요하다면 중단점을 설정해 디버그를 실행하면 된다.
4. 결과는 아래 이미지와 비슷하게 나온다.
![image](https://user-images.githubusercontent.com/39551265/148731259-016bb17f-2105-413e-aef2-c6165f57904e.png)


## Live Unit Testing

1. Visual Studio Enterprise 전용
2. 미리 작성한 테스트 메소드가 존재한다면 Live Unit Testing을 실행했을시 테스트 대상 메소드(제작하려는 소스)를 수정할시 실시간으로 테스트 결과를 알 수 있게 한다.(테스트 > Live Unit Testing > 시작)

## Code Coverage(코드 검사)
1. 테스트 탐색를 선택한 상태에서 상단메뉴의 테스트 -> 모든 테스트에 대한 코드 분석을 선택
2. 코드 검사 결과창이 나올것이다.
3. 각 DLL안에 클래스, 메서드 등의 검사 블록의 개수 등이 표시된다.
4. 검사되지 않은 영역을 확인하고 싶다면 검사하려는 매서드를 더블클릭하면 확인이 가능하다.
 <img width="576" alt="inteliTestUsed" src="https://user-images.githubusercontent.com/39551265/148185739-10e9b062-029a-43c5-bc7f-dc080400e272.png">


## 그 외
1. 세팅 불러오기
    * 세팅은 다른 프로젝트 처럼 app.config(framework) 나 appsettings.json(croe 이후) 파일등을 이용하고 같은 방법으로 세팅 데이터를 불러올 수 있다.
2. private 메소드도 실행하고 싶을 경우가 있을 것이다 그 경우 PrivateObject 를 찾아보자
3. 그외 아직 제작하지 않은 메소드를 대처하여 프로젝트를 제작도록 도와주는 Fake 나 목 등은 이후에 별도로 작성할 예정