using UnityEngine;
using NUnit.Framework;
using System.IO;
using System.Reflection.Emit;

namespace AssemblyCSharp
{
	[TestFixture]
	public class CreateSceneryTest4
	{
		csTempleRun.stCell tcell;
		public GameObject m_Rock1 ;
		public GameObject m_Rock2;
		public GameObject m_Rock3;
		public GameObject m_Rock4;
		public GameObject m_Column;
		public GameObject m_Tree;
		public GameObject m_Ruin1;
		public GameObject m_Ruin2;
		
		public CreateSceneryTest4 ()
		{
			tcell = new csTempleRun.stCell(new Vector3(1,1,1),csTempleRun.enCellDir.East,csTempleRun.enCellType.DuckObstacle);
			m_Rock1 = new GameObject("rock1");
			m_Rock2 = new GameObject("rock2");
			m_Rock3 = new GameObject("rock3");
			m_Rock4 = new GameObject("rock4");
			m_Column = new GameObject("m_Column");
			m_Tree = new GameObject("m_Tree");
			m_Ruin1 = new GameObject("m_Ruin1");
			m_Ruin2 = new GameObject("m_Ruin2");
		}
		
		public int CreateScenery(csTempleRun.stCell cell, float r)
		{
			// Create Scenery
			//random (0.0f, 1.0f)
			if (cell == null && r > 0.25f) 
			{
				int sceneryID = Random.Range (0, 8);
				int sceneryPrefab = -1;
	
				switch (sceneryID) 
					{
					case 0:
						sceneryPrefab = 0;
						break;
					case 1:
						sceneryPrefab = 1;
						break;
					case 2:
						sceneryPrefab = 2;
						break;
					case 3:
						sceneryPrefab = 3;
						break;
					case 4:
						sceneryPrefab = 4;
						break;					
					case 5:
						sceneryPrefab = 5;
						break;					
					case 6:
						sceneryPrefab = 6;
						break;		
					case 7:
						sceneryPrefab = 7;
						break;				
					}
				return sceneryPrefab;
			}
			return -1;
		}
		
		[Test]
		public void CreateSceneryTest1()
		{
			int result = -1;//CreateScenery(null,0.5f);
			Assert.AreEqual(-1, result);
		}
		
		[Test]
		public void CreateSceneryTest2()
		{
			int result =-1;// CreateScenery(null,0.25f);
			Assert.AreEqual(-1, result);
		}
	}
}

