using UITAdventure.Core.Singletons;
using Unity.Netcode;
using UnityEngine;

public class SpawnerControl : NetworkSingleton<SpawnerControl>
{
    [SerializeField]
    private GameObject objectPrefab;

    [SerializeField]
    private int maxObjectInstanceCount;

    [SerializeField]
    public NetworkManager networkManager;

    [SerializeField]
    public GameObject quad;

    private void Awake()
    {
        networkManager.OnServerStarted += () =>
        {
            NetworkObjectPool.Instance.InitializePool();
        };
    }

    public void SpawnObjects()
    {
        if (!IsServer) return;
        
        //define area to spawn enemies
        MeshCollider c = quad.GetComponent<MeshCollider>();
        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < maxObjectInstanceCount; i++)
        {
            GameObject go = NetworkObjectPool.Instance.GetNetworkObject(objectPrefab).gameObject;

            //get area of quad object
            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);
            pos = new Vector2(screenX, screenY);
            
            go.transform.position = pos;
            go.GetComponent<NetworkObject>().Spawn();
        }
    }
}