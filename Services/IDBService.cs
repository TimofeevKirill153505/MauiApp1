using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1
{
				internal interface IDBService
				{
								IEnumerable<Rout> GetAllRoutes();

								IEnumerable<Showplace> GetAllShowplaces();

								void Init();
				}
}
