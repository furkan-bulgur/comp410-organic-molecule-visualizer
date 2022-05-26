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


        if ((mainCarbonBonds.Count == 1 && sideCarbonBonds.Count == 1) ||
           (mainCarbonBonds.Count == 1 && sideCarbonBonds.Count == 2) ||
           (mainCarbonBonds.Count == 2 && sideCarbonBonds.Count == 1))
        {
            
            Vector3 mainDirection = main.NodeStructure.GetBondDirection(mainCarbonBonds[0]);
            Vector3 sideDirection = side.NodeStructure.GetBondDirection(sideCarbonBonds[0]);
            Vector3 mainProj = Vector3.ProjectOnPlane(mainDirection, bondDirection);
            Vector3 sideProj = Vector3.ProjectOnPlane(sideDirection, bondDirection);
            return new RotationAroundAxis(main.NodeStructure.Position, Vector3.Angle(mainProj, sideProj) + 180, bondDirection.normalized);

        }
        else if (mainCarbonBonds.Count == 2 && sideCarbonBonds.Count == 2)
        {
            
            Vector3 mainDirection = main.NodeStructure.GetBondDirection(mainCarbonBonds[0]) + main.NodeStructure.GetBondDirection(mainCarbonBonds[1]);
            Vector3 sideDirection = side.NodeStructure.GetBondDirection(sideCarbonBonds[0]) + side.NodeStructure.GetBondDirection(sideCarbonBonds[1]);
            Vector3 mainProj = Vector3.ProjectOnPlane(mainDirection, bondDirection);
            Vector3 sideProj = Vector3.ProjectOnPlane(sideDirection, bondDirection);
            return new RotationAroundAxis(main.NodeStructure.Position, Vector3.Angle(mainProj, sideProj) + 180, bondDirection.normalized);
        }
        else
        {
            Vector3 mainDirection = main.NodeStructure.GetBondDirection(mainBonds[0]);
            Vector3 sideDirection = side.NodeStructure.GetBondDirection(sideBonds[0]);
            Vector3 mainProj = Vector3.ProjectOnPlane(mainDirection, bondDirection);
            Vector3 sideProj = Vector3.ProjectOnPlane(sideDirection, bondDirection);
            //Debug.Log("Angle : " + Vector3.Angle(mainProj, sideProj));
            return new RotationAroundAxis(main.NodeStructure.Position, - Vector3.Angle(mainProj, sideProj) + 60, bondDirection.normalized);
        }

    }

    
}

