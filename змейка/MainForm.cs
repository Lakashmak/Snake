/*
 * Сделано в SharpDevelop.
 * Пользователь: Сергеич
 * Дата: 25.03.2019
 * Время: 18:00
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace змейка
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		int ckopoct = 3;
		bool ckpprov = true;
		bool provdvij = true;
		int foodprov = 0;
		int c1; //r
		int c2; //g
		int c3; //b
		Color a;
		Color b;
		int rcd1 = 0;
		int sch = 0;
		bool prov2 = false;
		int nap = 0;
		Random rnd = new Random();
		int x;
		int y;
		int prov = 4;
		Graphics gr;
		Pen pen;
		Pen pen2;
		Pen pen3;
		Bitmap bitmap;
		Snake snake;
		Food food;
		Food food2;
		public MainForm()
		{
			InitializeComponent();
			if(ckopoct == 1)
			{
				timer1.Interval = 325;
			}
			if(ckopoct == 2)
			{
				timer1.Interval = 250;
			}
			if(ckopoct == 3)
			{
				timer1.Interval = 175;
			}
			if(ckopoct == 4)
			{
				timer1.Interval = 100;
			}
			if(ckopoct == 5)
			{
				timer1.Interval = 25;
			}
			label1.Text="счёт:"+sch;
			label2.Text="рекорд:"+rcd1;
			do
			{
				c1 = rnd.Next(0, 256);
				c2 = rnd.Next(0, 256);
				c3 = rnd.Next(0, 256);
			} while (c1 + c2 + c3 > 512);
			a = Color.FromArgb(255, c1, c2, c3);
			b = Color.FromArgb(255,(c1+255)/2,(c2+255)/2,(c3+255)/2);
			x = rnd.Next(1,pictureBox1.Width/25);
			y = rnd.Next(1,pictureBox1.Height/25);
			pen = new Pen(a);
			pen2 = new Pen(b);
			pen3 = new Pen(Color.Red);
			bitmap = new Bitmap(pictureBox1.Width,pictureBox1.Height);
			gr = Graphics.FromImage(bitmap);
			gr.Clear(Color.White);
			snake = new Snake(x*25,y*25,gr,pen,pen2);
			for(int i = 0; i < snake.col_blocks; i++)
			{
				if(i != 0)
				{
					snake.blocks.Add(new block(snake.x,snake.y,snake.gr,snake.pen2));
				}
				if(i == 0)
				{
					snake.blocks.Add(new block(snake.x,snake.y,snake.gr,snake.pen));
				}
			}
			x = rnd.Next(1,pictureBox1.Width/25);
			y = rnd.Next(1,pictureBox1.Height/25);
			food = new Food(x*25,y*25,gr,1);
			x = rnd.Next(1,pictureBox1.Width/25);
			y = rnd.Next(1,pictureBox1.Height/25);
			food2 = new Food(-50,-50,gr,2);
			food.Draw();
			food2.Draw();
			snake.Draw();
			pictureBox1.Image = bitmap;
		}
		
		void Timer1Tick(object sender, EventArgs e)
		{
			ckpprov = false;
			provdvij = true;
			foodprov++;
			if(foodprov == 120)
			{
				foodprov = -30;
				x = rnd.Next(1,pictureBox1.Width/25);
				y = rnd.Next(1,pictureBox1.Height/25);
				food2.x = x*25;
				food2.y = y*25;
				
			}
			if(foodprov == 0)
			{
				food2.x = -50;
				food2.y = -50;
				
			}
			label1.Text="счёт:"+sch;
			label2.Text="рекорд:"+rcd1;
			x = rnd.Next(1,pictureBox1.Width/25);
			y = rnd.Next(1,pictureBox1.Height/25);
			gr.Clear(Color.White);
			if(nap == 4)
			{
				snake.x+=25;
			}
			if(nap == 2)
			{
				snake.x+=-25;
			}
			if(nap == 3)
			{
				snake.y+=25;
			}
			if(nap == 1)
			{
				snake.y+=-25;
			}
			if(snake.x+12 > pictureBox1.Width-25)
			{
				snake.x = 25;
			}
			if(snake.x-12 < 0)
			{
				snake.x = (pictureBox1.Width-25)/25*25;
			}
			if(snake.y+12 > pictureBox1.Height)
			{
				snake.y = 25;
			}
			if(snake.y-12 < 0)
			{
				snake.y = (pictureBox1.Height-25)/25*25;
			}
			if(snake.col_blocks > prov)
			{
				snake.blocks.Add(new block(snake.x,snake.y,snake.gr,snake.pen2));
				prov++;
				prov2 = true;
			}
			if(food.x == snake.x && food.y == snake.y)
			{
				food.x = x*25;
				food.y = y*25;
				snake.col_blocks++;
				sch = sch + ckopoct;
				if(sch > rcd1)rcd1 = sch;
				timer1.Interval = timer1.Interval + 5;
			}
			if(food2.x == snake.x && food2.y == snake.y)
			{
				food2.x = -50;
				food2.y = -50;
				snake.col_blocks = snake.col_blocks + 5;
				sch = sch + ckopoct*5;
				if(sch > rcd1)rcd1 = sch;
				timer1.Interval = timer1.Interval + 25;
			}
			for(int i = 0; i < 1; i++)
			{
				foreach(block element in snake.blocks)
				{
					if(food.x == element.x && food.y == element.y)
					{
						x = rnd.Next(1,pictureBox1.Width/25);
						y = rnd.Next(1,pictureBox1.Height/25);
						i--;
						food.x = x*25;
						food.y = y*25;
					}
				}
			}
			for(int i = 0; i < 1; i++)
			{
				foreach(block element in snake.blocks)
				{
					if(food2.x == element.x && food2.y == element.y)
					{
						x = rnd.Next(1,pictureBox1.Width/25);
						y = rnd.Next(1,pictureBox1.Height/25);
						i--;
						food2.x = x*25;
						food2.y = y*25;
					}
				}
			}
			//*
			if(prov2 == false)
			{
				foreach(block element in snake.blocks)
				{
					if(element != snake.blocks[0])
					{
						if(snake.x == element.x && snake.y == element.y)
						{
							x = rnd.Next(1,pictureBox1.Width/25);
							y = rnd.Next(1,pictureBox1.Height/25);
							snake.blocks.Clear();
							snake.x = x*25;
							snake.y = y*25;
							snake.col_blocks = 4;
							do
							{
								c1 = rnd.Next(0, 256);
								c2 = rnd.Next(0, 256);
								c3 = rnd.Next(0, 256);
							} while (c1 + c2 + c3 > 512);
							a = Color.FromArgb(255,c1,c2,c3);
							b = Color.FromArgb(255,(c1+255)/2,(c2+255)/2,(c3+255)/2);
							pen.Color = a;
							pen2.Color = b;
							for(int i = 0; i < snake.col_blocks; i++)
							{
								if(i != 0)
								{
									//snake.blocks.Add(new block(rnd.Next(1, pictureBox1.Width / 25)*25, rnd.Next(1, pictureBox1.Height / 25) * 25, snake.gr,snake.pen2));
									snake.blocks.Add(new block(snake.x, snake.y, snake.gr, snake.pen2));
								}
								if(i == 0)
								{
									//snake.blocks.Add(new block(rnd.Next(1, pictureBox1.Width / 25) * 25, rnd.Next(1, pictureBox1.Height / 25) * 25, snake.gr,snake.pen));
									snake.blocks.Add(new block(snake.x, snake.y, snake.gr, snake.pen));
								}
							}
							prov = 4;
							sch = 0;
							nap = 0;
							label1.Text="счёт:"+sch;
							if(ckopoct == 1)
							{
								timer1.Interval = 325;
							}
							if(ckopoct == 2)
							{
								timer1.Interval = 250;
							}
							if(ckopoct == 3)
							{
								timer1.Interval = 175;
							}
							if(ckopoct == 4)
							{
								timer1.Interval = 100;
							}
							if(ckopoct == 5)
							{
								timer1.Interval = 25;
							}
							ckpprov = true;
							timer1.Stop();
							break;
						}
					}
				}
			}//*/
			if(prov2 == true)
			{
				prov2 = false;
			}
			snake.Draw();
			food.Draw();
			food2.Draw();
			pictureBox1.Image = bitmap;
		}
		
		void Button1KeyDown(object sender, KeyEventArgs e)
		{
			
			if(provdvij == true)
			{
				if(e.KeyCode == Keys.D && nap != 2)
				{
					nap = 4;
					provdvij = false;
				}
				if(e.KeyCode == Keys.A && nap != 4)
				{
					nap = 2;
					provdvij = false;
				}
				if(e.KeyCode == Keys.S && nap != 1)
				{
					nap = 3;
					provdvij = false;
				}
				if(e.KeyCode == Keys.W && nap != 3)
				{
					nap = 1;
					provdvij = false;
				}
			}
			timer1.Start();
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			if(ckpprov == true)
			{
				ckopoct = Convert.ToInt32(numericUpDown1.Text);
				if(ckopoct == 1)
				{
					timer1.Interval = 325;
				}
				if(ckopoct == 2)
				{
					timer1.Interval = 250;
				}
				if(ckopoct == 3)
				{
					timer1.Interval = 175;
				}
				if(ckopoct == 4)
				{
					timer1.Interval = 100;
				}
				if(ckopoct == 5)
				{
					timer1.Interval = 50;
				}
			}
		}
	}
}
