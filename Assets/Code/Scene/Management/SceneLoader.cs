using System;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;


/// <summary>
/// 场景加载器，负责加载主菜单或其他游戏场景
/// </summary>
public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    private GameSceneSO _gamePlaySceneSO;
    [Header("监听")]
    [SerializeField]
    private LoadEventChannelSO _loadMenuChannel;
    [SerializeField]
    private LoadEventChannelSO _loadLoationChannel;
#if UNITY_EDITOR
    [SerializeField]
    private LoadEventChannelSO _coldStartUpChannnel;
#endif
    [Header("发送广播")]
    [SerializeField]
    private VoidEventChannelSO _onScenReadyChannel;

    private GameSceneSO _currentLoadedScene;
    private AsyncOperationHandle<SceneInstance> _loadGamplayAsyncHandle;
    private SceneInstance _gameManagerScene = new SceneInstance();


    //持久层加载后注册加载主菜单的事件监听，游戏启动器InitializationLoader 加载后会发送消息给持久层Persistent启动主菜单
    void Start()
    {
        _loadMenuChannel.OnLoadingRequested += LoadMenu;
        _loadLoationChannel.OnLoadingRequested += LoadLocation;
        _coldStartUpChannnel.OnLoadingRequested += OnEditorColdStartUp;
    }

    #if UNITY_EDITOR
    /// <summary>
    /// 编辑器调试模式下启动某个游戏场景时使用
    /// </summary>
    private void OnEditorColdStartUp(GameSceneSO scenSO, bool showLoadingScreen, bool fadeIn)
    {
        _currentLoadedScene = scenSO;
        if (scenSO.sceneType == GameSceneSO.GameSceneType.Location) {
            _loadGamplayAsyncHandle = _gamePlaySceneSO.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
            _loadGamplayAsyncHandle.WaitForCompletion();
            _gameManagerScene = _loadGamplayAsyncHandle.Result;
            StartGame();
        }
    }
    #endif


    private void StartGame()
    {
        _onScenReadyChannel.RaiseEvent();
    }

    //加载主菜单
    private void LoadMenu(GameSceneSO sceneSo, bool showLoadingScreen, bool fadeIn)
    {
        sceneSo.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += OnMenuLoadDone;
    }

    //具体场景加载
    private void LoadLocation(GameSceneSO arg0, bool arg1, bool arg2)
    {
       
    }

    private void OnMenuLoadDone(AsyncOperationHandle<SceneInstance> obj)
    {
        
    }

}
