using UnityEngine;

public class SceneEntrega2SlashCombo : Scene
{
    [Header("STATES")]
    [SerializeField] bool isCinema;
    public bool IsCinema 
    { 
        get => isCinema; 
        set 
        {
            isCinema = value;
            CheckCinemaState();
        } 
    }
    
    [Header("CHARACTERS")]
    [SerializeField] GameObject charRBot;
    [SerializeField] GameObject charRiven;
    [SerializeField] GameObject charLink;
    [SerializeField] GameObject charAang;
    [Space(5)]
    [SerializeField] GameObject charKatara;
    [SerializeField] GameObject charToph;
    [SerializeField] GameObject propChest;
    [SerializeField] GameObject propGoblinThrone;

    [Header("WEAPONS")]
    [SerializeField] GameObject wpnBrokenBlade;
    [SerializeField] GameObject wpnMasterSword;
    [SerializeField] GameObject wpnMasterShield;
    [SerializeField] GameObject wpnAirbenderStaff;

    [Header("PARENTS")]
    [SerializeField] GameObject fXParentObject;
    [SerializeField] GameObject cinemaParentObject;

    public GameObject FXParentObject
    {
        get => fXParentObject;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void CheckCinemaState()
    {
        if(isCinema)
        {
            cinemaParentObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            cinemaParentObject.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    void DisableAll()
    {
        charRBot.SetActive(false);
        charRiven.SetActive(false);
        charLink.SetActive(false);
        charAang.SetActive(false);

        wpnBrokenBlade.SetActive(false);
        wpnMasterSword.SetActive(false);
        wpnMasterShield.SetActive(false);
        wpnAirbenderStaff.SetActive(false);
        
        charKatara.SetActive(false);
        charToph.SetActive(false);
        propChest.SetActive(false);
        propGoblinThrone.SetActive(false);
    }
    void EnableAnng()
    {
        charAang.SetActive(true);
        wpnAirbenderStaff.SetActive(true);

        charKatara.SetActive(true);
        charToph.SetActive(true);
        propChest.SetActive(true);
        propGoblinThrone.SetActive(true);
    }


    // SET SCENE FOR SLASH TYPE
    public void SetSlashPixel()
    {
        DisableAll();

        charRiven.SetActive(true);
        wpnBrokenBlade.SetActive(true);
        

        Debug.Log("SCENE: 👾 Pixel");
    }
    public void SetSlashFire()
    {
        DisableAll();
        EnableAnng();

        Debug.Log("SCENE: 🔥 Fire");
    }
    public void SetSlashWater()
    {
        DisableAll();
        EnableAnng();

        Debug.Log("SCENE: 🌊 Water");
    }
    public void SetSlashThunder()
    {
        DisableAll();
        EnableAnng();

        Debug.Log("SCENE: ⚡ Thunder");
    }
    public void SetSlashCut()
    {
        DisableAll();
        
        charLink.SetActive(true);
        wpnMasterSword.SetActive(true);
        wpnMasterShield.SetActive(true);

        Debug.Log("SCENE: 🩸 Cut");
    }
}
