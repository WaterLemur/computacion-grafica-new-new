using UnityEngine;

public class SceneEntrega2SlashCombo : Scene
{
    [Header("CHARACTERS")]
    [SerializeField] GameObject charRBot;
    [SerializeField] GameObject charRiven;
    [SerializeField] GameObject charLink;
    [SerializeField] GameObject charAang;
    [SerializeField] GameObject charKatara;
    [Space(5)]
    [SerializeField] GameObject propChest;
    [SerializeField] GameObject propGoblinThrone;

    [Header("WEAPONS")]
    [SerializeField] GameObject wpnBrokenBlade;
    [SerializeField] GameObject wpnMasterSword;
    [SerializeField] GameObject wpnMasterShield;
    [SerializeField] GameObject wpnAirbenderStaff;

    [Header("FX GAMEOBJECT")]
    [SerializeField] GameObject fXParentObject;

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

    void DisableAll()
    {
        charRBot.SetActive(false);
        charRiven.SetActive(false);
        charLink.SetActive(false);
        charAang.SetActive(false);
        charKatara.SetActive(false);

        wpnBrokenBlade.SetActive(false);
        wpnMasterSword.SetActive(false);
        wpnMasterShield.SetActive(false);
        wpnAirbenderStaff.SetActive(false);
        
        propChest.SetActive(false);
        propGoblinThrone.SetActive(false);
    }
    void EnableAnng()
    {
        charAang.SetActive(true);
        wpnAirbenderStaff.SetActive(true);

        charKatara.SetActive(true);

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
