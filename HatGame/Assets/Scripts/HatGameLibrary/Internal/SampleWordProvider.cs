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
			return dataBaseService.GetWord();
		}
	}
}