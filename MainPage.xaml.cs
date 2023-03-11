namespace MauiApp1;

public class NumbButton:Button
{
				public int Numb
				{
								get;
								set;
				}
}

public partial class MainPage : ContentPage
{

				
				string Number1 = "";
				string Number2 = "";
				string MemoryNumber = "";

				bool isDecimal = false;

				Func<string> DefCount = null;
				Func<string> CurrentOperation = null;

				private void Count(Object sender, EventArgs a)
				{
								if (CurrentOperation == null) return;
								Number2 = InputField.Text;
								InputField.Text = CurrentOperation();
								if (InputField.Text.Contains(',')) isDecimal = true;
								else isDecimal= false;
								Number1 = "";
								Number2 = "";
								InputedField.Text = "";
								CurrentOperation = null;
				}

				void MemRead(object sender, EventArgs args)
				{
								if(MemoryNumber != "")
								InputField.Text = MemoryNumber;
				}

				void MemAdd(object sender, EventArgs args) 
				{
								if (InputField.Text == "ERROR")
								{
												Number1 = "";
												Number2 = "";
												InputField.Text = "0";
												InputedField.Text = "";
												CurrentOperation = null;
												return;
								}

								if (MemoryNumber == "") return;
								if (MemoryNumber.Contains(','))
								{
												decimal a = Convert.ToDecimal(MemoryNumber);
												decimal b = Convert.ToDecimal(InputField);

												MemoryNumber = new string((a + b).ToString().Take(15).ToArray());
								}
								else
								{
												long a = Convert.ToInt64(MemoryNumber);
												long b = Convert.ToInt64(InputField.Text);

												MemoryNumber = new string((a + b).ToString().Take(15).ToArray());

								}
				}

				void MemSub(object sender, EventArgs args)
				{
								if (InputField.Text == "ERROR")
								{
												Number1 = "";
												Number2 = "";
												InputField.Text = "0";
												InputedField.Text = "";
												CurrentOperation = null;
												return;
								}

								if (MemoryNumber == "") return;
								if (MemoryNumber.Contains(','))
								{
												decimal a = Convert.ToDecimal(MemoryNumber);
												decimal b = Convert.ToDecimal(InputField);

												MemoryNumber = new string((a - b).ToString().Take(15).ToArray());

								}
								else
								{
												long a = Convert.ToInt64(MemoryNumber);
												long b = Convert.ToInt64(InputField.Text);

												MemoryNumber = new string((a - b).ToString().Take(15).ToArray());

								}
				}

				void MemLst(object sender, EventArgs args)
				{
								CoolBox.IsVisible = !CoolBox.IsVisible;
								HiddenInfo.IsVisible = !HiddenInfo.IsVisible;
								HiddenInfo.Text = MemoryNumber;
				}

				void MemCl(object sender, EventArgs args)
				{
								MemoryNumber = "";
				}

				void MemSave(object sender, EventArgs args)
				{
								if (InputField.Text == "ERROR")
								{
												Number1 = "";
												Number2 = "";
												InputField.Text = "0";
												InputedField.Text = "";
												CurrentOperation = null;
												return;
								}

								MemoryNumber = InputField.Text;
				}

				void xDivAct(object sender, EventArgs e)
				{
								if (InputField.Text == "ERROR")
								{
												Number1 = "";
												Number2 = "";
												InputField.Text = "0";
												InputedField.Text = "";
												CurrentOperation = null;
												return;
								}

								Number1 = "1";
								isDecimal = true;
								CurrentOperation = Division;
								Count(null, null);
				}

				void SquareAct(object sender, EventArgs e)
				{
								if (InputField.Text == "ERROR")
								{
												Number1 = "";
												Number2 = "";
												InputField.Text = "0";
												InputedField.Text = "";
												CurrentOperation = null;
												return;
								}

								Number1 = InputField.Text;
								CurrentOperation= Multiply;
								Count(null, null);
				}

				void SqrtAct(object sender, EventArgs e) 
				{
								if (InputField.Text == "ERROR")
								{
												Number1 = "";
												Number2 = "";
												InputField.Text = "0";
												InputedField.Text = "";
												CurrentOperation = null;
												return;
								}

								Number2 = InputField.Text;
								decimal A = Convert.ToDecimal(Number2);
								string answer;

								if (A < 0) answer = "ERROR";
								else answer = new string (DecimalMath.DecimalEx.Sqrt(A).ToString().Take(15).ToArray());

								InputField.Text = answer;
								if (InputField.Text.Contains(',')) isDecimal = true;
								else isDecimal = false;
								Number1 = "";
								Number2 = "";
								InputedField.Text = "";
								CurrentOperation = null;
				}

				void PointAct(object sender, EventArgs a) 
				{
								if (InputField.Text == "ERROR")
								{
												Number1 = "";
												Number2 = "";
												InputField.Text = "0";
												InputedField.Text = "";
												CurrentOperation = null;
												return;
								}

								if (InputField.Text.Contains(',') || InputField.Text.Length >= 15) return;
								InputField.Text+= ",";
								isDecimal = true;
				}

