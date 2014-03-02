using UnityEngine;
using System.Collections;

public class MoveToCenter : Monobehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        foreach (GameObject Person in People)
        {
            transform.position = Vector3.MoveTowards(Person.transform.position, new Vector2(Screen.Width/2, Screen.Height/2), Person.wSpeed); // Move along path at set speed
            CheckCollision();
        }
    }

    void CheckCollision()
    {
        if (1 /*Person and hydro colliders colliding*/)
        {
            // Check if they hit a door
            DestroyPerson(Person);
            People.Sort;
        }
    }
}
