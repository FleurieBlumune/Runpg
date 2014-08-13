using UnityEngine;
using System;
using System.Collections;

namespace Run.Managers
{
    public class StatManager : MonoBehaviour
    {
        public static String CharacterLevelString = "CharLevel";
        public static String PlayerXpString = "CharXp";

        public int CharHp, CurCharHp, CharAtk, CharDef, CharXpToLevel, CharXp, CurEnemyLevel;
        public int CurPlayerLevel = PlayerPrefs.GetInt(CharacterLevelString);

        void Start()
        {

            //if (PlayerPrefs.GetInt(PlayerLevelString) == 0)
                SetPlayerLevelToOne();

            if (PlayerPrefs.GetInt(PlayerXpString) == 0)
                SetPlayerInitialXp();

            SetPlayerStatsBasedOnLevel();
        }

        void Update()
        {
            if (CharXp > CharXpToLevel)
                PlayerLevelUp();

            if (CurCharHp <= 0)
                GameEventManager.TriggerGameOver();
        }

        #region Player Level Functions

        void PlayerLevelUp()
        {
            PlayerPrefs.SetInt(CharacterLevelString, CurPlayerLevel + 1);
            SetPlayerStatsBasedOnLevel();
        }

        void SetPlayerLevelToOne()
        {
            PlayerPrefs.SetInt(CharacterLevelString, 1);
        }

        void SetPlayerStatsBasedOnLevel()
        {
            //Check out that hackish shit lol
            CharHp = CurCharHp = CharAtk = CharDef = (CurPlayerLevel * 2);
            CharXpToLevel = CurPlayerLevel * 100;
        }

        void SetPlayerInitialXp()
        {
            PlayerPrefs.SetInt(PlayerXpString, 10);
        }

        #endregion

        #region enemy level functions

        void SetEnemyLevel()
        {
            CurEnemyLevel = (CurPlayerLevel * 2) - 1;
        }

        void SetEnemyTraits()
        { }
        #endregion
    }
}