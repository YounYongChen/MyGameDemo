using UnityEngine;

public class SpawnSystem : MonoBehaviour
{

    [SerializeField]
    private MainCharacter _mainPlayerPrefab;
    [SerializeField]
    private Transform _spawnTransform;

    [SerializeField]
    private TransformAnchor _mainPlayerPos;

    [SerializeField]
    private VoidEventChannelSO _onSendReady;

    private void OnEnable()
    {
        _onSendReady.OnEventRaised += SpawnMainCharacter;
    }

    private void OnDisable()
    {
        _onSendReady.OnEventRaised -= SpawnMainCharacter;
    }

    private void SpawnMainCharacter()
    {
        var mainPlayer =  Instantiate(_mainPlayerPrefab, _spawnTransform.position ,_spawnTransform.rotation);
        _mainPlayerPos.Provide(mainPlayer.transform);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (_spawnTransform == null) {
            _spawnTransform = GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
