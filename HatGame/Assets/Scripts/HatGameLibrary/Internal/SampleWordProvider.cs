using System;
using Assets.Scripts.HatGameLibrary.Public.DataBase;
using HatGameLibrary.Interfaces;

namespace HatGameLibrary.Internal
{
	internal class SampleWordProvider : IWordProvider
	{
		private DataBaseService dataBaseService;

		public SampleWordProvider()
		{
			dataBaseService = new DataBaseService("HatBase.db");
		}
		public string GetNextWord()
		{
			Random Rand = new Random();
			string[] Words = new string[]
			{
				"Surprise Mazafaka :)",
				"Табуретка",
				"Зарница",
				"Олина Попа",
				"Мешок"
			};
			return Words[Rand.Next(0, 4)];
		}
	}
}