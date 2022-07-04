using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gerisayim : MonoBehaviour
{
    float floatzaman;
    int sayac;
    public Text zamantext;
    public Text uyaritext;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        uyaritext.text = "Bölümü bitirmek için 20 saniyeniz var";
    }


    void Update()
    {
        zamanyazdir();
        zamantext.text = "Zaman:" + sayac.ToString() + "sn";
        if (sayac == 2)
        {
            uyaritext.gameObject.SetActive(false);
        }

        else if (sayac == 21)
        {
            uyaritext.gameObject.SetActive(true);
            uyaritext.text = "Süreniz bitti,Kaybettiniz!";
        }
        else if (sayac == 23)
        {
            SceneManager.LoadScene(6);
        }

    }
    void zamanyazdir()
    {
        floatzaman += Time.deltaTime;
        if (floatzaman > 1)
        {
            sayac++;
            floatzaman = 0;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            uyaritext.gameObject.SetActive(true);
            uyaritext.text = "Tebrikler,Kazandınız! Seviye atlanıyor...";
            SceneManager.LoadScene(7);
            PlayerPrefs.SetInt("level", 2);
         }
        

    }

}
