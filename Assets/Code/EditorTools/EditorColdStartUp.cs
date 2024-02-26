using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;
using System;

public class EditorColdStartUp : MonoBehaviour
{

    [SerializeField]
    private GameSceneSO _thisSeneSO;
    [SerializeField]
    private GameSceneSO _persisitentSenceSO;

    [SerializeField]
    private AssetReference _coldStartUpChannelSO;

    [SerializeField]
    private VoidEventChannelSO _OnColdStartReady;

    private bool isColdStart = false;

    private void Awake()
    {
        if (!SceneManager.GetSceneByName(_persisitentSenceSO.sceneReference.editorAsset.name).isLoaded) {
            isColdStart = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isColdStart) {
            //通知Persistent中的ScenLoader 加载要加载的场景
            _persisitentSenceSO.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += OnPersisitentLoaded; 
        }   
    }

    private void OnPersisitentLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        _coldStartUpChannelSO.LoadAssetAsync<LoadEventChannelSO>().Completed += OnColdStartUpChannelLoaded;
    }

    private void OnColdStartUpChannelLoaded(AsyncOperationHandle<LoadEventChannelSO> obj)
    {
        if (_thisSeneSO != null) {
            obj.Result.RaiseEvent(_thisSeneSO);
        }
    }
}
