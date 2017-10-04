using NUnit.Framework;
using UnityEngine;
using System;
using System.Collections.Generic;

namespace AssemblyCSharp1
{
	[TestFixture]
	public class UpdateMinesTest
	{
		float m_coinMagetTimer;
		float m_maxCoinMagetTimer;
		float m_Point;
		float m_maxPointBonus;
		int currentTypeCase2;
		int currentTypeDefault;
		Vector3 minesPosition;
		Vector3 playerPosition;
		public UpdateMinesTest ()
		{
			minesPosition = new Vector3(1, 1, 1);
			playerPosition = new Vector3(1, 1, 2);
			currentTypeCase2 = 2;
			currentTypeDefault = 3;
			m_maxCoinMagetTimer = 10.0f;
			m_Point = 1.0f;
			m_maxPointBonus = 5.0f;
		}
		
		[Test]
		public void TestPoint()
		{	
			if (Vector3.Distance(minesPosition, playerPosition)<1.0f)
			{
				if (currentTypeCase2 == 2)
				{
					m_Point += m_maxPointBonus;	
					Assert.AreEqual(6.0f,m_Point);
				}
			}
		}
		
		[Test]
		public void TestCoinMaget()
		{
			if (Vector3.Distance(minesPosition, playerPosition)<1.0f)
			{
				if (currentTypeDefault == 3)
				{
					m_coinMagetTimer = m_maxCoinMagetTimer;
					Assert.AreEqual(10.0f,m_coinMagetTimer);
				}
			}
		}
	}
}

