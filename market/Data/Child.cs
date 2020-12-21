using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace market.Data
{
	public class Child
	{
		[JsonPropertyName("personalId")]
		public int Id { get; set; }
		public string DisplayName { get; set; }
		public double Price { get; set; }
		public DateTime BirthDate { get; set; }
		public GenderType Gender { get; set; }
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
		MALE = 0,
		FEMALE = 1
	}

	public static class GenderTypeExtensions
	{
		public static string GetName(this GenderType value)
		{
			return value switch
			{
				GenderType.MALE => "Muž",
				GenderType.FEMALE => "Žena",
				_ => "N/A",
			};
		}
	}
}
