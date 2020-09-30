using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGenerator : MonoBehaviour
{
    public float Speed
    {
        get => _speed;
        set
        {
            CancelInvoke();
            _speed = value;
            Invoke(_spawnFunc, SpawnDelay);
        }
    }
    public float SpawnDelay { get
        {
            float i = 10 / Speed;
            return i + Random.Range(-i/2, i/2); 
        }
    }

    [SerializeField] private Transform generationPoint = null;
    [SerializeField] private GameObject prefab= null;
    [SerializeField] private float _speed = 1f;

    [SerializeField] private HitKey[] hitKeys = null;

    private const string _spawnFunc = "SpawnKey";

    private void Start()
    {
        Invoke(_spawnFunc, SpawnDelay);
    }

    public void SpawnKey()
    {
        GameObject ins = Instantiate(prefab, generationPoint.position, Quaternion.identity, transform);
        ins.name = "Key";
        ins.GetComponent<HitKeyComponent>().Initialize(hitKeys[Random.Range((int)0, (int)hitKeys.Length)], 1f, Speed);
        Invoke(_spawnFunc, SpawnDelay);
    }


    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(generationPoint.position, 1f);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}
