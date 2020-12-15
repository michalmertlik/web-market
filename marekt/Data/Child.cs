using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marekt.Data
{
	public class Child
	{
		public int Id { get; set; }
		public string DisplayName { get; set; }
		public double Price { get; set; }
		public DateTime BirthDate { get; set; }
		public int Age { get; set; }
		public GenderType GenderType { get; set; }
		public bool Virginity { get; set; }
		public double Weight { get; set; }
		public bool Race { get; set; }
		public string Nationality { get; set; }
		public int SkinTone { get; set; }
		public int EyeColor { get; set; }
		public int HairColor { get; set; }
	}
	public enum GenderType
	{
		MALE = 1,
		FEMALE = 2
	}
}
