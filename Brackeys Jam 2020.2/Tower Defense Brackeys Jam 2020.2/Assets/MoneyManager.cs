using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public int Score = 0;
    public Text Text;
    public string dText = "S C O R E :  ";

    void Awake()
    {
        Text.text = dText + Score.ToString();
    }

    public void EnenyDied(int score)
    {
        Score += score;
        Text.text = dText + Score.ToString();
    }

    public void PackageDelivered(int score)
    {
        Score += score*3;
        Text.text = dText + Score.ToString();
    }
}
