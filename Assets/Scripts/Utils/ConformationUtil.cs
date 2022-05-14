using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConformationUtil
{
    public static int AngleIncrement = 60;
    public static RotationAroundAxis StaggerRotation(MoleculeNode main, MoleculeNode side, List<int> bondList)
    {
        int sideToMainBond = bondList[1];
        int mainToSideBond = bondList[0];
        //choose bonds different than their connection
        List<int> mainBonds = main.GetBindedBondNums();
        mainBonds.Remove(mainToSideBond);
        List<int> sideBonds = side.GetBindedBondNums();
        sideBonds.Remove(sideToMainBond);

        Vector3 bondDirection = main.NodeStructure.GetBondDirection(mainToSideBond);

        List<int> mainCarbonBonds = main.GetAllAdjecentBondNumsWithAtomWithout<CarbonAtom>(bondList[0]);
        List<int> sideCarbonBonds = side.GetAllAdjecentBondNumsWithAtomWithout<CarbonAtom>(bondList[1]);

        Debug.Log(mainCarbonBonds.Count);
        Debug.Log(sideCarbonBonds.Count);

        if ((mainCarbonBonds.Count == 1 && sideCarbonBonds.Count == 1) ||
           (mainCarbonBonds.Count == 1 && sideCarbonBonds.Count == 2) ||
           (mainCarbonBonds.Count == 2 && sideCarbonBonds.Count == 1))
        {
            Debug.Log("Whatfuck");
            Vector3 mainDirection = main.NodeStructure.GetBondDirection(mainCarbonBonds[0]);
            Vector3 sideDirection = side.NodeStructure.GetBondDirection(sideCarbonBonds[0]);
            Vector3 mainProj = Vector3.ProjectOnPlane(mainDirection, bondDirection);
            Vector3 sideProj = Vector3.ProjectOnPlane(sideDirection, bondDirection);
            return new RotationAroundAxis(main.NodeStructure.Position, Vector3.Angle(mainProj, sideProj) + 180, bondDirection.normalized);

        }
        else if (mainCarbonBonds.Count == 2 && sideCarbonBonds.Count == 2)
        {
            Debug.Log("This");
            Vector3 mainDirection = main.NodeStructure.GetBondDirection(mainCarbonBonds[0]) + main.NodeStructure.GetBondDirection(mainCarbonBonds[1]);
            Vector3 sideDirection = side.NodeStructure.GetBondDirection(sideCarbonBonds[0]) + side.NodeStructure.GetBondDirection(sideCarbonBonds[1]);
            Vector3 mainProj = Vector3.ProjectOnPlane(mainDirection, bondDirection);
            Vector3 sideProj = Vector3.ProjectOnPlane(sideDirection, bondDirection);
            return new RotationAroundAxis(main.NodeStructure.Position, Vector3.Angle(mainProj, sideProj) + 180, bondDirection.normalized);
        }
        else
        {
            Debug.Log("Here");
            return new RotationAroundAxis(main.NodeStructure.Position, 60, bondDirection.normalized);
        }

    }

    //public static float GetModifiedDistance(MoleculeNode main, MoleculeNode side, int mainBond, int sideBond)
    //{
    //    Vector3 mainDirection = main.NodeStructure.GetBondDirection(mainBond);
    //    Vector3 sideDirection = side.NodeStructure.GetBondDirection(sideBond);
    //    Vector3 diff = mainDirection - sideDirection;
    //    if(main.GetAdjacent(mainBond).IsAtomNode<CarbonAtom>() &&
    //        side.GetAdjacent(sideBond).IsAtomNode<CarbonAtom>())
    //    {
    //        return AppConstants.MethylMethylDistanceFactor * diff.magnitude;
    //    }
    //    else
    //    {
    //        return diff.magnitude;
    //    }
    //}

    //public static float GetModifiedAngle(MoleculeNode main, MoleculeNode side, int mainBond, int sideBond, Vector3 planeNormal)
    //{
    //    Vector3 normal = planeNormal.normalized;
    //    Vector3 mainDirection = main.NodeStructure.GetBondDirection(mainBond);
    //    Vector3 sideDirection = side.NodeStructure.GetBondDirection(sideBond);
    //    Vector3 mainProj = Vector3.ProjectOnPlane(mainDirection, normal);
    //    Vector3 sideProj = Vector3.ProjectOnPlane(sideDirection, normal);
    //    if (main.GetAdjacent(mainBond).IsAtomNode<CarbonAtom>() &&
    //        side.GetAdjacent(sideBond).IsAtomNode<CarbonAtom>())
    //    {
    //        return AppConstants.MethylMethylDistanceFactor * Vector3.Angle(mainProj, sideProj);
    //    }
    //    else
    //    {
    //        return Vector3.Angle(mainProj, sideProj);
    //    }
    //}

    //public static float DivisionByOneWithZeroTolerance(float num)
    //{
    //    if (num == 0)
    //    {
    //        return AppConstants.DivisionByZeroDefaultValue;
    //    }
    //    else
    //    {
    //        return 1f / num;
    //    }
    //}
    
}

