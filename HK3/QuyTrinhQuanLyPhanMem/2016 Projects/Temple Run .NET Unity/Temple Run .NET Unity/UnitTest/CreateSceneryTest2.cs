using NUnit.Framework;
using System;
using UnityEngine;

namespace AssemblyCSharp
{
	// 1012030
	[TestFixture]
	public class UnitTEST
	{
		Rect scrRect;
		csTempleRun.stCell sCell;
		csTempleRun.stCell dummyCell;
		
		public UnitTEST()
		{
			scrRect = new Rect(0,0,0,0);
			dummyCell = new csTempleRun.stCell(new Vector3(0, 0, 0), 
				csTempleRun.enCellDir.East, 
				csTempleRun.enCellType.DuckObstacle);
			sCell = dummyCell;
		}
		
		private bool CreateScenery(csTempleRun.stCell cell)
		{
			bool bOkArch = true;
				if (cell.NeighbourS != null) {
					bOkArch = true;
				}

				if (cell.NeighbourW != null) {
					bOkArch = false;
				}

				if (cell.NeighbourE != null) {
					bOkArch = false;
				}
			return bOkArch;
		}
		
		private bool isConerCell(csTempleRun.stCell cell)
		{
			if (cell.CellDirection == csTempleRun.enCellDir.West) 
			{
				if (cell.NeighbourN != null || cell.NeighbourS != null)
				return true;
			}

			return false;
		}
		
		// screenRect - line 603
		[Test]
		public void TestScreenRect()
		{
			Rect result = csTempleRun.screenRect(0,0,0,0);
			Assert.AreEqual(scrRect, result);
		}
		
		// CreateScenery - line 1163 - 1177
		[Test]
		public void TestCreateScenery()
		{
			bool result = CreateScenery(sCell);
			Assert.AreEqual(true, result);
		}
		
		[Test]
		public void TestCreateScenery_South()
		{
			sCell.NeighbourS = dummyCell;
			bool result = CreateScenery(sCell);
			sCell.NeighbourS = null;
			Assert.AreEqual(true, result);
		}
		
		[Test]
		public void TestCreateScenery_West()
		{
			sCell.NeighbourW = dummyCell;
			bool result = CreateScenery(sCell);
			sCell.NeighbourW = null;
			Assert.AreEqual(false, result);
		}
		
		[Test]
		public void TestCreateScenery_Est()
		{
			sCell.NeighbourE = dummyCell;
			bool result = CreateScenery(sCell);
			sCell.NeighbourE = null;
			Assert.AreEqual(false, result);
		}
		
		// isConerCell - line 2081 - 2083
		[Test()]
		public void TestisConerCell()
		{
			sCell.CellDirection = csTempleRun.enCellDir.East;
			bool result = isConerCell(sCell);
			Assert.AreEqual(false, result);
		}
		
		[Test()]
		public void TestisConerCell_West()
		{
			sCell.CellDirection = csTempleRun.enCellDir.West;
			sCell.NeighbourN = null;
			sCell.NeighbourS = null;
			bool result = isConerCell(sCell);
			Assert.AreEqual(false, result);
		}
		
		[Test()]
		public void TestisConerCell_WestNorth()
		{
			sCell.CellDirection = csTempleRun.enCellDir.West;
			sCell.NeighbourN = dummyCell;
			sCell.NeighbourS = null;
			bool result = isConerCell(sCell);
			sCell.NeighbourN = null;
			Assert.AreEqual(true, result);
		}
		
		[Test()]
		public void TestisConerCell_WestSouth()
		{
			sCell.CellDirection = csTempleRun.enCellDir.West;
			sCell.NeighbourN = null;
			sCell.NeighbourS = dummyCell;
			bool result = isConerCell(sCell);
			sCell.NeighbourS = null;
			Assert.AreEqual(true, result);
		}
	}
}

