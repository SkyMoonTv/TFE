using System.Collections;
using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
  /*  public Vector3[] positions;
    // Start is called before the first frame update
    void Start()
    {
        //Créé un nbr aléatoire compris entre 0 et la variable positions
        int randomNumber = Random.Range(0,positions.Length);
        transform.position = positions [randomNumber];
    } 

    void update()
    {
       
    }
*/

    public GameObject[] target;


    public void SpawnFirstTarget()
    {
        target[0].SetActive(true);
    }
    public void SetTrue()
    {
        int i = Random.Range(0,target.Length);
        target[i].SetActive(true);
    }


}
