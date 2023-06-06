using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int i = 0;
    private void OnTriggerEnter(Collider other)
    {
        /*AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(_audio);

        float lifeTime = Mathf.Max(_audio.length);
        GameObject.Destroy(gameObject, 0.25f);*/
        i++;
        if(i % 2 == 1)
        {
            Managers.Sound.Play("UnityChan/univ0001", Define.Sound.Bgm);
        }
        else
        {
            Managers.Sound.Play("UnityChan/univ0002", Define.Sound.Bgm);
        }
        
       
    }
}
