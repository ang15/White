using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class ResultBest : MonoBehaviour
    {
        [SerializeField]
        public Text vvod;

        private void Start()
        {
            if (PlayerPrefs.HasKey("Monets"))
            {
                
                vvod.text = " " + PlayerPrefs.GetInt("Monets");

            }
            else
            {
                vvod.text = " " + 0;
            }

        }

        private void Update()
        {

            if (PlayerPrefs.HasKey("Monets"))
            {
               vvod.text = " " + PlayerPrefs.GetInt("Monets");
            }
            else
            {
                vvod.text = " " + 0;
            }
        }

    }
