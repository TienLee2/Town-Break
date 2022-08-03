using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    public int Time;
    private Spawner launch;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Activate", Time);
        launch = this.gameObject.GetComponent<Spawner>();
    }

    void Activate()
    {
        launch.enabled = true;
    }
   
}
