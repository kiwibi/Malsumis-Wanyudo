using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChooser : MonoBehaviour
{

    public IntVariable currentLevel;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    // Start is called before the first frame update
    void Start()
    {
    
    }
    // Update is called once per frame
    void Update()
    {
        switch(currentLevel.Value)
        {
            case 1:
                level1.SetActive(true);
                level2.SetActive(false);
                level3.SetActive(false);
                break;
            case 2:
                level1.SetActive(false);
                level2.SetActive(true);
                break;
            case 3:
                level2.SetActive(false);
                level3.SetActive(true);
                break;
        }
    }
}
