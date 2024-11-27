using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandStormEffect : MonoBehaviour
{
    public ParticleSystem sandstormParticles; // Reference to the Particle System
    public float stormDuration = 10f;        // Duration of the storm

    private bool isStormActive = false;
    private float stormTimer = 0f;

    void Update()
    {
        if (isStormActive)
        {
            stormTimer += Time.deltaTime;
            if (stormTimer >= stormDuration)
            {
                EndSandstorm();
            }
        }
    }

    public void StartSandstorm()
    {
        if (sandstormParticles != null)
        {
            sandstormParticles.Play();
            isStormActive = true;
            stormTimer = 0f;
        }
        else
        {
            Debug.LogWarning("Sandstorm Particle System not assigned!");
        }
    }

    public void EndSandstorm()
    {
        if (sandstormParticles != null)
        {
            sandstormParticles.Stop();
            isStormActive = false;
        }
    }
}
