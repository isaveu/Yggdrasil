﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System.Linq;
using Xunit;
using Yggdrasil.Collections;

namespace Yggdrasil.Test.Collections
{
	public class CollectionTests
	{
		[Fact]
		public void AddingAndGetting()
		{
			var col = new Collection<int, int>();

			Assert.Equal(true, col.AddIfNotExists(1, 1000));
			Assert.Equal(true, col.AddIfNotExists(2, 2000));
			Assert.Equal(true, col.AddIfNotExists(3, 3000));
			Assert.Equal(false, col.AddIfNotExists(3, 3333));
			Assert.Equal(true, col.AddIfNotExists(4, 4000));

			Assert.Equal(4, col.Count);
			Assert.Equal(1000, col.GetValueOrDefault(1));
			Assert.Equal(2000, col.GetValueOrDefault(2));
			Assert.Equal(3000, col.GetValueOrDefault(3));
			Assert.Equal(4000, col.GetValueOrDefault(4));
		}

		[Fact]
		public void SettingAndGetting()
		{
			var col = new Collection<int, int>();

			col.AddOrReplace(1, 1000);
			col.AddOrReplace(2, 2000);
			col.AddOrReplace(3, 3000);
			col.AddOrReplace(3, 3333);
			col.AddOrReplace(4, 4000);

			Assert.Equal(4, col.Count);
			Assert.Equal(1000, col.GetValueOrDefault(1));
			Assert.Equal(2000, col.GetValueOrDefault(2));
			Assert.Equal(3333, col.GetValueOrDefault(3));
			Assert.Equal(4000, col.GetValueOrDefault(4));
		}

		[Fact]
		public void Removing()
		{
			var col = new Collection<int, int>();

			col.AddOrReplace(1, 1000);
			col.AddOrReplace(2, 2000);
			col.AddOrReplace(3, 3000);
			col.AddOrReplace(4, 4000);

			col.Remove(2);
			col.Remove(3);

			Assert.Equal(2, col.Count);
			Assert.Equal(1000, col.GetValueOrDefault(1));
			Assert.Equal(4000, col.GetValueOrDefault(4));
		}

		[Fact]
		public void Clearing()
		{
			var col = new Collection<int, int>();

			col.AddOrReplace(1, 1000);
			col.AddOrReplace(2, 2000);
			col.AddOrReplace(3, 3000);
			col.AddOrReplace(4, 4000);

			col.Clear();

			Assert.Equal(0, col.Count);
			Assert.Equal(0, col.GetValueOrDefault(1));
			Assert.Equal(0, col.GetValueOrDefault(2));
			Assert.Equal(0, col.GetValueOrDefault(3));
			Assert.Equal(0, col.GetValueOrDefault(4));
		}

		[Fact]
		public void Containing()
		{
			var col = new Collection<int, int>();

			col.AddOrReplace(1, 1000);
			col.AddOrReplace(2, 2000);
			col.AddOrReplace(3, 3000);
			col.AddOrReplace(4, 4000);

			Assert.Equal(true, col.ContainsKey(1));
			Assert.Equal(true, col.ContainsKey(3));
			Assert.Equal(false, col.ContainsKey(5));
			Assert.Equal(true, col.ContainsValue(2000));
			Assert.Equal(true, col.ContainsValue(4000));
			Assert.Equal(false, col.ContainsValue(6000));
		}

		[Fact]
		public void GetList()
		{
			var col = new Collection<int, int>();

			col.AddOrReplace(1, 1000);
			col.AddOrReplace(2, 2000);
			col.AddOrReplace(3, 3000);
			col.AddOrReplace(4, 4000);

			var lst = col.Get(a => a.Key >= 2 && a.Key <= 3);
			Assert.Equal(2, lst.Count);
			Assert.Equal(2000, lst[2]);
			Assert.Equal(3000, lst[3]);

			col.AddOrReplace(2, 4000);
			Assert.Equal(2, lst.Count);
			Assert.Equal(2000, lst[2]);
			Assert.Equal(3000, lst[3]);
		}
	}
}
