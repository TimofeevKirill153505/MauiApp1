using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiApp1
{
				public enum TypeOfRoom
				{
								Basic,
								Family,
								VIP
				}
				
				[Table("Routes")]
				internal class Rout
				{
								[PrimaryKey, Indexed, AutoIncrement]
								public uint Id { get; set; }

								public string StartPoint { get; set; }

								public string EndPoint { get; set; }
								
								public decimal Cost { get; set; }

								public override string ToString()
								{
												return $"{Id}. {StartPoint} - {EndPoint}: {Cost}$";
								}
				}


				[Table("Showplaces")]
				class Showplace
				{
								[PrimaryKey, Indexed]
								public string Name { get; set; }
								public string City	{ get; set; }

								public decimal Cost { get; set; }

								public string Adress { get; set; }

								[Indexed]
								public uint RootId { get; set; }

								public override string ToString()
								{
												return $"{Name} в {City} по цене {Cost} по адресу {Adress};";
								}
				}
}
