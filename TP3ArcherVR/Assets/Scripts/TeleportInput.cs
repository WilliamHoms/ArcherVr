using UnityEngine;
using System.Collections;

public class TeleportInput : MonoBehaviour {
    //id du button centrale. ou touchpad
    private Valve.VR.EVRButtonId CenterButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;

    //référence au trackedObject script de Valve
    private SteamVR_TrackedObject trackedObj;
    //check si y'a un controller d'allumer et lui assigne un index
    private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }

    public GameObject playerCage;
    //référence au script de la cage;
    public TeleportCage playerCageScript;

    //permet de donner une destination en appuyant;
    private string destinationToPass;

	void Start () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();

        playerCageScript = playerCage.GetComponent<TeleportCage>();

	}
	

	void Update () {



        //TODO: faire que le téléporte change le state du joueur. Enregistrer la position sur laquelle on est en state ?
        //si on touche le bouton on se téléporte
        if (controller.GetPressDown(CenterButton)) {

            //teleporte toi
            if (playerCageScript.state == "God")
            {
                playerCageScript.selected = destinationToPass;
            }


            playerCageScript.activateTeleport = true;

        }
	}

    void OnTriggerStay(Collider col)
    {

        //on check le tag de ce avec quoi on collide et on change la variable selected du script Cage.
        if (col.gameObject.CompareTag("TourAvant"))
        {
            destinationToPass = "TourAvant";
        }
        else if (col.gameObject.CompareTag("TourArriere"))
        {
            destinationToPass = "TourArriere";
        }
        else if (col.gameObject.CompareTag("TourMilieu"))
        {
            destinationToPass = "TourMilieu";
        }else
        {
            destinationToPass = "No selection";
        }


    }




}
