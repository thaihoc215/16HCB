using System;
using UnityEngine;
using NUnit.Framework;
namespace AssemblyCSharp
{
	[TestFixture]
	public class CreateObstacleTest
	{
		float m_tileBaseHeightRuin = -0.1f; 
		float m_tileBaseHeightBridge = 0.65f; 
		public CreateObstacleTest ()
		{
		}
		
		[Test]
		public void TestChangeCellTheme()
		{
			csTempleRun.stCell c = new csTempleRun.stCell(new Vector3(1,1,1), csTempleRun.enCellDir.North, csTempleRun.enCellType.DuckObstacle);
			c.CellTheme = csTempleRun.enCellTheme.Stone;
			c.CellTheme = (c.CellTheme == csTempleRun.enCellTheme.Stone ? csTempleRun.enCellTheme.Bridge : csTempleRun.enCellTheme.Stone);
			Assert.AreEqual(c.CellTheme, csTempleRun.enCellTheme.Bridge);
			c.CellPosition.y = (c.CellTheme == csTempleRun.enCellTheme.Stone ? m_tileBaseHeightRuin : m_tileBaseHeightBridge);
			Assert.AreEqual(0.65f,c.CellPosition.y); 
		}
	}
}

