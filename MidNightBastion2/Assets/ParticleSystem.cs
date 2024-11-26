using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystem : MonoBehaviour
{
    [Header("Sandstorm Settings")]
    public ParticleSystem sandstormParticles; // Reference to the Particle System
    public float stormDuration = 10f;         // Duration of the storm
    public float stormIntensity = 1f;        // Intensity multiplier (e.g., particle count)

    private float stormTimer;
    private bool isStormActive;

    void Start()
    {
        // Ensure the Particle System is assigned
        if (sandstormParticles == null)
        {
            sandstormParticles = GetComponent<ParticleSystem>();
            if (sandstormParticles == null)
            {
                Debug.LogError("No Particle System found! Please assign one to Sandstorm.");
            }
        }

        stormTimer = 0f;
        isStormActive = false;
    }

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
            // Adjust particle emission rate based on intensity
            var emission = sandstormParticles.emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(50f * stormIntensity);

            // Start the particle system
            sandstormParticles.Play();

            isStormActive = true;
            stormTimer = 0f;
        }
        else
        {
            Debug.LogWarning("No Particle System assigned to Sandstorm script.");
        }
    }

    public void EndSandstorm()
    {
        if (sandstormParticles != null)
        {
            sandstormParticles.Stop();

            isStormActive = false;
            stormTimer = 0f;
        }
    }
}


