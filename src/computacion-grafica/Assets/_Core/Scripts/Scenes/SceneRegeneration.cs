using System.Collections.Generic;
using UnityEngine;

public class SceneRegeneration : Scene
{
    [SerializeField] ParticleSystem ps;
    [SerializeField] List<GameObject> characters;
    [SerializeField] List<Animator> animators;
    string animationStateName = "Standing 2H Cast Spell 01";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();

        foreach(GameObject c in characters)
            c.SetActive(false);

        characters[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPlay()
    {
        ps.Play();
        animators[0].Play(animationStateName);
    }

    public void ButtonCharacter()
    {
        int i = 0;
        for(int j = 0; j < characters.Count; j++)
        {
            if(characters[j].activeSelf)
            {
                i = j;
                break;
            }
        }
        characters[i].SetActive(false);
        i++;
        if (i == characters.Count)
            i = 0;

        characters[i].SetActive(true);
    }
}
