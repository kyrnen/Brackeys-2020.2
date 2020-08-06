using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStartCounting : MonoBehaviour
{
    public GameObject GameStartCountingGameObject;

    public Text Text;
    public float timeLeft = 3;
    public float Timebetwwen;
    private void Start()
    {
        Timebetwwen = timeLeft;
    }
    void Update()
    {
        Timebetwwen -= Time.deltaTime;
        Text.text = timeLeft.ToString("F2");
        if (GameStartCountingGameObject.activeSelf)
        {
            StartCoroutine(GameSartCountingFuction());

            if(Timebetwwen <= 0)
            {
                GetComponent<GameStartCounting>().enabled = true;
                GetComponent<BuildManager>().enabled = true;
                GetComponent<Bullet>().enabled = true;
                GetComponent<CameraPan>().enabled = true;
                GetComponent<CameraZoom>().enabled = true;
                GetComponent<GenericTower>().enabled = true;
                GetComponent<MainMenu>().enabled = true;
                GetComponent<MusicManager>().enabled = true;
                GetComponent<Node>().enabled = true;
                GetComponent<PauseMenu>().enabled = true;
                GetComponent<PlayerHealth>().enabled = true;
                GetComponent<RewindTime>().enabled = true;
                GetComponent<ScrollText>().enabled = true;
                GetComponent<Target>().enabled = true;
                GetComponent<Turret>().enabled = true;
                GetComponent<WaveManager>().enabled = true;
                GetComponent<Waypoints>().enabled = true;
            }
        }
    }
    IEnumerator GameSartCountingFuction()
    {
        GetComponent<GameStartCounting>().enabled = false;
        GetComponent<CameraPan>().enabled = false;
        GetComponent<CameraZoom>().enabled = false;
        GetComponent<GenericTower>().enabled = false;
        GetComponent<MainMenu>().enabled = false;
        GetComponent<MusicManager>().enabled = false;
        GetComponent<Node>().enabled = false;
        GetComponent<PauseMenu>().enabled = false;
        GetComponent<PlayerHealth>().enabled = false;
        GetComponent<RewindTime>().enabled = false;
        GetComponent<ScrollText>().enabled = false;
        GetComponent<Target>().enabled = false;
        GetComponent<Turret>().enabled = false;
        GetComponent<WaveManager>().enabled = false;
        GetComponent<Waypoints>().enabled = false;
        yield return new WaitForSeconds(3);
        yield break;
    }
}
