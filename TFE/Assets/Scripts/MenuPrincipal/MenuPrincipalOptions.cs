using UnityEngine;
using UnityEngine.UI;

public class MenuPrincipalOptions : MonoBehaviour
{
    public GameObject Panel;
    //bool visible = false;

    public Dropdown DResolution;

    private bool FixeView;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       /* if()
        {
            visible = !visible;
            Panel.SetActive(visible);
        }
        */
            
    }

    public void SetResolution()
    {
        switch (DResolution.value)
        {
            case 0:
                Screen.SetResolution(640, 360, true);
                break;

            case 1:
                Screen.SetResolution(1280, 720, true);
                break;

            case 2:
                Screen.SetResolution(1920, 1080, true);
                break;
        }
    }
}
