using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinyRatAttack : MonoBehaviour{
    public float FuseTime;
    private bool FuseLit = false;
    private EnemyStateInfo Self;
    private EnemyStateInfo.State State;
    private GameObject Blast;
    private ParticleSystem Explosion;
    private bool Exploded = false;

    public SmallCounter SmallCounterScript;
    public MedCounter MediumCounterScript;


    void Start() {
        Self = transform.gameObject.GetComponent<EnemyStateInfo>();
        Blast = transform.Find("BlastRadius").gameObject;
        Explosion = Blast.transform.Find("Particle System").gameObject.GetComponent<ParticleSystem>();
    }

    void Update(){
        State = Self.state;

        if (Self.ReadyToStart) {

            if (State == EnemyStateInfo.State.Mele) {
                FuseLit = true;
            }

            if (FuseLit == true){
                if (FuseTime <= 0){
                    if (Exploded == false) {
                        StartCoroutine(Explode());
                    }
                }else{
                    FuseTime -= Time.deltaTime;
                }
            }
        }
    }

    IEnumerator Explode() {
        if (SmallCounterScript != null)
        {
            SmallCounterScript.Counter += 1;

        }
        else if (MediumCounterScript != null)
        {
            MediumCounterScript.Counter += 1;

        }

        Exploded = true;
        Blast.SetActive(true);
        Destroy(transform.Find("Point Light").gameObject);
        Destroy(transform.Find("Alarm").gameObject);
        Destroy(transform.Find("Body").gameObject);
        Destroy(transform.Find("Tire").gameObject);
        Destroy(transform.Find("Tire_001").gameObject);
        Explosion.Play();
        yield return new WaitForSeconds(Explosion.main.duration);
        Destroy(transform.parent.gameObject);

    }

}
