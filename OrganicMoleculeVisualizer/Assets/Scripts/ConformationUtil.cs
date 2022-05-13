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
        int randomParentBondNum = -1;
        int randomChildBondNum = -1;
        do
        {
            randomParentBondNum = Random.Range(1, main.NodeStructure.totalBondNum);
            randomChildBondNum = Random.Range(1, side.NodeStructure.totalBondNum);
        } while (randomParentBondNum != mainToSideBond && randomChildBondNum != sideToMainBond);

        Vector3 bondDirection = main.NodeStructure.GetBondDirection(mainToSideBond);
        Vector3 parentDirection = main.NodeStructure.GetBondDirection(randomParentBondNum);
        Vector3 childDirection = side.NodeStructure.GetBondDirection(randomChildBondNum);

        float resultAngle = 0;
        float currentMaxDistance = 0;
        for (int i = 0; i < 360; i += AngleIncrement)
        {
            Quaternion currentRotation = Quaternion.AngleAxis(i, bondDirection);
            Vector3 currentChildDirection = currentRotation * childDirection;
            Vector3 diff = parentDirection - currentChildDirection;
            if (diff.magnitude >= currentMaxDistance)
            {
                currentMaxDistance = diff.magnitude;
                resultAngle = i;
            }
        }

        return new RotationAroundAxis(main.NodeStructure.Position, resultAngle, bondDirection.normalized);
        //return null;


    }
    
}

