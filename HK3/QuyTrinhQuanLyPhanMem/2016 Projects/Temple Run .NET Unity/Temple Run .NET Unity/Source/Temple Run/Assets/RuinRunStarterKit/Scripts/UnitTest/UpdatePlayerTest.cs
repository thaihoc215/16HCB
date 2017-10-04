using UnityEngine;
using NUnit.Framework;
namespace AssemblyCSharp
{
	[TestFixture]
	public class UpdatePlayerTest
	{
		csTempleRun.enCellDir m_playerDirection;
		csTempleRun.enCellDir m_playerNextDirection;
		public UpdatePlayerTest ()
		{
		}
		[Test]
		public void North()
		{
			m_playerDirection = csTempleRun.enCellDir.North;
			
			if (m_playerDirection == csTempleRun.enCellDir.North)
				m_playerNextDirection = csTempleRun.enCellDir.East;
			if (m_playerDirection == csTempleRun.enCellDir.East)
				m_playerNextDirection = csTempleRun.enCellDir.South;
			if (m_playerDirection == csTempleRun.enCellDir.South)
				m_playerNextDirection = csTempleRun.enCellDir.West;
			if (m_playerDirection == csTempleRun.enCellDir.West)
				m_playerNextDirection = csTempleRun.enCellDir.North;
			
			Assert.AreEqual(csTempleRun.enCellDir.East, m_playerNextDirection);
		}
		[Test]
		public void East()
		{
			m_playerDirection = csTempleRun.enCellDir.East;
			
			if (m_playerDirection == csTempleRun.enCellDir.North)
				m_playerNextDirection = csTempleRun.enCellDir.East;
			if (m_playerDirection == csTempleRun.enCellDir.East)
				m_playerNextDirection = csTempleRun.enCellDir.South;
			if (m_playerDirection == csTempleRun.enCellDir.South)
				m_playerNextDirection = csTempleRun.enCellDir.West;
			if (m_playerDirection == csTempleRun.enCellDir.West)
				m_playerNextDirection = csTempleRun.enCellDir.North;
			
			Assert.AreEqual(csTempleRun.enCellDir.South, m_playerNextDirection);
		}
		[Test]
		public void South()
		{
			m_playerDirection = csTempleRun.enCellDir.South;
			
			if (m_playerDirection == csTempleRun.enCellDir.North)
				m_playerNextDirection = csTempleRun.enCellDir.East;
			if (m_playerDirection == csTempleRun.enCellDir.East)
				m_playerNextDirection = csTempleRun.enCellDir.South;
			if (m_playerDirection == csTempleRun.enCellDir.South)
				m_playerNextDirection = csTempleRun.enCellDir.West;
			if (m_playerDirection == csTempleRun.enCellDir.West)
				m_playerNextDirection = csTempleRun.enCellDir.North;
			
			Assert.AreEqual(csTempleRun.enCellDir.West, m_playerNextDirection);
		}
				[Test]
		public void West()
		{
			m_playerDirection = csTempleRun.enCellDir.West;
			
			if (m_playerDirection == csTempleRun.enCellDir.North)
				m_playerNextDirection = csTempleRun.enCellDir.East;
			if (m_playerDirection == csTempleRun.enCellDir.East)
				m_playerNextDirection = csTempleRun.enCellDir.South;
			if (m_playerDirection == csTempleRun.enCellDir.South)
				m_playerNextDirection = csTempleRun.enCellDir.West;
			if (m_playerDirection == csTempleRun.enCellDir.West)
				m_playerNextDirection = csTempleRun.enCellDir.North;
			
			Assert.AreEqual(csTempleRun.enCellDir.North, m_playerNextDirection);
		}
	}
}

