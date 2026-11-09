
using UnityEngine;

namespace Ejercicio4
{
    public class SpellMeteor : MonoBehaviour
    {
        [Header("REFERENCES")]
        [SerializeField] private ParticleSystem rock;
        [SerializeField] private Animator ground;

        [Header("SETTINGS")]
        [SerializeField] private float groundShatterTime = 0.5f;

        private ParticleSystem.Particle[] particles;
        private bool shattered;

        private void Awake()
        {
            particles = new ParticleSystem.Particle[
                rock.main.maxParticles
            ];
        }

        private void Update()
        {
            if (shattered) return;

            int count = rock.GetParticles(particles);

            for (int i = 0; i < count; i++)
            {
                ParticleSystem.Particle p = particles[i];

                if (p.remainingLifetime <= groundShatterTime)
                {
                    ground.SetTrigger("Shatter");
                    shattered = true;
                    break;
                }
            }
        }
    }
}
