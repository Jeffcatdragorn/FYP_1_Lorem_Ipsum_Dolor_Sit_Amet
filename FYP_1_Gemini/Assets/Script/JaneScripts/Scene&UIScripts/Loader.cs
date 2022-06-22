using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private class LoadingMonoBehaviour : MonoBehaviour { }

    public enum Scene //add all scene's names here
    {
        Cats_Scene,
        CipScene,
        FloatingLevel,
        JaneScene,
        MainMenu,
        PrototypeScene,
        ShootingRange,
        SampleScene
    }

    private static Action onLoaderCallBack;
    private static AsyncOperation LoadingAsyncOperation;

    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
