using HatGameLibrary.Interfaces;

namespace HatGameLibrary.Internal
{
    internal class SampleWordProvider : IWordProvider
    {
        public string GetNextWord()
        {
            return "sample";
        }
    }
}