using System;
using NUnit.Framework;

namespace AssemblyCSharp
{
	[TestFixture]
	public class test
	{
		public csTempleRun.enCellDir m_playerDirection = csTempleRun.enCellDir.North, m_playerNextDirection;
		
		public test ()
		{
		}

		public void Testupdate(csTempleRun.enCellDir direc)
		{
			m_playerDirection = direc;
				if (m_playerDirection == csTempleRun.enCellDir.North)
					m_playerNextDirection = csTempleRun.enCellDir.East;
				if (m_playerDirection == csTempleRun.enCellDir.East)
					m_playerNextDirection = csTempleRun.enCellDir.South;
				if (m_playerDirection == csTempleRun.enCellDir.South)
					m_playerNextDirection = csTempleRun.enCellDir.West;
				if (m_playerDirection == csTempleRun.enCellDir.West)
					m_playerNextDirection = csTempleRun.enCellDir.North;
		}
		
		[Test]
		public void test1()
		{
			Testupdate(csTempleRun.enCellDir.North);
			
			Assert.AreEqual(csTempleRun.enCellDir.East, m_playerNextDirection);
		}
		
		[Test]
		public void test2()
		{
			Testupdate(csTempleRun.enCellDir.East);
			
			Assert.AreEqual(csTempleRun.enCellDir.South, m_playerNextDirection);
		}
		
		[Test]
		public void test3()
		{
			Testupdate(csTempleRun.enCellDir.South);
			
			Assert.AreEqual(csTempleRun.enCellDir.West, m_playerNextDirection);
		}
		
		[Test]
		public void test4()
		{
			Testupdate(csTempleRun.enCellDir.West);
			
			Assert.AreEqual(csTempleRun.enCellDir.North, m_playerNextDirection);
		}
	}
}

