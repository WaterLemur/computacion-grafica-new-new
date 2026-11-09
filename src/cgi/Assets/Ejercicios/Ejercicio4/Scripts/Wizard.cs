using UnityEngine;
using UnityEngine.InputSystem;


namespace Ejercicio4
{
    public enum State
    {
        Idle,
        Charging,
        Holding,
        Casting
    }
    public class Wizard : MonoBehaviour
    {
        [Header("VARIABLES")]
        [SerializeField] State state = State.Idle;
        public State CuteState { get => state; set => state = value; }    

        public float timeHold = 2.0f;
        public float timer = 0.0f;

        [Header("REFERENCES")]
        [SerializeField] Animator animWizard;
        [SerializeField] Animator animStaff;

        [Header("SPELLS")]
        [SerializeField] GameObject meteor;
        [SerializeField] GameObject earthquake;


        public static Wizard W { get; private set; }

        void Awake()
        {
            if (W == null)
            {
                W = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start()
        {
            timer = timeHold;
        }

        void Update()
        {
            StateMachine();
        }


        public void CastSpell()
        {
            Debug.Log("Casting spell");
            animWizard.SetTrigger("Charge");
            animStaff.SetTrigger("Charge");
        }

        public void OnMeteor(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                CastSpell();
                GameObject go = Instantiate(meteor);
                go.GetComponentInChildren<Animator>().SetTrigger("Play");
            }
        }
        public void OnBlizzard()
        {
            CastSpell();
        }
        public void OnEarthquake(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                CastSpell();
                GameObject go = Instantiate(earthquake);
                go.GetComponentInChildren<Animator>().SetTrigger("Play");

            }
        }


        public void StateMachine()
        {
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Charging:
                    animWizard.ResetTrigger("Charge");
                    animStaff.ResetTrigger("Charge");
                    break;
                case State.Holding:
                    timer -= Time.deltaTime;
                    if (timer <= 0)
                    {
                        state = State.Casting;
                        timer = timeHold;

                        animWizard.SetTrigger("Cast");
                        animStaff.SetTrigger("Cast");
                    }
                    break;
                case State.Casting:
                        animWizard.ResetTrigger("Cast");
                        animStaff.ResetTrigger("Cast");
                    break;
            }
        }
    }
}
