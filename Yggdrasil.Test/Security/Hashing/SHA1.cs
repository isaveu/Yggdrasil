﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System.Text;
using Xunit;
using Yggdrasil.Security.Hashing;

namespace Yggdrasil.Test.Security.Hashing
{
	public class SHA1Tests
	{
		[Fact]
		public void Encode()
		{
			Assert.Equal("7110EDA4D09E062AA5E4A390B0A572AC0D2C0220", SHA1.Encode("1234"));
			Assert.Equal(new byte[] { 0x71, 0x10, 0xED, 0xA4, 0xD0, 0x9E, 0x06, 0x2A, 0xA5, 0xE4, 0xA3, 0x90, 0xB0, 0xA5, 0x72, 0xAC, 0x0D, 0x2C, 0x02, 0x20 },
				SHA1.Encode(Encoding.UTF8.GetBytes("1234")));

			Assert.Equal("0A0A9F2A6772942557AB5355D76AF442F8F65E01", SHA1.Encode("Hello, World!"));
			Assert.Equal(new byte[] { 0x0A, 0x0A, 0x9F, 0x2A, 0x67, 0x72, 0x94, 0x25, 0x57, 0xAB, 0x53, 0x55, 0xD7, 0x6A, 0xF4, 0x42, 0xF8, 0xF6, 0x5E, 0x01 },
				SHA1.Encode(Encoding.UTF8.GetBytes("Hello, World!")));
		}
	}
}
