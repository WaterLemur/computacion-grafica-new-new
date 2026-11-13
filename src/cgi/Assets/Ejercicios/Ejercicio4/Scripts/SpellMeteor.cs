
using UnityEngine;

namespace Ejercicio4_Spells
{
    public class SpellMeteor : MonoBehaviour
    {
        [Header("REFERENCES")]
        [SerializeField] Animator ground;

        [Header("SETTINGS")]
        [SerializeField] float timer = 0.5f;
        bool shattered = false;



        void Update()
        {
            if (shattered) return;

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ground.SetTrigger("Shatter");
                shattered = true;
            }

        }
    }
}
