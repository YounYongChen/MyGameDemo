using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

/// <summary>
/// 游戏启动器，指定首先加载的场景以及持久层管理器PersisitentManager 所在的Scene。
/// </summary>
public class InitializationLoader : MonoBehaviour
{

    [SerializeField]
    [Header("发送消息的频道")]
    private AssetReference _menuLoadEventChannel;
    [Header("持久层场景以及游戏菜单界面")]
    [SerializeField]
    private GameSceneSO _sceneToload;
    [SerializeField]
    private GameSceneSO _managerScene;

    void Start()
    {
        _managerScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadEventChannel;
    }

    private void LoadEventChannel(AsyncOperationHandle<SceneInstance> obj)
    {
        _menuLoadEventChannel.LoadAssetAsync<LoadEventChannelSO>().Completed += LoadMainMenu;
    }

    private void LoadMainMenu(AsyncOperationHandle<LoadEventChannelSO> obj)
    {
        obj.Result.RaiseEvent(_sceneToload,true);
        int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        //卸载掉该场景
        SceneManager.UnloadSceneAsync(currentSceneBuildIndex);
    }
}
