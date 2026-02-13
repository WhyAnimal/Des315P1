using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreforanceTracker : MonoBehaviour
{

    public float worstFPS = -1f;
    public float meanFPS = -1f;
    public float mediumFPS = -1f;
    public float bestFPS = -1f;

    public float FPSTimeCheck = 10.0f;
    private float fpsTimer = 0;

    private float fpsSum = 0;
    private int frameCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Count this frame
        float currentFPS = 1f / Time.deltaTime; // deltaTime -> FPS
        fpsSum += currentFPS;
        frameCount++;

        // Track best/worst FPS
        if (bestFPS < currentFPS || bestFPS < 0)
            bestFPS = currentFPS;

        if (worstFPS > currentFPS || worstFPS < 0)
            worstFPS = currentFPS;

        // Timer countdown
        fpsTimer -= Time.deltaTime;

        if (fpsTimer <= 0f)
        {
            // Calculate mean and medium FPS
            meanFPS = fpsSum / frameCount;

            // Approximate medium as the average of best and worst
            mediumFPS = (bestFPS + worstFPS) / 2f;

            // Reset for next measurement
            fpsSum = 0;
            frameCount = 0;
            fpsTimer = FPSTimeCheck;


        }

    }
}
