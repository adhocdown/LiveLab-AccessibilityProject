using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


public class FakeRandomSpawn : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;  // permanent list of possible objects to spawn

    // make another list in the game that stores all of your INSTANTIATED objects 
    // so you can delete them if needed 

    public List<Transform> location; // = List<Transform>();

    List<int> numList = new List<int>();        // our actual list we use
    List<int> randomNumList = new List<int>();  // a temporary list used for randomization!

    public bool isRandomized;
    private float timeToSpawn = 3f;
    public float timePassed = 0f;


    public void Start()
    {
        RandomizeList(); // create a randomized list in the beginning
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int index = numList[0];
            Instantiate(objectsToSpawn[index], location[index].position, Quaternion.identity);
            Debug.Log("Object #" + index + " Instantiated.");
            numList.RemoveAt(0);
        }
    }

    public void RandomizeList()
    {
        // Add index number values to our temporary array
        for (int i = 0; i < objectsToSpawn.Count; i++)
        {
            randomNumList.Add(i);
        }

        while (randomNumList.Count != 0)
        {
            //Random.InitState((int)System.DateTime.Now.Ticks);
            int randomIndex = Random.Range(0, randomNumList.Count);

            numList.Add(randomNumList[randomIndex]);
            randomNumList.RemoveAt(randomIndex);
        }

        // checking list output 
        for (int i = 0; i < objectsToSpawn.Count; i++)
        {
            Debug.Log(numList[i]);
        }

        //Instantiate(objectsToSpawn[0], location[0].position, Quaternion.identity);
    }

    /*
    public void spawnObject()
    {
        // Change this to JUST spawn one object
        for (int i = 0; i < objectsToSpawn.Count; i++)
        {
           
        }

        int index = numList[i];
        Instantiate(objectsToSpawn[index], location[i].position, Quaternion.identity);

    }
    */

    
    public void SpawnAllObjects()
    {
        for (int i = 0; i < objectsToSpawn.Count; i++)
        {
            int index = numList[i];
            Instantiate(objectsToSpawn[index], location[i].position, Quaternion.identity);
            // Have an empty gameobject (a parent) in your scene.
            // make the instantiated object a CHILD of that parent.
            ///// protip: You can use parentTransform.GetChild(0) to get the first child
            ///// and then kill the child whenever the user shouldn't see it 
        }
    }
}