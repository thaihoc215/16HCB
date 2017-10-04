using UnityEngine;
using NUnit.Framework;
namespace AssemblyCSharp
{
	[TestFixture]
	public class stCellTest
	{
		Vector3    cellPosition;
		csTempleRun.enCellDir  cellDirection;
		csTempleRun.enCellType cellType;
		csTempleRun.stCell temp;
		
		public stCellTest ()
		{
			cellPosition = new Vector3(0.1f, 0.1f, 0.1f);
			cellDirection = csTempleRun.enCellDir.East;
			cellType = csTempleRun.enCellType.DuckObstacle;
			temp = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
		}
		[Test]
		public void TestConstructor()
		{
			Assert.AreEqual(new Vector3(0.1f,0.1f,0.1f), temp.CellPosition, "CellPosition is correct!");
			Assert.AreEqual(csTempleRun.enCellDir.East, temp.CellDirection, "CellDirection is correct!");
			Assert.AreEqual(csTempleRun.enCellType.DuckObstacle, temp.CellType, "CellType is correct!");
		}
	}
}

