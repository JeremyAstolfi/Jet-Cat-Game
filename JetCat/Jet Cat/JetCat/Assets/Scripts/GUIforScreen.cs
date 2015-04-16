using UnityEngine;
using System.Collections;

public class GUIforScreen : MonoBehaviour {

    public JetCatInteraction character;
    public GameManager gM;
    public Texture heartTexture;
    public Texture fuelTexture;

    void Start()
    {
    }

    void OnGUI()
    {
        for (int h = 0; h < character.health; h++)
        {
            GUI.DrawTexture(new Rect(h * 55, 0, 50, 50), heartTexture);
        }
        for (int f = 0; f < character.fuelAmount; f++)
        {
            GUI.DrawTexture(new Rect(f * 55, 60, 50, 10), fuelTexture);
        }
        guiText.text = "Score : " + gM.Score.ToString();
    }
}
