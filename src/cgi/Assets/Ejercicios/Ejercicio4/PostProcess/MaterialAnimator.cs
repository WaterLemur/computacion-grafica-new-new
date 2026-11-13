using System;
using UnityEngine;


namespace Ejercicio4_Spells
{
    [Serializable]
    struct FloatCurve
    {
        public string materialProperty;
        public AnimationCurve curve;
    }


    [RequireComponent(typeof(ParticleSystem))]
    [ExecuteInEditMode]
    public class MaterialAnimator : MonoBehaviour
    {

        [SerializeField] Material targetMaterial;

        ParticleSystem particles;
        [SerializeField] FloatCurve[] curves;
        [SerializeField] float particleTime;


        void Awake()
        {
            particles = GetComponent<ParticleSystem>();
        }
        
        void Evaluate()
        {
            particleTime = particles.time;
            foreach(FloatCurve curve in curves)
            {
                targetMaterial?.SetFloat(curve.materialProperty, curve.curve.Evaluate(particles.time));
            }
        }

        void Update()
        {
            Evaluate();
        }
    }
}