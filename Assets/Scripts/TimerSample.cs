using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimerSample : MonoBehaviour
{
    Timer timer;


    void Start()
    {
        timer = new Timer();
        timer.Interval = 100;
        //timer.Elapsed += OnTimer;
        timer.Elapsed += new ElapsedEventHandler(OnTimer);

        timer.Start();
    }

    private void OnTimer(object sender, ElapsedEventArgs e)
    {
        Debug.Log("The timer has done.");
    }

    private void OnDisable()
    {
        timer.Dispose();
    }

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }
}
