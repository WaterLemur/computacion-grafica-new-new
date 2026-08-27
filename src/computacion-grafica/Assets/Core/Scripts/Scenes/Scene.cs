using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class Scene : MonoBehaviour
{
    [SerializeField] internal string info = null;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        Text sceneInfo = GameObject.Find("SceneInfo").GetComponent<Text>();
        sceneInfo.text = SceneManager.GetActiveScene().name;
        
        if (!string.IsNullOrEmpty(info))
            sceneInfo.text += " - " + info;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
