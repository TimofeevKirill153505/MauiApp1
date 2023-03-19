using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiApp1
{
				internal class SQLService: IDBService, IDisposable
				{
								static SQLService instance = null;
								SQLiteConnection db;
								
								public void Dispose()
								{
												//???
								}

								SQLService() 
								{
												SQLiteOpenFlags flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;
												string path = Path.Combine(FileSystem.AppDataDirectory, "DataB.db");
												db = new SQLiteConnection(path, flags);
								}

								public static SQLService GetInstance()
								{
												if(instance == null)
																instance = new SQLService();

												return instance;
								}

								public IEnumerable<Rout> GetAllRoutes() 
								{ 
												return db.Table<Rout>();
								}

								public IEnumerable<Showplace> GetAllShowplaces()
								{
												return db.Table<Showplace>();
								}

								public void Init()
								{
												var res = db.CreateTable<Rout>();
												if (res == CreateTableResult.Migrated) return;

												db.CreateTable<Showplace>();

												var routes = new List<Rout>{

																new Rout(){ StartPoint = "Moscow", EndPoint = "Gelendjik", Cost = 0, Id = 1},
																new Rout(){ StartPoint = "Omsk", EndPoint = "Omsk", Cost = 1000},
																new Rout(){ StartPoint = "Perm", EndPoint = "Solekamsk", Cost = 10},
																new Rout(){ StartPoint = "Moscow", EndPoint = "Kyiv", Cost = 300000}
												};
												
												var showplaces = new List<Showplace>() {
																new Showplace(){ Name = "Мечеть имени пророка Мохаммеда",RootId = 1, 
																Adress = "ул. Пушкина, д. Колотушкина", City = "Грозный", Cost = 0},

																new Showplace(){Name = "Метро", RootId = 2, Adress = "ул. Пушкина, д. Колотушкина", City = "Омск", Cost = 1},

																new Showplace(){Name = "Копи Мории", RootId = 3, Adress = "ул. Пушкина, д. Колотушкина", 
																City = "Солекамск", Cost = 500000},
																new Showplace(){Name = "Погран застава", RootId = 4, Adress = "ул. Пушкина, д. Колотушкина",
																City = "Белгород", Cost = 50000},
																new Showplace(){Name = "Макеевский родничок", RootId = 4, Adress = "ул. Пушкина, д. Колотушкина",
																City = "с. Макеевка", Cost = 1}
												};

												db.InsertAll(showplaces);
												db.InsertAll(routes);
								}

				}
}
