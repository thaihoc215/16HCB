using UnityEngine;
using NUnit.Framework;
using System.IO;
using System.Reflection.Emit;
namespace AssemblyCSharp
	
{	[TestFixture]
	public class CreateSceneryTest1
	{
		csTempleRun.stCell cell;
		csTempleRun.enCellDir  cellDirection;
		csTempleRun.enCellType cellType;
		Vector3    cellPosition;
		
		public CreateSceneryTest1 ()
		{		
		}

		[Test]
		public void TestCellDirWest1()
		{
			//cell.NeighbourE != null
			//cell.NeighbourS == null
			//cell.NeighbourN == null
			cellDirection = csTempleRun.enCellDir.West;
			cell = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourE = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			bool bOkArch = true;
			
			if (cell.NeighbourE != null) {
					bOkArch = true;
				}

				if (cell.NeighbourS != null) {
					bOkArch = false;
				}

				if (cell.NeighbourN != null) {
					bOkArch = false;
				}
			
			
			Assert.AreEqual(true, bOkArch);
			
		}
		[Test]
		public void TestCellDirWes2()
		{
			//cell.NeighbourE == null
			//cell.NeighbourS != null
			//cell.NeighbourN == null
			cellDirection = csTempleRun.enCellDir.West;
			cell = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourS = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			bool bOkArch = true;
			
			if (cell.NeighbourE != null) {
					bOkArch = true;
				}

				if (cell.NeighbourS != null) {
					bOkArch = false;
				}

				if (cell.NeighbourN != null) {
					bOkArch = false;
				}
			
			
			Assert.AreEqual(false, bOkArch);
			
		}
		[Test]
		public void TestCellDirWest3()
		{
			//cell.NeighbourE == null
			//cell.NeighbourS == null
			//cell.NeighbourN != null
			cellDirection = csTempleRun.enCellDir.West;
			cell = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourN = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			bool bOkArch = true;
			
			if (cell.NeighbourE != null) {
					bOkArch = true;
				}

				if (cell.NeighbourS != null) {
					bOkArch = false;
				}

				if (cell.NeighbourN != null) {
					bOkArch = false;
				}
			
			
			Assert.AreEqual(false, bOkArch);
			
		}
		[Test]
		public void TestCellDirWest4()
		{
			//cell.NeighbourE != null
			//cell.NeighbourS != null
			//cell.NeighbourN == null
			cellDirection = csTempleRun.enCellDir.West;
			cell = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourE = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourS = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			bool bOkArch = true;
			
			if (cell.NeighbourE != null) {
					bOkArch = true;
				}

				if (cell.NeighbourS != null) {
					bOkArch = false;
				}

				if (cell.NeighbourN != null) {
					bOkArch = false;
				}
			
			
			Assert.AreEqual(false, bOkArch);
			
		}
		[Test]
		public void TestCellDirWest5()
		{
			//cell.NeighbourE != null
			//cell.NeighbourS == null
			//cell.NeighbourN != null
			cellDirection = csTempleRun.enCellDir.West;
			cell = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourN = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourE = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			bool bOkArch = true;
			
			if (cell.NeighbourE != null) {
					bOkArch = true;
				}

				if (cell.NeighbourS != null) {
					bOkArch = false;
				}

				if (cell.NeighbourN != null) {
					bOkArch = false;
				}
			
			
			Assert.AreEqual(false, bOkArch);
			
		}
		[Test]
		public void TestCellDirWest6()
		{
			//cell.NeighbourE == null
			//cell.NeighbourS != null
			//cell.NeighbourN != null
			cellDirection = csTempleRun.enCellDir.West;
			cell = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourN = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourS = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			bool bOkArch = true;
			
			if (cell.NeighbourE != null) {
					bOkArch = true;
				}

				if (cell.NeighbourS != null) {
					bOkArch = false;
				}

				if (cell.NeighbourN != null) {
					bOkArch = false;
				}
			
			
			Assert.AreEqual(false, bOkArch);
			
		}
		[Test]
		public void TestCellDirWest7()
		{
			//cell.NeighbourE != null
			//cell.NeighbourS != null
			//cell.NeighbourN != null
			cellDirection = csTempleRun.enCellDir.West;
			cell = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourN = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourS = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			cell.NeighbourE = new csTempleRun.stCell(cellPosition, cellDirection, cellType);
			bool bOkArch = true;
			
			if (cell.NeighbourE != null) {
					bOkArch = true;
				}

				if (cell.NeighbourS != null) {
					bOkArch = false;
				}

				if (cell.NeighbourN != null) {
					bOkArch = false;
				}
			
			
			Assert.AreEqual(false, bOkArch);
			
		}
		
	
	
	
	}
		


}

