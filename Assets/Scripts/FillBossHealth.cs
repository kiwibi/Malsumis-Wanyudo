using UnityEngine;
using UnityEngine.UI;

public class FillBossHealth : MonoBehaviour
{
    public IntReference maxHealth;
    public IntReference health;
    private Image image;

    // Start is called before the first frame update
    private void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    private void Update()
    {
        image.fillAmount = (float)health / (float)maxHealth;
    }
}
