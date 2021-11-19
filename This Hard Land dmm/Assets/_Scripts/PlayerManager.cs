using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Vector3 playerCoord;

    public bool canFordsBack;

    public bool posMinus;

    public bool playerXDir;// This is set up as a bool so that it can be used in multiple other update functions with less computing power

}
