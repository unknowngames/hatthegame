using System;
using HatGameLibrary.Public;

namespace HatGameLibrary.Interfaces
{
	public interface IGameView
	{
		string WordArea { get; set; }
		int Points { get; set; }
		TimeSpan LastTime { get; set; }

		event OnClickDelegate Guessed;
		event OnClickDelegate NotGuessed;
	}
}