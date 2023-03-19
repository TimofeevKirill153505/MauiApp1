using System.Threading;

namespace MauiApp1;

public partial class ProgressPage : ContentPage
{

				Task tsk = null;
				CancellationTokenSource cts = null;
				CancellationToken tok;
				public ProgressPage()
				{
								InitializeComponent();
				}

				void Count()
				{
								double res = 0;
								double trash = 0;
								double h = 0.0001;
								for (double x = 0; x <= 1; x += h)
								{
												if (tok.IsCancellationRequested == true)
												{
																MainThread.BeginInvokeOnMainThread(() => ProgLabel.Text = "Процесс отменен");
																return;
												}

												res += Math.Sin(x) * h;

												for(int i = 0; i < 100; ++i)
												{
																if (i % 2 == 0) trash += i * i * i;
																else trash -= i * i * i;
												}

												MainThread.BeginInvokeOnMainThread(SetProgress(x, res));
								}

								MainThread.BeginInvokeOnMainThread(() => ProgLabel.Text = $"Полученный результат: {res}");
				}

				Action SetProgress(double proc, double res)
				{
								return () =>
								{
												ProgBar.Progress = proc;
												if (proc < 1) ProgLabel.Text = $"Процесс работает: {Math.Round(proc * 100, 2)}%";
												else ProgLabel.Text = $"Полученный результат: {res}";
								};
				}

				void StartM(object sender, EventArgs e)
				{
								cts = new CancellationTokenSource();
								tok = cts.Token;
								tsk = new Task(Count, tok);
								tsk.Start();
				}

				async void CancelM(object sender, EventArgs e)
				{
								if (tsk == null) return;			
								cts.Cancel();
								await tsk;
								tsk.Dispose();
								tsk = null;
				}
}