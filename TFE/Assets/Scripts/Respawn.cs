using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    //Position du joueur
    [SerializeField]
    private Transform player;
    
    //position de point de respawn
    public Transform respawnPoint;

    //Quand quelque chose rentre en collision
    private void OnTriggerEnter(Collider other)
    {
        //Si l'objet a le tag Player
        if(other.CompareTag("Player"))
        {
            //La position de l'objet = respawnPoint
            player.transform.position = respawnPoint.transform.position;
            Physics.SyncTransforms();
        }
    }
}
