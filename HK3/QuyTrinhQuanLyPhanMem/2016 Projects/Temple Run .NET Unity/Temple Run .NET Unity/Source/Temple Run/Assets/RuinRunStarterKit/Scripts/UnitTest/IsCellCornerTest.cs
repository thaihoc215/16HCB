using System;
using NUnit.Framework;
using UnityEngine;
namespace AssemblyCSharp
{
	[TestFixture]
	public class IsCellCornerTest
	{
		public IsCellCornerTest ()
		{
			
		}
		
		[Test]
		public void TestNorthCellDirection()
		{
			bool isCellCorner = false;
			csTempleRun.stCell cell = new csTempleRun.stCell(new Vector3(1,1,1), csTempleRun.enCellDir.North, csTempleRun.enCellType.DuckObstacle);
			cell.NeighbourE = new csTempleRun.stCell(new Vector3(1,1,1), csTempleRun.enCellDir.North, csTempleRun.enCellType.DuckObstacle);
			cell.NeighbourW = new csTempleRun.stCell(new Vector3(1,1,2), csTempleRun.enCellDir.North, csTempleRun.enCellType.JumpObstacle);
			if (cell.CellDirection == csTempleRun.enCellDir.North) {
				if (cell.NeighbourE != null || cell.NeighbourW != null)
				{
					isCellCorner = true;
				}			
			}
			Assert.AreEqual(true, isCellCorner);
		}
	}
}

