using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public Transform spawn_pos;
    public GameObject GroundPlaneObj;

    public float TimeToSpawn;
    public float TimeBtwnWave;

    public static GroundSpawner instance;

    void Start()
    {
        
    }

    private void Awake()
    {
        instance=this;
    }
    void Update()
    {
        if(Time.time > TimeToSpawn)
        {
            SpawnGround();
            TimeToSpawn = Time.time + TimeBtwnWave;
        }   
    }

    public void SpawnGround()
    {
        Instantiate(GroundPlaneObj, spawn_pos.position, Quaternion.identity);
        spawn_pos.position = new Vector3(spawn_pos.position.x, spawn_pos.position.y, spawn_pos.position.z + 30f);
    }
}
