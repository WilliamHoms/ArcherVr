using UnityEngine;
using System.Collections;

public class TowerAnimateSpawn : MonoBehaviour {

    private Animator animator;
    //string CurrentStateName = "";
    public GameObject basicTowerPrefab;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
        {
            //détruire la tour anim et spawn la vraie tour;

            Instantiate(basicTowerPrefab, transform.position, transform.rotation);

            Destroy(gameObject);
        }

    }
	
}
