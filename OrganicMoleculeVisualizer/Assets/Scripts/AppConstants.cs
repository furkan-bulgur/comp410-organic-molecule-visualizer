using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AppConstants
{
    public static float AppScale = 1;
    public static float FullBondLength = 0.5f * AppScale; 
    public static float BondLength = (FullBondLength / 2) * AppScale;
    public static float BondLengthInsideAtom = (BondLength / 5) * AppScale;
    public static float BondLengthOutsideAtom = BondLength - BondLengthInsideAtom;
    public static float BondRadius = 0.15f;
    public static float HydrogenAtomRadius = 0.3f;
    public static float CarbonAtomRadius = 0.5f;

    public static Quaternion DefaultRotation = Quaternion.Euler(new Vector3(0,0,90));
    public static Vector3 DefaultUpVector = Vector3.up;
    public static Vector3 DefaultBondDirection = Vector3.right;
    public static Quaternion DefaultBondRotation = Quaternion.Euler(0, 90, 0);
    public static Vector3 CarbonAtomScale = new Vector3(CarbonAtomRadius*2, CarbonAtomRadius * 2, CarbonAtomRadius * 2) * AppScale;
    public static Vector3 HydrogenAtomScale = new Vector3(HydrogenAtomRadius*2, HydrogenAtomRadius * 2, HydrogenAtomRadius * 2) * AppScale;
    public static Vector3 SingleBondScale = new Vector3(BondRadius*2, BondLength/2, BondRadius*2) * AppScale;

    public const int SingleBondNum = 1;
    public const int SingleBondTotalBondNum = 1;
    public static Dictionary<int, Vector3> SingleBondDefaultDirections = new Dictionary<int, Vector3>()
    {
        {1, new Vector3(1,0,0) },
    };

    public const int TetrahedralTotalBondNum = 4;
    public static Dictionary<int, Vector3> TetrahedralBondDefaultDirections = new Dictionary<int, Vector3>()
    {
        {1, new Vector3(1,-1,1) },
        {2, new Vector3(1,1,-1) },
        {3, new Vector3(-1,1,1) },
        {4, new Vector3(-1,-1,-1) },
    };

    public static int AllowedAlkaneChainMaxCarbonNum = 6;

}
