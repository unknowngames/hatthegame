using SQLite4Unity3d;

namespace Assets.Scripts.HatGameLibrary.Public.DataBase
{
	class Word
	{
		[PrimaryKey, AutoIncrement]
		public int id { get; set; }
		public string word { get; set; }
	}
}
