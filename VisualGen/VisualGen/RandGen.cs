using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualGen
{
	public static class RandGen
	{
		static public ulong Seed = InitSeed();

		static public ulong InitSeed()
		{
			ulong seed = (ulong)DateTime.Now.Ticks;
			seed ^= (ulong)System.Diagnostics.Process.GetCurrentProcess().Id;
			seed ^= (ulong)Guid.NewGuid().GetHashCode();
			seed ^= (ulong)Environment.TickCount;
			seed ^= (ulong)System.Environment.WorkingSet;
			seed ^= (ulong)System.GC.GetTotalMemory(false);
			return seed;
		}

		public static ulong Rol(ulong num, int bits)
		{
			return (num << bits) | (num >> (64 - bits));

		}
		public static ulong Ror(ulong num, int bits)
		{
			return (num << (64 - bits)) | (num >> bits);

		}

		static public ulong MagicRandom()
		{
			Seed = Ror(Seed, 4 ) + Rol(Seed, 20);
			Seed = Ror(Seed, 12) + Rol(Seed, 7 );
			Seed = Ror(Seed, 33) + Rol(Seed, 39);
			return Seed;
		}
	}
}
