/*
 * Сделано в SharpDevelop.
 * Пользователь: Сергеич
 * Дата: 25.03.2019
 * Время: 18:08
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
	/// Description of Snake.
	/// </summary>
	public class Snake
	{
		public int x;
		public int y;
		int x1;
		int y1;
		int x2;
		int y2;
		public int col_blocks = 4;
		public Graphics gr;
		public Pen pen;
		public Pen pen2;
		public List<block> blocks = new List<block>();
		public Snake(int x, int y, Graphics gr, Pen pen, Pen pen2)
		{
			this.x=x;
			this.y=y;
			this.gr=gr;
			this.pen=pen;
			this.pen2=pen2;
		}
		
		public void Draw()
		{
			Random rnd = new Random();
			x1 = x;
			y1 = y;
			foreach(block element in blocks) if(element != blocks[0])
			{
				x2 = element.x;
				y2 = element.y;
				element.x = rnd.Next(-1, 2) * 0 + x1;
				element.y = rnd.Next(-1, 2) * 0 + y1;
				element.Draw();
				x1 = x2;
				y1 = y2;
			}
			else
            {
				x2 = element.x;
				y2 = element.y;
				element.x = x1;
				element.y = y1;
				element.Draw();
				x1 = x2;
				y1 = y2;
            }
			blocks[0].Draw();
		}
	}
}
