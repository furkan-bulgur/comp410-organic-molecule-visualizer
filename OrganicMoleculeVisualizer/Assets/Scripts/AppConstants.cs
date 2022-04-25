using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppConstants
{
    public static float AppScale = 1;
    public static float FullBondLength = 1 * AppScale; 
    public static float BondLength = (FullBondLength / 2) * AppScale;
    public static float BondLengthInsideAtom = (BondLength / 5) * AppScale;
    public static Quaternion DefaultRotation = Quaternion.Euler(new Vector3(0,0,90));
    public static Vector3 DefaultUpVector = Vector3.up;
    public static Vector3 DefaultBondDirection = Vector3.right;
    public static Quaternion DefaultBondRotation = Quaternion.Euler(0, 90, 0);
    public static Vector3 CarbonAtomScale = new Vector3(1, 1, 1) * AppScale;
    public static Vector3 HydrogenAtomScale = new Vector3(0.6f, 0.6f, 0.6f) * AppScale;
    public static Vector3 SingleBondScale = new Vector3(0.3f, BondLength + BondLengthInsideAtom,  0.3f) * AppScale;
}
