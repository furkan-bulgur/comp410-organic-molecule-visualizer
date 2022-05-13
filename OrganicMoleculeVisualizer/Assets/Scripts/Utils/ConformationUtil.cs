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
        float resultAngle = 0;
        float currentMaxDistance = 0;
        for (int i = 0; i < 360; i += AngleIncrement)
        {
            Quaternion currentRotation = Quaternion.AngleAxis(i, bondDirection);
            float factoredDistance = 0f;
            foreach(int mainBond in mainBonds)
            {
                foreach(int sideBond in sideBonds)
                {
                    factoredDistance += GetModifiedDistance(main, side, mainBond, sideBond);
                }
            }
            Debug.Log(factoredDistance);
            if (factoredDistance >= currentMaxDistance)
            {
                currentMaxDistance = factoredDistance;
                resultAngle = i;
            }
        }
        
        return new RotationAroundAxis(main.NodeStructure.Position, resultAngle, bondDirection.normalized);
        //return null;


    }

    public static float GetModifiedDistance(MoleculeNode main, MoleculeNode side, int mainBond, int sideBond)
    {
        Vector3 mainDirection = main.NodeStructure.GetBondDirection(mainBond);
        Vector3 sideDirection = side.NodeStructure.GetBondDirection(sideBond);
        Vector3 diff = mainDirection - sideDirection;
        if(main.GetAdjacent(mainBond).IsAtomNode<CarbonAtom>() &&
            side.GetAdjacent(sideBond).IsAtomNode<CarbonAtom>())
        {
            return AppConstants.MethylMethylDistanceFactor * diff.magnitude;
        }
        else
        {
            return diff.magnitude;
        }
    }
    
}