				string Sum()
				{
								string answer;
								if (isDecimal)
								{
												decimal a = Convert.ToDecimal(Number1);
												decimal b = Convert.ToDecimal(Number2);
												answer = new string((a + b).ToString().Take(15).ToArray());
								}
								else
								{
												long a = Convert.ToInt64(Number1);
												long b = Convert.ToInt64(Number2);
												answer = new string((a + b).ToString().Take(15).ToArray());
								}

								return answer;
				}

				void Neg(object sender, EventArgs a)
				{
								if (InputField.Text == "0" || InputField.Text == "ERROR" || InputField.Text == "") return;
								if (InputField.Text[0] != '-') InputField.Text = '-' + InputField.Text;
								else InputField.Text = new string(InputField.Text.Skip(1).ToArray());
				}

				void CAct(object sender, EventArgs a)
				{
								Number1 = "";
								Number2 = "";
								CurrentOperation = null;
								InputedField.Text = "";
								InputField.Text = "0";
								isDecimal = false;
				}

				void CEAct(object sender, EventArgs a)
				{
								InputField.Text = "0";
				}

				void log(object sender, EventArgs a)
				{
								if (InputField.Text == "ERROR")
								{
												Number1 = "";
												Number2 = "";
												InputField.Text = "0";
												InputedField.Text = "";
												CurrentOperation = null;
												return;
								}

								decimal A = Convert.ToDecimal(InputField.Text);
								if (A <= 0) return;
								string answer;

								if (A < 0) answer = "ERROR";
								else answer = new string (DecimalMath.DecimalEx.Log(A).ToString().Take(15).ToArray());

								InputField.Text = answer;
								if (InputField.Text.Contains(',')) isDecimal = true;
								else isDecimal = false;
								Number1 = "";
								Number2 = "";
								InputedField.Text = "";
								CurrentOperation = null;
				}

				string Minus()
				{
								string answer;
								if (isDecimal)
								{
												decimal a = Convert.ToDecimal(Number1);
												decimal b = Convert.ToDecimal(Number2);
												answer = new string((a - b).ToString().Take(15).ToArray());
								}
								else
								{
												long a = Convert.ToInt64(Number1);
												long b = Convert.ToInt64(Number2);
												answer = new string((a - b).ToString().Take(15).ToArray());
								}

								return answer;
				}

				string Multiply()
				{
								string answer;
								if (isDecimal)
								{
												decimal a = Convert.ToDecimal(Number1);
												decimal b = Convert.ToDecimal(Number2);
												answer = new string((a * b).ToString().Take(15).ToArray());
								}
								else
								{
												long a = Convert.ToInt64(Number1);
												long b = Convert.ToInt64(Number2);
												answer = new string((a * b).ToString().Take(15).ToArray());

								}

								return answer;
				}

				string Division()
				{
								decimal a = Convert.ToDecimal(Number1);
								decimal b = Convert.ToDecimal(Number2);
								return b!=0 ? new string((a / b).ToString().Take(15).ToArray()) : "ERROR";
				}

				void Percent(object Sender, EventArgs ag)
				{
								if (InputField.Text == "ERROR")
								{
												Number1 = "";
												Number2 = "";
												InputField.Text = "0";
												InputedField.Text = "";
												CurrentOperation = null;
												return;
								}

								if (Number1 == "" || CurrentOperation == null)
								{
												return;
								}

								isDecimal= true;

								Number2 = InputField.Text;
								decimal a = Convert.ToDecimal(Number1);
								decimal b = Convert.ToDecimal(Number2);

								b /= 100;
								b *= a;

								Number2 = new string((b).ToString().Take(15).ToArray());
								Count(null, null);
				}

				void OnDualOperatorClicked(object sender, EventArgs a)
				{
								if(InputField.Text == "ERROR")
								{
												Number1 = "";
												Number2 = "";
												InputField.Text = "0";
												InputedField.Text = "";
												CurrentOperation = null;
												return;
								}
								if (Number1 != "")
								{
												Count(null,null);
								}
								Number1 = InputField.Text;
								InputField.Text = "0";

								Button butt = sender as Button;
								InputedField.Text = Number1 + butt.Text;
								switch (butt.Text)
								{
												case "+":
																CurrentOperation = Sum;
												break;

												case "-":
																CurrentOperation= Minus;
												break;

												case "X":
																CurrentOperation = Multiply;
												break;

												case "/":
																isDecimal = true;
																CurrentOperation= Division;
												break;

								}
								
				}

				public MainPage()
				{
								InitializeComponent();
								DefCount = () => Number1;
								CurrentOperation = DefCount;
				}

				private void OnNumberClicked(Object sender, EventArgs a)
				{
								Button butt = (Button)sender;
								if (InputField.Text.Length >= 15) return;
								if (InputField.Text == "0" || InputField.Text == "ERROR")  InputField.Text = "";
								InputField.Text += butt.Text;

				}

				private void OnDelButtonClicked(Object sender, EventArgs a)
				{
								if (InputField.Text == "ERROR") InputField.Text = "0";
								InputField.Text = new string(InputField.Text.SkipLast(1).ToArray());
								if (InputField.Text == String.Empty || InputField.Text == "-") InputField.Text = "0";
				}

}