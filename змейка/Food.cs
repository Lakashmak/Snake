/*
 * Сделано в SharpDevelop.
 * Пользователь: Сергеич
 * Дата: 25.03.2019
 * Время: 19:58
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace змейка
{
	/// <summary>
	/// Description of Food.
	/// </summary>
	public class Food
	{
		public int raz;
		public int x;
		public int y;
		public Graphics gr;
		Pen pen = new Pen(Color.Red);
		Pen pen2 = new Pen(Color.Blue);
		public Food(int x, int y, Graphics gr, int raz)
		{
			this.x=x;
			this.y=y;
			this.gr=gr;
			this.raz=raz;
		}
		public void Draw()
		{
			if(raz == 1)
			{
				RectangleF block = new RectangleF(x-6,y-6,12,12);
				gr.FillRectangle(new SolidBrush(pen.Color),block);
			}
			if(raz == 2)
			{
				RectangleF block = new RectangleF(x-25,y-25,50,50);
				gr.FillRectangle(new SolidBrush(pen2.Color),block);
			}
		}
	}
}
