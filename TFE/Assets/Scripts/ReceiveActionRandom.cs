using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReceiveActionRandom : MonoBehaviour
{


    //Choisir quel gameObject il va supprimer
    [SerializeField]
    private GameObject door;

    //Maximum de points de vie
    [SerializeField]
    private int maxHitPoint = 1;

    //Points de vie actuels
    [SerializeField]
    private int hitPoint = 0;

    private int numberTarget = 0;

    private void Start()
    {
        //Au d�but : Points de vie actuels = Maximum de points de vie
        hitPoint = maxHitPoint;
        numberTarget = 9;

    }


    //Permet de recevoir des dommages
    public void GetDamage(int damage)
    {
        //Applique les dommages aux points de vies actuels
        hitPoint -= damage;


        //Si les point de vie sont inf�rieurs � 1 = Supprime l'objet
        if (hitPoint < 1)
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<RandomSpawn>().SetTrue();
            numberTarget -= 1 ;
            //Destroy(gameObject);
        }

        if(numberTarget == 0)
        {
            Destroy(door);
        }
    }
}