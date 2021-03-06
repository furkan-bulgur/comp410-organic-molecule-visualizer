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

    public static Quaternion DefaultRotation = Quaternion.identity;
    public static Vector3 DefaultUpVector = Vector3.up;
    public static Vector3 DefaultBondDirection = Vector3.right;
    public static Quaternion DefaultBondRotation = Quaternion.Euler(0, 90, 0);
    public static Vector3 CarbonAtomScale = new Vector3(CarbonAtomRadius * 2, CarbonAtomRadius * 2, CarbonAtomRadius * 2) * AppScale;
    public static Vector3 HydrogenAtomScale = new Vector3(HydrogenAtomRadius * 2, HydrogenAtomRadius * 2, HydrogenAtomRadius * 2) * AppScale;
    public static Vector3 SingleBondScale = new Vector3(BondRadius * 2, BondLength / 2, BondRadius * 2) * AppScale;

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

    public static int AllowedAlkaneChainMaxCarbonNum = 7;


    public static float MethylMethylDistanceFactor = 2f;
    public static float DivisionByZeroDefaultValue = 1f;

    public static Dictionary<string, int> AlkaneNaming = new Dictionary<string, int>
    {
        {"methane", 1},
        {"ethane", 2},
        {"propane", 3},
        {"butane", 4},
        {"pentane", 5},
        {"hexane", 6},
        {"heptane", 7},
        {"octane", 8},
        {"nonane", 9},

    };
    public static Dictionary<string, int> AlkaneBranchNaming = new Dictionary<string, int>
    {
        {"methyl", 1},
        {"ethyl", 2},
    };

    public static Dictionary<string, int> AlkaneBranchCountNaming = new Dictionary<string, int>
    {
        {"di", 2},
        {"tri", 3},
        {"tetra", 4},
    };

}
