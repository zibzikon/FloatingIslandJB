using System.Collections.Generic;
using UnityEngine;

public interface IBuildingContainer
{ 
   void SetBuildPointsPosition();
   public BuildPoint GetCorrectBuildPoint(Building building, Direction3 direction);
}
