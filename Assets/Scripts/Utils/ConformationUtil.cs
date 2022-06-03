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

        Vector3 bondDirection = main.NodeStructure.GetBondDirection(mainToSideBond).normalized;

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
            Vector3 cross = Vector3.Cross(mainProj, sideProj).normalized;
            float alignmentAngle = -Vector3.Angle(mainProj, sideProj);
            if (-1 * bondDirection == cross)
            {
                alignmentAngle *= -1;
            }

            return new RotationAroundAxis(main.NodeStructure.Position, alignmentAngle + 180, bondDirection.normalized);

        }
        else if (mainCarbonBonds.Count == 2 && sideCarbonBonds.Count == 2)
        {
            
            Vector3 mainDirection = main.NodeStructure.GetBondDirection(mainCarbonBonds[0]) + main.NodeStructure.GetBondDirection(mainCarbonBonds[1]);
            Vector3 sideDirection = side.NodeStructure.GetBondDirection(sideCarbonBonds[0]) + side.NodeStructure.GetBondDirection(sideCarbonBonds[1]);
            Vector3 mainProj = Vector3.ProjectOnPlane(mainDirection, bondDirection);
            Vector3 sideProj = Vector3.ProjectOnPlane(sideDirection, bondDirection);
            Vector3 cross = Vector3.Cross(mainProj, sideProj).normalized;
            float alignmentAngle = -Vector3.Angle(mainProj, sideProj);
            if (-1 * bondDirection == cross)
            {
                alignmentAngle *= -1;
            }

            return new RotationAroundAxis(main.NodeStructure.Position, alignmentAngle + 180, bondDirection.normalized);
            
        }
        else
        {
            Vector3 mainDirection = main.NodeStructure.GetBondDirection(mainBonds[0]);
            Vector3 sideDirection = side.NodeStructure.GetBondDirection(sideBonds[0]);
            Vector3 mainProj = Vector3.ProjectOnPlane(mainDirection, bondDirection);
            Vector3 sideProj = Vector3.ProjectOnPlane(sideDirection, bondDirection);
            Vector3 cross = Vector3.Cross(mainProj, sideProj).normalized;
            float alignmentAngle = -Vector3.Angle(mainProj, sideProj);
            if(-1*bondDirection == cross)
            {
                alignmentAngle *= -1;
            }
            
            return new RotationAroundAxis(main.NodeStructure.Position, alignmentAngle + 60, bondDirection.normalized);
            //Debug.Log($"Main Direction : {mainDirection}");
            //Debug.Log($"Side Direction : {sideDirection}");
            //Debug.Log($"Main Proj : {mainProj}");
            //Debug.Log($"Side Proj : {sideProj}");
            //Debug.Log($"Bond Direction : {bondDirection}");
            //Debug.Log($"Cross Product : {Vector3.Cross(mainProj,sideProj).normalized}");
            //Debug.Log($"Angle : {Vector3.Angle(mainProj, sideProj)}");
        }

    }

    
}

