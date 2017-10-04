using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace AssemblyCSharp2
{
	public enum enCellDir
	{
		North,
		East,
		West,
		South,
		NorthSouth,
		EastWest,
	};
	public enum enCellType
	{
		Run,
		JumpGap,	
		JumpObstacle,
		DuckObstacle,
		LedgeLeft,
		LedgeRight,
	};
	[TestFixture]
	public class CreateObstacleTest
	{
		enCellDir CellDirection;
		enCellDir NeighbourE_CellDirection;
		enCellDir NeighbourW_CellDirection;
		int iCase1;
		int iCase2;
		int iCase3;
		float random1;
		float random2;
		float CellPosition_y;
		float m_tileBaseHeightRuin;
		enCellType CellType;
		
		public CreateObstacleTest()
		{
			CellDirection = enCellDir.East;
			NeighbourW_CellDirection = CellDirection;
			NeighbourE_CellDirection = CellDirection;
			CellPosition_y = -1.5f;
			m_tileBaseHeightRuin = 2.5f;
			iCase1 = 1;
			random1 = 1.0f;
			random2 = 0.4f;
			iCase2 = 2;
			iCase3 = 3;
		}
		[Test]
		public void TestCase1Random1 ()
		{
			if (CellDirection == enCellDir.East || CellDirection == enCellDir.West)
			{					
				if (NeighbourE_CellDirection == CellDirection &&
						NeighbourW_CellDirection == CellDirection) 
				{
					if (iCase1 == 1)
					{
						if (random1 >=0.5f)
						{
							CellType = enCellType.LedgeLeft;
						}
					}
				}
			}		
			Assert.AreEqual(enCellType.LedgeLeft, CellType);
		}
		[Test]
		public void TestCase1Random2 ()
		{
			if (CellDirection == enCellDir.East || CellDirection == enCellDir.West)
			{					
				if (NeighbourE_CellDirection == CellDirection &&
						NeighbourW_CellDirection == CellDirection) 
				{
					if (iCase1 == 1)
					{
						if (random2 >=0.5f)
						{
							
						}
						else
						{
							CellType = enCellType.LedgeRight;
						}
					}
				}
			}		
			Assert.AreEqual(enCellType.LedgeRight, CellType);
		}
		[Test]
		public void TestCase2 ()
		{
			if (CellDirection == enCellDir.East || CellDirection == enCellDir.West)
			{					
				if (NeighbourE_CellDirection == CellDirection &&
						NeighbourW_CellDirection == CellDirection) 
				{
					if (iCase2 == 2)
					{
						CellType = enCellType.JumpObstacle;
					}
				}
			}		
			Assert.AreEqual(enCellType.JumpObstacle, CellType);
		}
		[Test]
		public void TestCase23 ()
		{
			if (CellDirection == enCellDir.East || CellDirection == enCellDir.West)
			{					
				if (NeighbourE_CellDirection == CellDirection &&
						NeighbourW_CellDirection == CellDirection) 
				{
					if (iCase2 == 2)
					{
						CellPosition_y = m_tileBaseHeightRuin;
					}
				}
			}		
			Assert.AreEqual(2.5f, CellPosition_y);
		}
		public void TestCase3 ()
		{
			if (CellDirection == enCellDir.East || CellDirection == enCellDir.West)
			{					
				if (NeighbourE_CellDirection == CellDirection &&
						NeighbourW_CellDirection == CellDirection) 
				{
					if (iCase3 == 3)
					{
						CellType = enCellType.DuckObstacle;
					}
				}
			}		
			Assert.AreEqual(enCellType.DuckObstacle, CellType);
		}
	}
}

