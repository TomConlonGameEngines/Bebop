using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Prefab;
    
    public int radius = 500;
    public float noiseScale = 0.1f;

    public float lower = 0.5f;
    public float upper = 1.0f;

    public static Spawner Instance = null;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        var settings = GameObjectConversionSettings.FromWorld(World.DefaultGameObjectInjectionWorld, new BlobAssetStore());
        var prefab = GameObjectConversionUtility.ConvertGameObjectHierarchy(Prefab, settings);
        var entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

        for (int slice = -radius; slice < radius; slice++)
        {
            for (int row = -radius; row < radius; row++)
            {
                for (int col = -radius; col < radius; col++)
                {
                    var instance = entityManager.Instantiate(prefab);

                // Place the instantiated entity in a grid with some noise
                    var position = transform.TransformPoint(row * 2, slice * 2, col * 2);
                    entityManager.SetComponentData(instance, new LocalToWorld());
                    entityManager.SetComponentData(instance, new Translation {Value = position});
                    entityManager.SetComponentData(instance, new Flow {Value = 0});
                }
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
