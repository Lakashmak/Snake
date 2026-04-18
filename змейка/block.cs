/*
 * Сделано в SharpDevelop.
 * Пользователь: Сергеич
 * Дата: 25.03.2019
 * Время: 18:09
 * 
 * Для изменения этого шаблона используйте Сервис | Настройка | Кодирование | Правка стандартных заголовков.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace змейка
{
	/// <summary>
	/// Description of block.
	/// </summary>
	public class block
	{
		public int x;
		public int y;
		public Graphics gr;
		public Pen pen;
		public block(int x, int y, Graphics gr, Pen pen)
		{
			this.x=x;
			this.y=y;
			this.gr=gr;
			this.pen=pen;
		}
		public void Draw()
		{
			RectangleF block = new RectangleF(x-11,y-11,23,23);
			gr.FillRectangle(new SolidBrush(pen.Color),block);
		}
	}
}
