using System;
using HatGameLibrary.Interfaces;

namespace HatGameLibrary.Internal
{
    internal class SampleWordProvider : IWordProvider
    {
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
		return Words[Rand.Next(0,4)];
        }
    }
}