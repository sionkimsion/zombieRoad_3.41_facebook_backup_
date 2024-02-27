# zombieRoad_3.141
unity 3.141 ver


1. 페이스북 14.0 ndk 버전

2. 플레이 시 오류 없음.

3. 빌드 시 오류 있음.

Building Library\Bee\artifacts\Android\d8kzr\libil2cpp.so failed with output:
Library/Bee/artifacts/Android/d8kzr/zgmd_ity.Canvas.o: In function `CanvasJSWrapper_init_m7F37E8D602676BCF848A03B7E02C9FBECE38281F':

Building Library\Bee\artifacts\Android\iz17e\libil2cpp.so failed with output:

BuildFailedException: Incremental Player build failed!

Build completed with a result of 'Failed' in 95 seconds (95423 ms)
UnityEngine.GUIUtility:ProcessEvent (int,intptr,bool&)

UnityEditor.BuildPlayerWindow+BuildMethodException: 4 errors
  at UnityEditor.BuildPlayerWindow+DefaultBuildMethods.BuildPlayer (UnityEditor.BuildPlayerOptions options) [0x002da] in <36f62d8e760b48f7af5d32916f997ce1>:0 
  at UnityEditor.BuildPlayerWindow.CallBuildMethods (System.Boolean askForBuildLocation, UnityEditor.BuildOptions defaultBuildOptions) [0x00080] in <36f62d8e760b48f7af5d32916f997ce1>:0 
UnityEngine.GUIUtility:ProcessEvent (int,intptr,bool&)


4. 일반 빌드 (64 이런거 없이) 시 빌드 성공함

Build completed with a result of 'Succeeded' in 65 seconds (65242 ms)
UnityEngine.GUIUtility:ProcessEvent (int,intptr,bool&)



5. 유니티 실행 시 아래와 같은 경고 메세지 있음.

Assets\FacebookSDK\Examples\Windows\FBWindowsPurchaseManager.cs(72,9): warning CS0618: 'WWW' is obsolete: 'Use UnityWebRequest, a fully featured replacement which is more efficient and has additional features'


Assets\FacebookSDK\Examples\Windows\FBWindowsPurchaseManager.cs(72,23): warning CS0618: 'WWW' is obsolete: 'Use UnityWebRequest, a fully featured replacement which is more efficient and has additional features'


Assets\FacebookSDK\Examples\Windows\FBWindowsLoginManager.cs(129,9): warning CS0618: 'WWW' is obsolete: 'Use UnityWebRequest, a fully featured replacement which is more efficient and has additional features'


Assets\FacebookSDK\Examples\Windows\FBWindowsLoginManager.cs(129,23): warning CS0618: 'WWW' is obsolete: 'Use UnityWebRequest, a fully featured replacement which is more efficient and has additional features'


 File C:\Users\a\.android\repositories.cfg could not be loaded.
System.Threading.ThreadHelper:ThreadStart ()
