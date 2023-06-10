using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using System.Threading.Tasks;

public class Scene1 : MonoBehaviour
{
    public async Task Test()
    {
        // シーンBをロードしてコンポーネントを取得
        var scene2 = await LoadScene.Load<Scene2>("SceneLoadTest 2");

        // 任意のメソッド呼び出し (タイミングはsceneBのAwakeの後、Startの前)
        // SceneAのGameObjectはDestroy済みでnullになるので注意
        scene2.SetArguments(123, new List<string> { "abc", "あいうえお" });
    }
}
