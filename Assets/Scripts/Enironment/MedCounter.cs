using System.Collections;
using UnityEngine;

public class MedCounter : MonoBehaviour
{
    [Header("Enemies")]
    public int Counter = 0;
    public int Timer = 60;
    public GameObject Wave2;
    public SlashAttackTriggers AttackScript;

    [Header("PowerUps")]
    private GameObject Boons;

    [Header("Misc")]
    private bool CanEndRoom = true;
    private GameHighScore ScoreScript;

    // Start is called before the first frame update
    void Start()
    {
        Wave2 = transform.Find("Wave2").gameObject;
        Wave2.SetActive(false);
        Boons = transform.Find("Boons").gameObject;
        Boons.SetActive(false);
        
        AttackScript = GameObject.Find("Player").GetComponentInChildren<SlashAttackTriggers>();
        AttackScript.FindBarrel();

        ScoreScript = GameObject.Find("Player").GetComponent<GameHighScore>();

        // ScoreScript = GameObject.Find("Player").GetComponent<HighScore>();

        StartCoroutine(RoomTimer());
    }

    void Update()
    {
        if (Counter >= 10) { Wave2.SetActive(true); }
        if (Counter >= 20 && CanEndRoom) { 
            CanEndRoom = false;
            EndRoom(); 
        }
    }

    public void IncreaseCount()
    {
        Counter += 1;
    }

    void EndRoom()
    {
        Game.RoomCleared = true;
        ScoreScript.AddScore(1000);
        // spawns powerups and unlocks doors
        Boons.SetActive(true);

    }

    IEnumerator RoomTimer() {
        while (true) {
            yield return new WaitForSeconds(1);
            Timer -= 1;
            if (Timer <= 0) { yield break; }
        }
    }
}
