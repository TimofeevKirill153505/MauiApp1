namespace MauiApp1;

public partial class DataBase : ContentPage
{
				List<Rout> routs;
				List<Showplace> showplaces;
				public DataBase()
				{
								
								InitializeComponent();
								var serv = SQLService.GetInstance();
								serv.Init();
								routs = serv.GetAllRoutes().ToList();
								showplaces = serv.GetAllShowplaces().ToList();
								picker.ItemsSource = routs;
				}

				void Picked(object sender, EventArgs a)
				{
								var rout = picker.SelectedItem as Rout;
								Items.Text = "";

								foreach(var shwpl in showplaces.Where(s => s.RootId == rout.Id))
								{
												Items.Text += shwpl + "\n";
								}
				}

}