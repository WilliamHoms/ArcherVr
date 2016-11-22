using UnityEngine;
using System.Collections;

public class ActivateTower : MonoBehaviour {

    private Tower towerscript;

    bool activateTower = false;
    bool cooldown = false;

    public float activateTime = 5f;
    public float waitTilNextActivate= 10f;


    float timerActivate;
    float activateCooldown;

    Renderer[] rendererChildren;


    void Start () {
        towerscript = GetComponent<Tower>();

        timerActivate = activateTime;
        activateCooldown = waitTilNextActivate;
        rendererChildren = GetComponentsInChildren<Renderer>();

	}
	

	void Update () {
        //si on est pas en cooldown et que la tour est activable
        if (activateTower && !cooldown)
        {
            timerActivate -= Time.deltaTime;
            //mettre un matériel pour dire qu'elle est active;
            foreach (var r in rendererChildren)
            {
                r.material.color = Color.green;
            }

            //on active le script de visée de la tour;
            towerscript.awake = true;
            //si le temps d'activation est à zero on la met en cooldown et on désactive la tool;

            if (timerActivate <= 0) {

                //remettre le timer à valeur défaut
                timerActivate = activateTime;

                cooldown = true;
                towerscript.awake = false;
                activateTower = false;

            }
        }

        if (cooldown)
        {
            activateCooldown -= Time.deltaTime;
            //matériel tour désactivée
            foreach (var r in rendererChildren)
            {
                r.material.color = Color.red;
            }
           

            if (activateCooldown <= 0)
            {
                foreach (var r in rendererChildren)
                {
                    r.material.color = Color.blue;
                }

                //remettre le timer à valeur défaut
                activateCooldown = waitTilNextActivate;
                //tour normale

                cooldown = false;
            }

        }

	    
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            if (!cooldown)
            {
                //activer la tour
                activateTower = true;
            }
            Destroy(col.gameObject);
        }
    }
}
