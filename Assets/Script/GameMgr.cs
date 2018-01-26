using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Witch
{
    public class GameMgr : MonoBehaviour
    {
        public static GameMgr instance = null;


        //  --- Unity default ---
        // Use this for initialization
        void Awake()
        {
            if (null == instance)
            {
                instance = this;
            }
            else if (this != instance)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);

            InitGame();
            //get instance of managers
        }


        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        //  --- End of Unity default ---


        //initiate game attributes, load data if necessary
        void InitGame()
        {
            // to be implemented
        }




    }



}
