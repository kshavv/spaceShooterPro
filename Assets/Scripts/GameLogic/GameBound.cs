using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Scripts.GameLogic
{
    internal static class GameBound //static classes are sealed by default - cannot derive other classes
    {
        public static void DefinePlayerBound(Transform playerTransform)
        {
            playerTransform.position = new Vector3(playerTransform.position.x, Mathf.Clamp(playerTransform.position.y,-5.0f,0), 0);

            if(playerTransform.position.x >= 13.3f)
            {
                playerTransform.position = new Vector3(-13.3f, playerTransform.position.y, 0);
            }
            else if (playerTransform.position.x <= -13.3f)
            {
                playerTransform.position = new Vector3(13.3f, playerTransform.position.y, 0);

            }
        }
    }
}
