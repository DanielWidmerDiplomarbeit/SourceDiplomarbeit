using System;
using ZeusMobile.Models;

namespace ZeusMobile.ViewModels
{
	class TodoItemCellViewModel : BaseViewModel
	{
		TodoItem todo;

		public TodoItem Item { get { return todo; }}

		public string Name { get { return todo.Name; }}

		public DateTime Schadensdatum { get { return todo.Schadensdatum; }}

		public bool Done {get { return todo.Done; }}

		public TodoItemCellViewModel (TodoItem todoItem)
		{
			todo = todoItem;
		}
	}
}

