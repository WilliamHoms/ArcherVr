using UnityEngine;
using System.Collections;

public class PressBouton : MonoBehaviour {

    Animator boutonAnimator;

    public GameObject prefabBasicTower;
    public GameObject towerSpawnPoint;

    float timer = 3f;
    private bool spawned = false;

    bool spawnTower = false;

    void Start () {
        boutonAnimator = GetComponent<Animator>();

	}
	

	void Update () {

        if (spawnTower) {
            SpawnBasicTower();
            
        }

        if (spawned)
        {
            timer -= Time.deltaTime;

            //TODO: change matériel du bouton pour être grisé;



            if (timer <= 0f)
            {
                timer = 3f;
                //TODO : rechanger le matériel pour celui de base;

                boutonAnimator.SetBool("pushed", false);

                spawned = false;
            }
        }

	
	}

    void OnTriggerEnter(Collider col) {

            //collide avec la manette droite, active l'animation
        if (col.gameObject.name == "Head") {
            Debug.Log("Je marche");
            if (!spawned)
            {
                Debug.Log("Je joue l'Animation du bouton ");
                spawnTower = true;
                spawned = true;
            }
        }
    }

    void SpawnBasicTower() {

        Debug.Log("Je spawn la tour");
        Instantiate (prefabBasicTower, towerSpawnPoint.transform.position, towerSpawnPoint.transform.rotation);
        //Faire jouer anim de spawn.
        //tour.GetComponent<Animator>();
        //tour.SetBool();
        spawnTower = false;
        boutonAnimator.SetBool("pushed", true);
    }
}
