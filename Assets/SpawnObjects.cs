using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

    public GameObject planetPrefab;
    public GameObject creaturePrefab;
    public int numCreatures;
    private GameObject[] creatures;

	// Use this for initialization
	void Start () {
        Vector3 planetPosition = new Vector3(-10, 0, 100);
        Instantiate(planetPrefab, planetPosition, transform.rotation);
        creatures = new GameObject[numCreatures];
        for (int i = 0; i < numCreatures; i ++) {
            Vector3 creaturePosition = new Vector3(Random.Range(-200, 200), Random.Range(-20, 20), Random.Range(60, 200));
            Quaternion creatureRotation = Random.rotation;
            creatures[i] = Instantiate(creaturePrefab, creaturePosition, creatureRotation);            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
