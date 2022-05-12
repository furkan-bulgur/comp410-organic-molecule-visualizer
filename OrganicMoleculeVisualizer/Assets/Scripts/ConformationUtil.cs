using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConformationUtil
{
    public static int AngleIncrement = 60;
    public static RotationAroundAxis StaggerRotation(MoleculeTreeNode parent, MoleculeTreeNode child)
    {
        int childToParentBondNum = child.ChildToParentBond;
        int parentToChildBondNum = child.ParentToChildBond;
        //choose bonds different than their connection
        int randomParentBondNum = -1;
        int randomChildBondNum = -1;
        do
        {
            randomParentBondNum = Random.Range(1, parent.NodeStructure.totalBondNum);
            randomChildBondNum = Random.Range(1, child.NodeStructure.totalBondNum);
        } while (randomParentBondNum != parentToChildBondNum && randomChildBondNum != childToParentBondNum);

        Vector3 bondDirection = parent.NodeStructure.GetBondDirection(parentToChildBondNum);
        Vector3 parentDirection = parent.NodeStructure.GetBondDirection(randomParentBondNum);
        Vector3 childDirection = child.NodeStructure.GetBondDirection(randomChildBondNum);

        float resultAngle = 0;
        float currentMaxDistance = 0;
        for(int i = 0; i < 360; i += AngleIncrement)
        {
            Quaternion currentRotation = Quaternion.AngleAxis(i, bondDirection);
            Vector3 currentChildDirection = currentRotation * childDirection;
            Vector3 diff = parentDirection - currentChildDirection;
            if(diff.magnitude >= currentMaxDistance)
            {
                currentMaxDistance = diff.magnitude;
                resultAngle = i;
            }
        }

        return new RotationAroundAxis(parent.NodeStructure.Position, resultAngle, bondDirection.normalized);



    }
    
}

