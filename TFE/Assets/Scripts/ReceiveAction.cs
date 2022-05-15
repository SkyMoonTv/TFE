using UnityEngine;

public class ReceiveAction : MonoBehaviour
{
    //Maximum de points de vie
    [SerializeField]
    private int maxHitPoint = 1;

    //Points de vie actuels
    [SerializeField]
    private int hitPoint = 0;

    private void Start()
    {
        //Au d�but : Points de vie actuels = Maximum de points de vie
        hitPoint = maxHitPoint;
    }


    //Permet de recevoir des dommages
    public void GetDamage(int damage)
    {
        //Applique les dommages aux points de vies actuels
        hitPoint -= damage;


        //Si les point de vie sont inf�rieurs � 1 = Supprime l'objet
        if (hitPoint < 1)
        {
            Destroy(gameObject);
        }
    }
}