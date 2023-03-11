using System.Threading;

namespace MauiApp1;

public partial class ProgressPage : ContentPage
{

				Task<double> tsk = null;
				CancellationTokenSource cts= new CancellationTokenSource();
				public ProgressPage()
				{
								InitializeComponent();
				}

				double Count()
				{
								double res = 0;
								double trash = 0;
								double h = 0.00000001;
								for (double x = 0; x <= 1; x += h)
								{
												if (cts.Token.IsCancellationRequested == true)
												{
																return 0;
												}

												res += Math.Sin(x) * h;

												for(int i = 0; i < 100; ++i)
												{
																if (i % 2 == 0) trash += i * i * i;
																else trash -= i * i * i;
												}

												MainThread.BeginInvokeOnMainThread(SetProgress(x, res));
								}

								return res;
				}

				Action SetProgress(double proc, double res)
				{
								return () =>
								{
												ProgBar.Progress = proc;
												if (proc != 1) ProgLabel.Text = $"Процесс работает: {Math.Round(proc * 100, 2)}%";
												else ProgLabel.Text = $"Полученный результат: {res}";
								};
				}

				void StartM(object sender, EventArgs e)
				{
								tsk = new Task<double>(Count, cts.Token);
								tsk.Start();
				}

				void CancelM(object sender, EventArgs e)
				{
								cts.Cancel();
								ProgLabel.Text = "Процесс отменен";
								tsk = null;
				}
}