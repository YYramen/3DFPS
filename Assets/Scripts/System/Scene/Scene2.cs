using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

public class Scene2 : MonoBehaviour
{
    public void SetArguments(int param1, List<string> param2)
    {
        Debug.Log($"param1: {param1}, param2: {param2}");
    }
}
