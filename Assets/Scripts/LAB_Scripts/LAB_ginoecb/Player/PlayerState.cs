using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerState : MonoBehaviour
{
    public _bool isDashing = new _bool();
    public _bool isCastingAbility = new _bool();
    public _bool isCastingSpeed = new _bool();

    private void Awake()
    {
    }

    #region Custom Classes

    // Boolean value that requires explicit function calls for read and write
    [System.Serializable]
    public class _bool
    {
        [SerializeField] private bool variable;

        public bool Check()
        {
            return variable;
        }

        public void Set(bool value)
        {
            variable = value;
        }
    }

    // int value that requires explicit function calls for read and write
    [System.Serializable]
    public class _int
    {
        [SerializeField] private int variable;

        public int Check()
        {
            return variable;
        }

        public void Set(int value)
        {
            variable = value;
        }

        public _int(int value)
        {
            Set(value);
        }

        #region Overloaded Operators

        public static _int operator ++(_int instance)
        {
            instance.variable += 1;
            return instance;
        }

        public static _int operator --(_int instance)
        {
            instance.variable -= 1;
            return instance;
        }

        #endregion Overloaded Operators
    }

    #endregion Custom Classes
}
