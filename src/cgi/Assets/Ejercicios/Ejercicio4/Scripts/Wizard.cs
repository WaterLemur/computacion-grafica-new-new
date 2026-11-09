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
        [Space(5)]
        [SerializeField] Transform spellParent;
        [SerializeField] Transform SpellSpawnPoint;
        [Space(5)]
        [SerializeField] Transform cam;
        [SerializeField] Transform camPosWiz;
        [SerializeField] Transform camPosSpell;

        [Header("SPELLS")]
        [SerializeField] GameObject 불;
        [SerializeField] GameObject 물;
        [SerializeField] GameObject 풀;
        [Space(5)]
        [SerializeField] GameObject 원불;
        [SerializeField] GameObject 원물;
        [SerializeField] GameObject 원풀;


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
                ClearParent();
                CastSpell();

                Transform circlePos = animWizard.gameObject.transform;
                GameObject c = Instantiate(원불, circlePos);
                c.transform.parent = spellParent;

                GameObject go = Instantiate(불, SpellSpawnPoint);
                go.transform.parent = spellParent;
                go.GetComponentInChildren<Animator>().SetTrigger("Play");
            }
        }
        public void OnBlizzard(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                ClearParent();
                CastSpell();

                Transform circlePos = animWizard.gameObject.transform;
                GameObject c = Instantiate(원불, circlePos);
                c.transform.parent = spellParent;

                GameObject go = Instantiate(물, SpellSpawnPoint);
                go.transform.parent = spellParent;
            }
        }
        public void OnEarthquake(InputAction.CallbackContext ctx)
        {
            if (ctx.started)
            {
                ClearParent();
                CastSpell();

                Transform circlePos = animWizard.gameObject.transform;
                GameObject c = Instantiate(원풀, circlePos);
                c.transform.parent = spellParent;

                GameObject go = Instantiate(풀, SpellSpawnPoint);
                go.transform.parent = spellParent;
                go.GetComponentInChildren<Animator>().SetTrigger("Play");
            }
        }

        void ClearParent()
        {
            foreach (Transform child in spellParent)
            {
                Destroy(child.gameObject);
            }
        }


        public void StateMachine()
        {
            switch (state)
            {
                case State.Idle:
                    cam.position = camPosWiz.position;
                    cam.rotation = camPosWiz.rotation;
                    break;


                case State.Charging:
                    animWizard.ResetTrigger("Charge");
                    animStaff.ResetTrigger("Charge");

                    cam.position = camPosSpell.position;
                    cam.rotation = camPosSpell.rotation;
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
