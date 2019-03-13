using UnityEngine;

public class CorruptedHeart : MonoBehaviour
{
    public IntVariable currentKillCount;
    public IntVariable clearLevel1;
    public IntVariable clearLevel2;
    public IntVariable clearLevel3;
    
    private float totalKills;

    private Animator HeartBeat;
    public IntVariable CurrentHealth;
    public FloatVariable HeartColor;
    private Color colorChange;
    public Color startColor;
    
    private SpriteRenderer heart;
    // Start is called before the first frame update
    void Start()
    {
        heart = GetComponent<SpriteRenderer>();
        HeartBeat = GetComponent<Animator>();
        heart.color = startColor;
        //heart.color = Color.Lerp(startColor, endColor, HeartColor.Value);

        totalKills = clearLevel1.Value + clearLevel2.Value + clearLevel3.Value;
        colorChange = new Color(1.5f, 1.5f, 1.5f, 0);
    }

    void Update()
    {
        switch(CurrentHealth.Value)
        {
            case 1: case 2:
                HeartBeat.speed = 5;
                break;
            case 3: case 4:
                HeartBeat.speed = 4;
                break;
            case 5: case 6:
                HeartBeat.speed = 3;
                break;
            case 7: case 8:
                HeartBeat.speed = 2;
                break;
            case 9: case 10:
                HeartBeat.speed = 1;
                break;
        }

        Darken();
    }

    private void Darken()
    {
        HeartColor.Value = (currentKillCount.Value / totalKills);
        heart.color = startColor - colorChange * HeartColor.Value;
    }
}