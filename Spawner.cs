using UnityEngine;
using System.Collections;

public class Spawner : Monobehaviour
{
    public float minsTBSpawn; // min time between each person spawning at gametime=0
    public float maxsTBSpawn; // max time between each person spawning at gametime=0
    public float tbSpawnScaling; // rate that minsTBSpawn and maxsTBSpawn increase at per frame
    public float minWSpeed; // min walk speed for people (constant per person)
    public float maxWSpeed; // max walk speed for people (constant per person)
    float tOLastSpawn; // time that the last person was spawned
    List<cPerson> People = new List<cPerson>(); // contains all people objects
    public Transform Person1, Person2, Person3, Person4, Person5;
    enum Prefab { Person1 = 1, Person2, Person3, Person4, Person5 };

    void Start()
    {
    }

    void Update()
    {
        if (tOLastSpawn > maxsTBSpawn) // If max time between spawns procs
        {
            SpawnPerson(); // 100% chance to spawn
        }
        else if (tOLastSpawn > minsTBSpawn) // else, if only min time between spawns procs
        {
            if (RandomSpawn()) // Random chance to spawn
            {
                SpawnPerson();// Spawn a person
            }
        }
        Time.timeSinceLevelLoad;
        minsTBSpawn *= tbSpawnScaling;
        maxsTBSpawn *= tbSpawnScaling;
    }

    bool RandomSpawn()
    {
        Random.Seed = Time.timeSinceLevelLoad; // seed rng
        if (Random.Range(1, 20) = 20) // Chance to spawn a person (called each frame ((e.g. this is 5% per frame))
        {
            SpawnPerson(); // Spawn a person
        }
    }

    void SpawnPerson()
    {
        People.Add(new cPerson()); // create and add new person object to people list
        tOLastSpawn = time.timeSinceLevelLoad;
    }

    void DestroyPerson(Person p)
    {
        People.remove(p);
    }
}

//*****************************************************
//          Class for each person object
//*****************************************************
public class cPerson
{
    private GameObject person;
    private Vector2 startPos;
    private float wSpeed; // actual walk speed
    private int prefabNo;
    private string prefabName;

    public cPerson()
    {
        Random.Seed = Time.timeSinceLevelLoad; // seed rng
        prefabNo = Random.Range(1, 5); // rng get number for prefab
        Prefabs thisPrefab = ((Prefabs)prefabNo); // get prefab name from int
        string prefabName = thisPrefab.ToString(); // convert prefab name to string
        
        this.person = instantiate(Prefabs.prefabName, GetSCoords());
        this.wSpeed = Random.Range(minWSpeed, maxWSpeed);
    }

    //public GameObject Person
    //{
    //    get { return person; }
    //    set { Person = value; }
    //}

    public Vector2 StartPos
    {
        get { return startPos; }
    }

    // Gets spawn position as any point at edge of screen
    public Vector2 GetSCoords()
    {
        Random.Seed = Time.timeSinceLevelLoad; // seed rng
        return Vector2( (Random.Range(1 /*- PrefabSize*/, Screen.Width)),
                        (Random.Range(1 /*- PrefabSize*/, Screen.Height)) );

        /* ( -prefabsize if the objects are anchored in their center so that
         the people spawn off-screen) */
    }
}