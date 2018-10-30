using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform Target;
    public float VelocityAmount;
    public float AcceleratAmount;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private int amount = 200;
    [SerializeField]
    private float burnRange = 100;

    [HideInInspector]
    public static GameManager GM;

    public static EntityArchetype Bullet;
    public static EntityArchetype BulletMove;

    private EntityManager manager;
    private MeshInstanceRenderer msi;

    private int count = 0;

    void Start()
    {
        GM = this;
        manager = World.Active.GetOrCreateManager<EntityManager>();
        createMeshInstance();
        Bullet = manager.CreateArchetype(typeof(Position),  typeof(MeshInstanceRenderer), typeof(MoveSpeed));
    }

    private void createMeshInstance()
    {
        var GO = GameObject.Instantiate(bulletPrefab);

        msi = new MeshInstanceRenderer();
        msi.material = GO.GetComponent<Renderer>().material;
        msi.mesh = GO.GetComponent<MeshFilter>().mesh;
        Destroy(GO);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
            addShips();
    }

    private void addShips()
    {
        for (var i = 0; i < amount; i++)
        {
            var cubeEntity = manager.CreateEntity(Bullet);

            Vector3 pos = UnityEngine.Random.insideUnitSphere * 100;
            manager.SetComponentData(cubeEntity, new Position { Value = new float3(pos.x, pos.y, pos.z) });

            Vector3 v = pos.normalized * VelocityAmount;
            manager.SetComponentData(cubeEntity, new MoveSpeed { Velocity = new float3(v.x, v.y, v.z) });

            manager.SetSharedComponentData(cubeEntity, msi);
        }
        count += amount;
    }

    private void OnGUI()
    {
        GUILayout.Label(string.Format("Amoun: {0}", count));
    }
}