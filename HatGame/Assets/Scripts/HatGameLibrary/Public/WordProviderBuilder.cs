using HatGameLibrary.Interfaces;
using HatGameLibrary.Internal;

namespace HatGameLibrary.Public
{
    public static class WordProviderBuilder
    {
        public static IWordProvider Create()
        {
            return new SampleWordProvider();
        }
    }
}